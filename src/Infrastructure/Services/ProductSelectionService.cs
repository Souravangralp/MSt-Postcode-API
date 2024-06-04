namespace ProductMatrix.Infrastructure.Services;

public class ProductSelectionService : IProductSelectionService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly ICalculateRangeService _calculateRangeService;

    #endregion

    #region Ctor

    public ProductSelectionService(IApplicationDbContext context,
        ICalculateRangeService calculateRangeService)
    {
        _context = context;
        _calculateRangeService = calculateRangeService;
    }

    #endregion

    #region Methods

    public async Task<TextValuePair[]> GetEligibleProducts(ProductScenarioBuilder productScenarioBuilder)
    {
        List<Product> products = [];

        var lvrId = await _calculateRangeService.GetLVR(productScenarioBuilder.LVR ?? 0.00) ?? null;

        //var dwellingId = await _calculateRangeService.GetDwelling(productScenarioBuilder.PostCodeScenarioDto.Dwellings ?? 0) ?? null;

        PropertyInfo[] properties = typeof(PostCodeScenarioDto).GetProperties();

        var dto = new PostCodeScenarioDto();

        foreach (var property in properties)
        {
            string name = property.Name;
            object? result = property.GetValue(dto) ?? throw new NotFoundException("", "");
            string? value = result.GetValue<string>() ?? "";

            var productCatalogueID = 1;

            //var productCatalogueID = await _context.PostCodeProductSelectors
            //                     .Where(pcps => pcps.PropertyName == name && 
            //                            pcps.FacilityType == value && 
            //                            pcps.PostCodeProductSelector_LoanToValueRatioID == lvrId &&
            //                            pcps.PostCodeProductSelector_DwellingID == dwellingId)
            //                     .Select(pcps => pcps.PostCodeProductSelector_ProductCatalogueID)
            //                     .FirstOrDefaultAsync();

            var productCatalogue = await _context.ProductCatalogues.Where(p => p.ID == productCatalogueID).FirstOrDefaultAsync();

            if (productCatalogue == null) { throw new NotFoundException("", ""); }

            products.AddRange(await GetProducts(productCatalogue));
        }

        return products.Select(p => new TextValuePair() 
        {
            Key = p.ID,
            Value = p.Name
        }).ToArray();
    }

    #region Helper Methods

    private async Task<List<Product>> GetProducts(ProductCatalogue productCatalogue)
    {
        return await GetProductWIthProductCatelogue(productCatalogue);
    }

    private async Task<List<Product>> GetProductWIthProductCatelogue(ProductCatalogue productCatalogue)
    {
        List<Product> products = [];

        if (productCatalogue.ISUltraPrimeI)
        {
            var result = await GetProduct(1);

            if (result != null) { products.Add(result); }
        }
        if (productCatalogue.ISUltraPrimeII)
        {
            var result = await GetProduct(2);

            if (result != null) { products.Add(result); }
        }
        if (productCatalogue.ISUltraPrimeIII)
        {
            var result = await GetProduct(3);

            if (result != null) { products.Add(result); }
        }

        return products;
    }

    private async Task<Product?> GetProduct(int productID)
    {
        return await _context.Products.Where(p => p.ID == productID).FirstOrDefaultAsync();
    }

    #endregion

    #endregion
}
