namespace ProductMatrix.Infrastructure.Services.ProductFilter;

public class EmployerClassificationProductSelectorService : IEmployerClassificationProductSelectorService
{
    #region Fields

    private readonly IApplicationDbContext _context;

    #endregion

    #region Ctor

    public EmployerClassificationProductSelectorService(IApplicationDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Methods

    public async Task<List<int?>> GetProducts(string employerType)
    {
        return await _context.EmployerClassificationProductSelectors
                                            .Where(ecps => ecps.EmployerClassificationType.ToLower().Replace(" ", "") == employerType.ToLower().Replace(" ", ""))
                                            .AsNoTracking()
                                            .Select(ecps => ecps.EmployerClassificationProductSelector_ProductID)
                                            .ToListAsync();
    }

    #endregion
}
