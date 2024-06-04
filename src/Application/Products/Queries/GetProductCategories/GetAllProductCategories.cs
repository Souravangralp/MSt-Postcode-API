namespace ProductMatrix.Application.Products.Queries.GetProductCategories;

public record GetAllProductCategories : IRequest<TextValuePair[]>;

public class GetAllProductCategoriesHandler : IRequestHandler<GetAllProductCategories, TextValuePair[]>
{
    #region Fields

    private readonly IListService _listService;

    #endregion

    #region Ctor

    public GetAllProductCategoriesHandler(IListService listService)
    {
        _listService = listService;
    }

    #endregion

    #region Methods

    public async Task<TextValuePair[]> Handle(GetAllProductCategories request, CancellationToken cancellationToken)
    {
        return await _listService.GetAll<ProductCategory>();
    }

    #endregion
}
