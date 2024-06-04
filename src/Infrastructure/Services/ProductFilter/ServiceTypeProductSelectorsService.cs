namespace ProductMatrix.Infrastructure.Services.ProductFilter;

public class ServiceTypeProductSelectorsService : IServiceTypeProductSelectorsService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly IGeneralLookUpService _generalLookUpService;

    #endregion

    #region Ctor

    public ServiceTypeProductSelectorsService(
               IApplicationDbContext context,
               IGeneralLookUpService generalLookUpService)
    {
        _context = context;
        _generalLookUpService = generalLookUpService;
    }

    #endregion

    #region Methods

    public async Task<List<int?>> GetProducts(string serviceType, int councilZoningId)
    {
        var generalLookUpId = await _generalLookUpService.GetGeneralLookUpID(GeneralLookUps.ServiceType, serviceType);

        return await _context.ServiceTypeProductSelectors.Where(stps => stps.ServiceTypeProductSelector_GeneralLookUpID == generalLookUpId &&
                                                                        stps.ServiceTypeProductSelector_CouncilZoningTypeID == councilZoningId)
                                                         .Select(stps => stps.ServiceTypeProductSelector_ProductID)
                                                         .ToListAsync();
    }

    #endregion
}
