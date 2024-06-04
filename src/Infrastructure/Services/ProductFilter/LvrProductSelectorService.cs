namespace ProductMatrix.Infrastructure.Services.ProductFilter;

public class LvrProductSelectorService : ILvrProductSelectorService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    
    #endregion

    #region Ctor

    public LvrProductSelectorService(IApplicationDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Methods

    public async Task<List<int?>> GetProducts(string residencyType, double lvr)
    {
        var productIDs = await _context.LvrProductSelectors.Where(lps=> lps.ResidencyType.ToLower().Replace(" ", "") == residencyType.ToLower().Replace(" ", "") &&
                                                                        lps.MaximumLVR >= lvr)
                                                           .AsNoTracking()
                                                           .Select(lps=> lps.LvrProductSelector_ProductID)
                                                           .ToListAsync();

        return productIDs;
    }

    #endregion
}
