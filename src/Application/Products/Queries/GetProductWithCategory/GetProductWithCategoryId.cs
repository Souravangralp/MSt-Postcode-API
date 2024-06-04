namespace ProductMatrix.Application.Products.Queries.GetProductWithCategory;

public record GetProductWithCategoryId : IRequest<TextValuePair[]>
{
    //[Comment("Please dont remove this")]
    //public required ProductScenarioBuilder ProductScenarioBuilder { get; set; }

    [Comment("using this property to get product based on product category ID")]
    public required int ProductCategoryID { get; set; }

    [Comment("using this property to get product based on product category ID")]
    public required double LoanAmount { get; set; }
}

public class GetProductWithCategoryIdHandler : IRequestHandler<GetProductWithCategoryId, TextValuePair[]>
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly IProductSelectionService _productSelectionService;

    #endregion

    #region Ctor

    public GetProductWithCategoryIdHandler(
        IApplicationDbContext context,
        IProductSelectionService productSelectionService)
    {
        _context = context;
        _productSelectionService = productSelectionService;
    }

    #endregion

    #region Methods

    public async Task<TextValuePair[]> Handle(GetProductWithCategoryId request, CancellationToken cancellationToken)
    {
        #region Please dont remove this 

        //var query = await _productSelectionService.GetEligibleProducts(request.ProductScenarioBuilder);

        //return query;

        #endregion

        #region using this block of code for getting products based on loanAmount.

        var query = _context.Products.Where(product => product.Product_ProductCategoryID == request.ProductCategoryID);

        query = request.LoanAmount >= (int)LoanAmount.Maximum
            ? query.Where(x => x.RangeTo == (int)LoanAmount.Maximum)
            : query.Where(x => x.RangeFrom < request.LoanAmount && x.RangeTo >= request.LoanAmount);

        return await query
            .Select(y => new TextValuePair
            {
                Key = y.ID,
                Value = y.Name
            })
            .ToArrayAsync(cancellationToken);

        #endregion
    }

    #endregion
}
