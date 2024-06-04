namespace ProductMatrix.Infrastructure.Services.ProductFilter;

public class DwellingProductSelectorService : IDwellingProductSelectorService
{
    #region Fields

    private readonly IApplicationDbContext _context;

    #endregion

    #region Ctor

    public DwellingProductSelectorService(
        IApplicationDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Methods

    public async Task<List<int?>> GetProducts(string postcode, int dwellings)
    {
        var dwelling = dwellings;

        if (dwellings > 20) { dwelling = 100; }

        string pcCategory = await GetPostcodeClassifications(postcode);

        return await _context.DwellingsProductSelectors.Where(pps => pps.PCCategory.Replace(" ", "").ToLower() == pcCategory.Replace(" ", "").ToLower() &&
                                                                     pps.DwellingCount == dwelling)
                                                       .AsNoTracking()
                                                       .Select(pps => pps.DwellingsProductSelector_ProductID)
                                                       .ToListAsync();
    }

    #region Helpers

    private async Task<string> GetPostcodeClassifications(string postcode)
    {
        List<PostcodeClassification> postcodeClassifications = [];

        var code = await _context.Postcodes.Where(pc => pc.Code == postcode).FirstOrDefaultAsync() ?? throw new NotFoundException(postcode, nameof(Postcode));

        var postcodeClassificationMapper = await _context.PostcodeClassificationMapper.Where(pcm => pcm.PostcodeClassificationMapper_PostcodeID == code.ID)
                        .AsNoTracking()
                        .ToListAsync();

        foreach (var pcm in postcodeClassificationMapper)
        {
            var classificationMapper = await _context.PostcodeClassifications.Where(pc => pc.ID == pcm.PostcodeClassificationMapper_PostcodeClassificationID)
                .AsNoTracking()
                .FirstOrDefaultAsync() ?? throw new NotFoundException(nameof(PostcodeClassification), pcm.ID.ToString());

            postcodeClassifications.Add(classificationMapper);
        }

        return postcodeClassifications.Where(pc => pc.Name == PostcodeClassificationType.PCCategory.Value).Select(pc => pc.Value).FirstOrDefault() ?? "";
    }

    #endregion

    #endregion
}
