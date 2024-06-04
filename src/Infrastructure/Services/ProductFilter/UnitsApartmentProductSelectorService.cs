namespace ProductMatrix.Infrastructure.Services.ProductFilter;

public class UnitsApartmentProductSelectorService : IUnitsApartmentProductSelectorService
{
    #region Fields

    private readonly IApplicationDbContext _context;

    #endregion

    #region Ctor

    public UnitsApartmentProductSelectorService(
               IApplicationDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Methods

    public async Task<List<int?>> GetProducts(double livingAreaSize)
    {
        return await _context.UnitsApartmentProductSelectors.Where(uaps => uaps.LivingAreaFrom < livingAreaSize &&
                                                                           uaps.LivingAreaTo >= livingAreaSize)
                                                             .AsNoTracking()
                                                             .Select(uaps => uaps.UnitsApartmentProductSelector_ProductID)
                                                             .ToListAsync();
    }

    #endregion
}
