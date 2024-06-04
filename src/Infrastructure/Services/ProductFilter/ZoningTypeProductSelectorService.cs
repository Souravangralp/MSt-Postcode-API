namespace ProductMatrix.Infrastructure.Services.ProductFilter;

public class ZoningTypeProductSelectorService : IZoningTypeProductSelectorService
{
    #region Fields

    private readonly IApplicationDbContext _context;

    #endregion

    #region Ctor

    public ZoningTypeProductSelectorService(IApplicationDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Methods

    public async Task<List<int?>> GetProducts(string councilZoningCategory, string zone, string state, int councilZoningTypeId)
    {
        var existingState = await _context.States.Where(s => s.Name.Replace(" ", "").ToLower() == state.Replace(" ", "").ToLower() ||
                                                       s.AbbreivatedName.Replace(" ", "").ToLower() == state.Replace(" ", "").ToLower())
                                                    .AsNoTracking()
                                                    .FirstOrDefaultAsync() ?? throw new NotFoundException(state, nameof(State));


        var existingCouncilZoningCategory = await _context.CouncilZoningCategories.Where(czc => czc.Name.Replace(" ", "").ToLower() == councilZoningCategory.Replace(" ", "").ToLower())
                                                    .AsNoTracking()
                                                    .FirstOrDefaultAsync() ?? throw new NotFoundException(councilZoningCategory, nameof(CouncilZoningCategory));

        return await _context.ZoningTypeProductSelectors.Where(ztps => ztps.ZoningTypeProductSelector_StateID == existingState.ID &&
                                                                             ztps.ZoningTypeProductSelector_CouncilZoningTypeID == councilZoningTypeId &&
                                                                             ztps.Zone.Replace(" ", "").ToLower() == zone.Replace(" ", "").ToLower() &&
                                                                             ztps.ZoningTypeProductSelector_CouncilZoningCategoryID == existingCouncilZoningCategory.ID)
                                                    .AsNoTracking()
                                                    .Select(x => x.ZoningTypeProductSelector_ProductID)
                                                    .ToListAsync();
    }

    #endregion
}
