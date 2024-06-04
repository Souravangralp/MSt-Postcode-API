namespace ProductMatrix.Infrastructure.Services.ProductFilter;

public class ButtonTypeProductSelectorService : IButtonTypeProductSelectorService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly IGeneralLookUpService _generalLookUpService;

    #endregion

    #region Ctor

    public ButtonTypeProductSelectorService(
               IApplicationDbContext context,
               IGeneralLookUpService generalLookUpService)
    {
        _context = context;
        _generalLookUpService = generalLookUpService;
    }

    #endregion

    #region Methods

    public async Task<List<int?>> GetProducts(string buttonValue, int councilZoningId)
    {
        var generalLookUpId = await _generalLookUpService.GetGeneralLookUpID(GeneralLookUps.ButtonType, buttonValue);

        return await _context.ButtonTypeProductSelectors.Where(utps => utps.ButtonTypeProductSelector_GeneralLookUpID == generalLookUpId &&
                                                                       utps.ButtonTypeProductSelector_CouncilZoningTypeID == councilZoningId)
                                                       .Select(utps => utps.ButtonTypeProductSelector_ProductID)
                                                       .ToListAsync();
    }

    #endregion
}
