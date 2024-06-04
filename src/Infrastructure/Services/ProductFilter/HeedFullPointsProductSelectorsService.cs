namespace ProductMatrix.Infrastructure.Services.ProductFilter;

public class HeedFullPointsProductSelectorsService : IHeedFullPointsProductSelectorsService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly IGeneralLookUpService _generalLookUpService;

    #endregion

    #region Ctor

    public HeedFullPointsProductSelectorsService(
               IApplicationDbContext context,
               IGeneralLookUpService generalLookUpService)
    {
        _context = context;
        _generalLookUpService = generalLookUpService;
    }

    #endregion

    #region Methods

    public async Task<List<int?>> GetProducts(string heedfulPointsType)
    {
        var generalLookUpId = await _generalLookUpService.GetGeneralLookUpID(GeneralLookUps.HeedfulPointsType, heedfulPointsType);

        return await _context.HeedFullPointTypeProductSelectors.Where(hpps => hpps.HeedFullPointTypeProductSelector_GeneralLookUpID == generalLookUpId)
                                                               .Select(hpps => hpps.HeedFullPointTypeProductSelector_ProductID)
                                                               .ToListAsync();
    }

    #endregion
}
