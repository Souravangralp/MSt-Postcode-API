namespace ProductMatrix.Infrastructure.Services.ProductFilter;

public class ProductFilterService : IProductFilterService
{
    #region Fields

    private readonly IApplicationDbContext _context;

    #endregion

    #region Ctor

    public ProductFilterService(
        IApplicationDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Methods

    public async Task<List<int>> RemoveDuplicates(List<int?> productIds)
    {
        var liberalHLProductId = await _context.Products.Where(product => product.Name.Replace(" ", "").ToLower() == ProductType.LiberalHL.ProductName.Replace(" ", "").ToLower())
                                               .Select(product => product.ID)
                                               .FirstOrDefaultAsync();

        if (productIds.Contains(liberalHLProductId)) { return [liberalHLProductId]; }

        var sortedList = productIds
            .Where(item => item != null)
            .GroupBy(item => item)
            .Select(g => g.Key ?? 0)
            .ToList();

        return await Task.FromResult(sortedList);
    }

    public async Task<TextValuePair[]> GetEligibleProducts(List<int> productIds)
    {
        var result = await _context.Products.Where(product => productIds.Contains(product.ID)) 
                .Select(product => new TextValuePair
                {
                    Key = product.ID,
                    Value = product.Name,
                })
                .AsNoTracking()
                .ToArrayAsync();

        return result;
    }

    #endregion
}
