using ProductMatrix.Domain.Constants;

namespace ProductMatrix.Application.ProductFilters.Queries.GetRuleWithFilterID;

public record GetAllRulesWithFilterIDQuery : IRequest<ICollectionResult>
{
    public int CouncilZoiningID { get; set; }

    public int FilterID { get; set; }
}

public class GetAllRulesWithFilterIDQueryHandler : IRequestHandler<GetAllRulesWithFilterIDQuery, ICollectionResult>
{
    #region 

    private readonly IFilterCrudService _filterCrudService;

    #endregion

    #region Ctor

    public GetAllRulesWithFilterIDQueryHandler(IFilterCrudService filterCrudService)
    {
        _filterCrudService = filterCrudService;
    }

    #endregion

    #region Methods

    public async Task<ICollectionResult> Handle(GetAllRulesWithFilterIDQuery request, CancellationToken cancellationToken)
    {
        return await _filterCrudService.PerformCrud(request, CrudOperation.GetAll.Operation);
    }

    #endregion
}
