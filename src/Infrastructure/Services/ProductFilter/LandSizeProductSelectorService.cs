namespace ProductMatrix.Infrastructure.Services.ProductFilter;

public class LandSizeProductSelectorService : ILandSizeProductSelectorService
{
    #region Fields

    private readonly IApplicationDbContext _context;

    #endregion

    #region Ctor

    public LandSizeProductSelectorService(
               IApplicationDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Methods

    public async Task<List<int?>> GetProducts(int landSize, int councilZoningId)
    {
        var landSizeClassification = await _context.LandSizeClassifications.Where(lsc => lsc.From < landSize &&
                                                                                  lsc.To >= landSize)
                                                                    .FirstOrDefaultAsync() ?? throw new NotFoundException(landSize.ToString(), nameof(LandSize));

        return await _context.LandSizeProductSelectors.Where(ftps => ftps.LandSizeProductSelector_LandSizeClassificationID == landSizeClassification.ID)
                                                          .Select(ftps => ftps.LandSizeProductSelector_ProductID)
                                                          .ToListAsync();
    }

    #endregion
}
