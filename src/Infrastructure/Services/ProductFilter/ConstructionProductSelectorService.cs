using ProductMatrix.Domain;

namespace ProductMatrix.Infrastructure.Services.ProductFilter;

public class ConstructionProductSelectorService : IConstructionProductSelectorService
{
    #region Fields

    private readonly IApplicationDbContext _context;

    #endregion

    #region Ctor

    public ConstructionProductSelectorService(IApplicationDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Methods

    public async Task<List<int?>> GetProducts(Application.Common.Models.ProductSelectors.ConstructionProductSelectorDto constructionProductSelectorDto)
    {
        var construction = await _context.ConstructionTypes.Where(ct => ct.Value.Replace(" ", "").ToLower() == constructionProductSelectorDto.ConstructionType.Replace(" ", "").ToLower())
                .AsNoTracking()
                .FirstOrDefaultAsync() ?? throw new NotFoundException(constructionProductSelectorDto.ConstructionType, nameof(ConstructionType));

        var builder = await _context.BuilderTypes.Where(ct => ct.Value.Replace(" ", "").ToLower() == constructionProductSelectorDto.BuilderType.Replace(" ", "").ToLower())
                .AsNoTracking()
                .FirstOrDefaultAsync() ?? throw new NotFoundException(constructionProductSelectorDto.BuilderType, nameof(BuilderType));

        int? renovationID = string.IsNullOrWhiteSpace(constructionProductSelectorDto.RenovationType) ? null : await _context.RenovationTypes.Where(ct => ct.Value.Replace(" ", "").ToLower() == constructionProductSelectorDto.RenovationType.Replace(" ", "").ToLower())
                .AsNoTracking().Select(ct => ct.ID)
                .FirstOrDefaultAsync();

        return await _context.ConstructionProductSelectors.Where(cps => cps.ConstructionProductSelector_BuilderTypeID == builder.ID &&
                                                                        cps.ConstructionProductSelector_CouncilZoningTypeID == constructionProductSelectorDto.CouncilZoiningID &&
                                                                        cps.ConstructionProductSelector_RenovationTypeID == renovationID &&
                                                                        cps.ConstructionProductSelector_ConstructionTypeID == construction.ID)
            .AsNoTracking()
            .Select(cps => cps.ConstructionProductSelector_ProductID)
            .ToListAsync();
    }

    #endregion
}

