using ProductMatrix.Domain.Constants;

namespace ProductMatrix.Application.ProductFilters.Commands.Create;

public record CreateRuleCommand : IRequest<bool>
{
    public required int CouncilZoningTypeID { get; set; }

    public required int FilterID { get; set; }

    [DefaultValue("")]
    public required object Model { get; set; }
}

public class CreateRuleCommandHandler : IRequestHandler<CreateRuleCommand, bool>
{
    #region Fields

    private readonly IFilterCrudService _filterCrudService;

    #endregion

    #region Ctor

    public CreateRuleCommandHandler(IFilterCrudService filterCrudService)
    {
        _filterCrudService = filterCrudService;
    }

    #endregion

    #region Methods

    public async Task<bool> Handle(CreateRuleCommand request, CancellationToken cancellationToken)
    {
        return await _filterCrudService.PerformCrud(request, CrudOperation.Create.Operation);
    }

    #endregion
}
