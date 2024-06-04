using ProductMatrix.Domain.Constants;

namespace ProductMatrix.Application.ProductFilters.Commands.Delete;

public record DeleteRuleCommand : IRequest<bool>
{
    public required int CouncilZoningTypeID { get; set; }

    public required int FilterID { get; set; }

    public required int RuleID { get; set; }
}

public class DeleteRuleCommandHandler : IRequestHandler<DeleteRuleCommand, bool>
{
    #region Fields

    private readonly IFilterCrudService _filterCrudService;
 
    #endregion

    #region Ctor

    public DeleteRuleCommandHandler(IFilterCrudService filterCrudService)
    {
        _filterCrudService = filterCrudService;
    }

    #endregion

    #region Methods

    public async Task<bool> Handle(DeleteRuleCommand request, CancellationToken cancellationToken)
    {
        return  await _filterCrudService.PerformCrud(request, CrudOperation.Delete.Operation);
    }

    #endregion
}
