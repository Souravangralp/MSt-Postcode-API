using ProductMatrix.Domain.Constants;

namespace ProductMatrix.Application.ProductFilters.Commands.Update;

public record UpdateRuleCommand : IRequest<bool>
{
    public required int CouncilZoningTypeID { get; set; }

    public required int FilterID { get; set; }

    [DefaultValue("")]
    public required object Model { get; set; }
}

public class UpdateRuleHandler : IRequestHandler<UpdateRuleCommand, bool>
{
    #region Fields

    private readonly IFilterCrudService _filterCrudService;

    #endregion

    #region Ctor

    public UpdateRuleHandler(IFilterCrudService filterCrudService)
    {
        _filterCrudService = filterCrudService;
    }

    #endregion

    #region Methods

    public async Task<bool> Handle(UpdateRuleCommand request, CancellationToken cancellationToken)
    {
        return await _filterCrudService.PerformCrud(request, CrudOperation.Update.Operation);
    }

    #endregion
}
