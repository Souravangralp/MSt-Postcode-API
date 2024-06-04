namespace ProductMatrix.Infrastructure.Services.ProductFilter;

public class PostcodeProductSelectorService : IPostcodeProductSelectorService
{
    #region Fields

    private readonly IApplicationDbContext _context;

    #endregion

    #region Ctor

    public PostcodeProductSelectorService(IApplicationDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Methods

    public async Task<List<int?>> GetProducts(string postcode, string? stateCode, string? suburb)
    {
        List<PostcodeClassification> postcodeClassifications = [];
        List<int?> productIds = [];
        PostcodeSuburbMapper? postcodeSuburbMapper = null;

        var code = await _context.Postcodes.Where(p => p.Code == postcode)
                                           .AsNoTracking()
                                           .FirstOrDefaultAsync() ?? throw new NotFoundException(postcode, nameof(Postcode));

        if (suburb is not null && stateCode is not null)
        {
            var existingState = await _context.States.Where(state => state.Name.Trim().Replace(" ", "").ToLower() == stateCode.Trim().Replace(" ", "").ToLower() ||
                                                                     state.AbbreivatedName.Trim().Replace(" ", "").ToLower() == stateCode.Trim().Replace(" ", "").ToLower())
                                                     .AsNoTracking()
                                                     .FirstOrDefaultAsync() ?? throw new NotFoundException(stateCode, nameof(State));

            var existingSuburbs = await _context.Suburbs.Where(s => s.Name.Replace(" ", "").ToLower() == suburb.Replace(" ", "").ToLower() &&
                                                                    s.Suburb_SuburbStateID == existingState.ID)
                                                        .AsNoTracking()
                                                        .Select(s => s.ID)
                                                        .ToListAsync() ?? throw new NotFoundException(suburb, nameof(Suburb));

            if (existingSuburbs is not null)
            {
                postcodeSuburbMapper = await _context.PostcodeSuburbMapper.Where(psm => psm.PostcodeSuburbMapper_PostcodeID == code.ID &&
                                                                                        psm.PostcodeSuburbMapper_SuburbID != null &&
                                                                                        existingSuburbs.Contains((int)psm.PostcodeSuburbMapper_SuburbID))
                                                                          .AsNoTracking()
                                                                          .FirstOrDefaultAsync() ?? throw new NotFoundException(suburb, nameof(Suburb));
            }
        }

        if (postcodeSuburbMapper is not null && postcodeSuburbMapper.ISIsLand)
        {
            productIds.AddRange([(int)ProductTypes.Optimax, (int)ProductTypes.Liberal]);
        }
        else
        {
            postcodeClassifications = await GetPostcodeClassifications(code);

            productIds = await GetValidProducts(postcodeClassifications);
        }

        return productIds;
    }

    #region Helpers

    private async Task<List<PostcodeClassification>> GetPostcodeClassifications(Postcode code)
    {
        List<PostcodeClassification> postcodeClassifications = [];

        var postcodeClassificationMapper = await _context.PostcodeClassificationMapper.Where(pcm => pcm.PostcodeClassificationMapper_PostcodeID == code.ID &&
                                                                                                    !pcm.ISDeleted)
                                                                                      .AsNoTracking()
                                                                                      .ToListAsync();

        foreach (var pcm in postcodeClassificationMapper)
        {
            var classificationMapper = await _context.PostcodeClassifications.Where(pc => pc.ID == pcm.PostcodeClassificationMapper_PostcodeClassificationID)
                .AsNoTracking()
                .FirstOrDefaultAsync() ?? throw new NotFoundException(pcm.ID.ToString(), nameof(PostcodeClassification));

            postcodeClassifications.Add(classificationMapper);
        }

        return postcodeClassifications;
    }

    private async Task<List<int?>> GetValidProducts(List<PostcodeClassification> postcodeClassifications)
    {
        List<int?> productIds = [];

        if (postcodeClassifications.Any())
        {
            var postcodeProductClassificationDto = GetPostcodeProductClassificationDto(postcodeClassifications);

            productIds.AddRange(await GetProductsWithClassifications(postcodeProductClassificationDto));
        }

        return productIds;
    }

    private static PostcodeProductClassificationDto GetPostcodeProductClassificationDto(List<PostcodeClassification> postcodeClassifications)
    {
        var postcodeProductClassificationDto = new PostcodeProductClassificationDto();

        foreach (var pc in postcodeClassifications)
        {
            if (pc.Name == PostcodeClassificationType.PCCategory.Value)
            {
                postcodeProductClassificationDto.PCCategory = pc.Value;
            }
            if (pc.Name == PostcodeClassificationType.StandardAndPoor.Value)
            {
                postcodeProductClassificationDto.StandardAndPoor = pc.Value;
            }
            if (pc.Name == PostcodeClassificationType.HighSecurity.Value)
            {
                postcodeProductClassificationDto.HighSecurity1 = string.IsNullOrWhiteSpace(postcodeProductClassificationDto.HighSecurity1) ? pc.Value : postcodeProductClassificationDto.HighSecurity1;

                postcodeProductClassificationDto.HighSecurity2 = (!string.IsNullOrWhiteSpace(postcodeProductClassificationDto.HighSecurity2) ? pc.Value : postcodeProductClassificationDto.HighSecurity2);
            }
        }

        return postcodeProductClassificationDto;
    }

    private async Task<List<int?>> GetProductsWithClassifications(PostcodeProductClassificationDto postcodeProductClassificationDto)
    {
        List<int?> productIds = [];

        var postcodeSpecificationMappers = from psm in _context.PostcodeSpecificationMapper
                                           join pc in _context.PostcodeClassifications on psm.PostcodeClassification_SAndPID equals pc.ID
                                           join pc1 in _context.PostcodeClassifications on psm.PostcodeClassification_HighSecurityID equals pc1.ID into pc1Group
                                           from pc1 in pc1Group.DefaultIfEmpty()
                                           join pc2 in _context.PostcodeClassifications on psm.PostcodeClassification_PCCategoryID equals pc2.ID
                                           where pc.Name == PostcodeClassificationType.StandardAndPoor.Value
                                                 && (pc1 == null || pc1.Name == PostcodeClassificationType.HighSecurity.Value)
                                                 && pc2.Name == PostcodeClassificationType.PCCategory.Value
                                                 && pc.Value.Replace(" ", "").ToLower() == postcodeProductClassificationDto.StandardAndPoor.Replace(" ", "").ToLower()
                                                 && pc2.Value.Replace(" ", "").ToLower() == postcodeProductClassificationDto.PCCategory.Replace(" ", "").ToLower()
                                           select new { Key = psm.ID, SandP = pc.Value, highSecurities = pc1 != null ? pc1.Value : null, PCCatgeory = pc2.Value };


        var postcodeSpecifications = await postcodeSpecificationMappers.ToListAsync();

        if (!string.IsNullOrWhiteSpace(postcodeProductClassificationDto.HighSecurity1))
        {
            if (!string.IsNullOrWhiteSpace(postcodeProductClassificationDto.HighSecurity2))
            {
                postcodeSpecifications = postcodeSpecifications.Where(ps =>
                                ps.highSecurities.Replace(" ", "").ToLower() == postcodeProductClassificationDto.HighSecurity1.Replace(" ", "").ToLower() ||
                                ps.highSecurities.Replace(" ", "").ToLower() == postcodeProductClassificationDto.HighSecurity2.Replace(" ", "").ToLower())
                           .ToList();
            }
            else
            {
                postcodeSpecifications = postcodeSpecifications.Where(ps => ps.highSecurities.Replace(" ", "").ToLower() == postcodeProductClassificationDto.HighSecurity1.Replace(" ", "").ToLower())
                                                               .ToList();
            }
        }
        else
        {
            postcodeSpecifications = postcodeSpecifications.Where(ps => ps.highSecurities == null)
                                                           .ToList();
        }
        foreach (var postcode in postcodeSpecifications)
        {
            var compareProductIds = await _context.PostcodeProductSelectors.Where(pcs => pcs.PostcodeProductSelector_PostcodeSpecificationMapperID == postcode.Key)
                                                                           .Select(pcs => pcs.PostcodeProductSelector_ProductID)
                                                                           .ToListAsync();

            if (!productIds.Any())
            {
                productIds.AddRange(compareProductIds);
            }
            else
            {
                productIds = ProductFilterUtility.GetCommonProducts(productIds, compareProductIds);
            }
        }

        return productIds;
    }

    #endregion

    #endregion
}
