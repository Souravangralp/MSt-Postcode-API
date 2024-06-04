namespace ProductMatrix.Infrastructure.Services.ProductFilter;

public class PurchaseTypeProductSelectorService : IPurchaseTypeProductSelectorService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly IEntityService _entityService;

    #endregion

    #region Ctor

    public PurchaseTypeProductSelectorService(IApplicationDbContext context
        , IEntityService entityService)
    {
        _context = context;
        _entityService = entityService;
    }

    #endregion

    #region Methods

    public async Task<List<int?>> GetProducts(string docType, string occupancyType, double lvr, int councilZoningID)
    {
        int? docTypeId = _entityService.GetByName<DocType>(docType).Result.ID;

        var productIds = await _context.PurchaseTypeProductSelectors
                                                .Where(ptps => ptps.OccupancyType.ToLower().Replace(" ", "") == occupancyType.ToLower().Replace(" ", "") &&
                                                               ptps.PurchaseTypeProductSelector_DocTypeID == docTypeId &&
                                                               ptps.MinimumLVR <= lvr && 
                                                               ptps.MaximumLVR >= lvr &&
                                                               ptps.PurchaseTypeProductSelector_CouncilZoningTypeID == councilZoningID)
                                                .AsNoTracking()
                                                .Select(ptps => ptps.PurchaseTypeProductSelector_ProductID)
                                                .ToListAsync();

        return productIds;
    }

    #endregion
}
