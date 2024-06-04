namespace ProductMatrix.Infrastructure.Services.ProductFilter;

public class GuidedByTypeProductSelectorService : IGuidedByTypeProductSelectorService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly IGeneralLookUpService _generalLookUpService;

    #endregion

    #region Ctor

    public GuidedByTypeProductSelectorService(
               IApplicationDbContext context,
               IGeneralLookUpService generalLookUpService)
    {
        _context = context;
        _generalLookUpService = generalLookUpService;
    }

    #endregion

    #region Methods

    public async Task<List<int?>> GetProducts(string guidedByType)
    {
        var generalLookUpId = await _generalLookUpService.GetGeneralLookUpID(GeneralLookUps.GuidedByType, guidedByType);

        return await _context.GuidedByTypeProductSelectors.Where(ftps => ftps.GuidedByTypeProductSelector_GeneralLookUpID == generalLookUpId)
                                                          .Select(ftps => ftps.GuidedByTypeProductSelector_ProductID)
                                                          .ToListAsync();
    }

    #endregion
}
