namespace ProductMatrix.Infrastructure.Services.ProductFilter;

public class FacilityTypeProductSelectorService : IFacilityTypeProductSelectorService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly IGeneralLookUpService _generalLookUpService;

    #endregion

    #region Ctor

    public FacilityTypeProductSelectorService(
               IApplicationDbContext context,
               IGeneralLookUpService generalLookUpService)
    {
        _context = context;
        _generalLookUpService = generalLookUpService;
    }

    #endregion

    #region Methods

    public async Task<List<int?>> GetProducts(string facilityType)
    {
        var generalLookUpId = await _generalLookUpService.GetGeneralLookUpID(GeneralLookUps.FacilityType, facilityType);

        return await _context.FacilityTypeProductSelectors.Where(ftps => ftps.FacilityTypeProductSelector_GeneralLookUpID == generalLookUpId && !ftps.ISDeleted)
                                                          .Select(ftps => ftps.FacilityTypeProductSelector_ProductID)
                                                          .ToListAsync();
    }

    #endregion
}
