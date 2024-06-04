namespace ProductMatrix.Infrastructure.Services.ProductFilter;

public class BorrowingEntityProductSelectorService : IBorrowingEntityProductSelectorService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly IEntityService _entityService;

    #endregion

    #region Ctor

    public BorrowingEntityProductSelectorService(
               IApplicationDbContext context,
               IEntityService entityService)
    {
        _context = context;
        _entityService = entityService;
    }

    #endregion

    #region Methods

    public async Task<List<int?>> GetProducts(string borrowingEntityType, int councilZoningID)
    {
        int borrowingEntityTypeID = _entityService.GetByName<BorrowingEntityType>(borrowingEntityType).Result.ID;

        return await _context.BorrowingEntityProductSelectors.Where(beps => beps.BorrowingEntityProductSelector_BorrowingEntityTypeID == borrowingEntityTypeID &&
                                                                            beps.BorrowingEntityProductSelector_CouncilZoningTypeID == councilZoningID)
                                                             .AsNoTracking()
                                                             .Select(beps => beps.BorrowingEntityProductSelector_ProductID)
                                                             .ToListAsync();
    }

    #endregion
}
