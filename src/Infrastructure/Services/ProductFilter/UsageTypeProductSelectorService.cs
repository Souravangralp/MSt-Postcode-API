namespace ProductMatrix.Infrastructure.Services.ProductFilter;

public class UsageTypeProductSelectorService : IUsageTypeProductSelectorService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly IGeneralLookUpService _generalLookUpService;

    #endregion

    #region Ctor

    public UsageTypeProductSelectorService(
               IApplicationDbContext context,
               IGeneralLookUpService generalLookUpService)
    {
        _context = context;
        _generalLookUpService = generalLookUpService;
    }

    #endregion

    #region Methods

    public async Task<List<int?>> GetProducts(string secondaryUsageType, int councilZoningId)
    {
        var generalLookUpId = await _generalLookUpService.GetGeneralLookUpID(GeneralLookUps.SecondaryUsageType, secondaryUsageType);

        return await _context.UsageTypeProductSelectors.Where(utps => utps.UsageTypeProductSelector_GeneralLookUpID == generalLookUpId &&
                                                                      utps.UsageTypeProductSelector_CouncilZoningTypeID == councilZoningId)
                                                       .Select(utps => utps.UsageTypeProductSelector_ProductID)
                                                       .ToListAsync();
    }

    #endregion
}
