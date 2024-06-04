namespace ProductMatrix.Infrastructure.Services.ProductFilter;

public class TitleTypeProductSelectorService : ITitleTypeProductSelectorService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly IGeneralLookUpService _generalLookUpService;

    #endregion

    #region Ctor

    public TitleTypeProductSelectorService(
               IApplicationDbContext context,
               IGeneralLookUpService generalLookUpService)
    {
        _context = context;
        _generalLookUpService = generalLookUpService;
    }

    #endregion

    #region Methods

    public async Task<List<int?>> GetProducts(string titleType, int councilZoningId)
    {
        var generalLookUpId = await _generalLookUpService.GetGeneralLookUpID(GeneralLookUps.TitleType, titleType);

        return await _context.TitleTypeProductSelectors.Where(ttps => ttps.TitleTypeProductSelector_GeneralLookUpID == generalLookUpId &&
                                                                      ttps.TitleTypeProductSelector_CouncilZoningTypeID == councilZoningId)
                                                          .Select(ttps => ttps.TitleTypeProductSelector_ProductID)
                                                          .ToListAsync();
    }

    #endregion
}
