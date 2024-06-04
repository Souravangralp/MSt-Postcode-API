namespace ProductMatrix.Infrastructure.Services.ProductFilter;

public class SecurityTypeProductSelectorService : ISecurityTypeProductSelectorService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly IGeneralLookUpService _generalLookUpService;

    #endregion

    #region Ctor

    public SecurityTypeProductSelectorService(
               IApplicationDbContext context,
               IGeneralLookUpService generalLookUpService)
    {
        _context = context;
        _generalLookUpService = generalLookUpService;
    }

    #endregion

    #region Methods

    public async Task<List<int?>> GetProducts(string securityType, int councilZoningId)
    {
        var generalLookUpId = await _generalLookUpService.GetGeneralLookUpID(GeneralLookUps.SecurityType, securityType);

        return await _context.SecurityTypeProductSelectors.Where(stps => stps.SecurityTypeProductSelector_GeneralLookUpID == generalLookUpId &&
                                                                         stps.SecurityTypeProductSelector_CouncilZoningTypeID == councilZoningId)
                                                          .Select(stps => stps.SecurityTypeProductSelector_ProductID)
                                                          .ToListAsync();
    }

    #endregion
}
