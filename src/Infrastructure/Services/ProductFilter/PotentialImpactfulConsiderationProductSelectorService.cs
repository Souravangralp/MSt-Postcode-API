namespace ProductMatrix.Infrastructure.Services.ProductFilter;

public class PotentialImpactfulConsiderationProductSelectorService : IPotentialImpactfulConsiderationProductSelectorService
{

    #region Fields

    private readonly IApplicationDbContext _context;

    #endregion

    #region Ctor

    public PotentialImpactfulConsiderationProductSelectorService(
               IApplicationDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Methods

    public async Task<List<int?>> GetProducts(string potentialImpactfulType)
    {
        return await _context.PotentialImpactfulConsiderationProductSelectors
                                                    .Where(picps => picps.Type.Replace(" ","").ToLower() == potentialImpactfulType.Replace(" ", "").ToLower())
                                                    .Select(picps => picps.PotentialImpactfulConsiderationProductSelector_ProductID)
                                                    .ToListAsync();
    }

    #endregion
}
