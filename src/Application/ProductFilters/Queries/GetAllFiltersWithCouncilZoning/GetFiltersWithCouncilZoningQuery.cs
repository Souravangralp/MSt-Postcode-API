namespace ProductMatrix.Application.ProductFilters.Queries.GetAllFiltersWithCouncilZoning;

public record GetFiltersWithCouncilZoningQuery : IRequest<RulesFilterDto[]>
{
    public int CouncilZoningID { get; set; }
}

public record GetFiltersWithCouncilZoningQueryHandler : IRequestHandler<GetFiltersWithCouncilZoningQuery, RulesFilterDto[]>
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly IEntityService _entityService;

    #endregion

    #region Ctor

    public GetFiltersWithCouncilZoningQueryHandler(IApplicationDbContext context,
        IEntityService entityService)
    {
        _context = context;
        _entityService = entityService;
    }

    #endregion

    #region Methods

    public async Task<RulesFilterDto[]> Handle(GetFiltersWithCouncilZoningQuery request, CancellationToken cancellationToken)
    {
        var filters = await _context.RulesFilters.Where(pf => pf.RulesFilter_CouncilZoningTypeID == request.CouncilZoningID)
            .ToListAsync(cancellationToken);

        var parentFilters = filters.Where(x => x.ParentRuleFilterID == null).ToList();

        var childFilters = filters.Where(x => x.ParentRuleFilterID != null).ToList();

        return await GetFilterCollection(parentFilters, childFilters);
    }

    #region Helpers

    private async Task<RulesFilterDto[]> GetFilterCollection(List<RulesFilter> parentFilters, List<RulesFilter> childFilters)
    {
        List<RulesFilterDto> parentFilterCollection = [];

        foreach (var item in parentFilters)
        {
            List<RulesFilterDto> childFilterCollection = [];

            foreach (var childFilter in childFilters)
            {
                if (childFilter.ParentRuleFilterID == item.ID)
                {
                    childFilterCollection.Add(new RulesFilterDto()
                    {
                        ID = childFilter.ID,
                        FilterName = _entityService.Get<GeneralLookUp>(childFilter.FilterType_GeneralLookUpID ?? 0).Result.Value,
                        CouncilZoningID = childFilter.RulesFilter_CouncilZoningTypeID
                    });
                }
            }
            parentFilterCollection.Add(item != null ? new RulesFilterDto()
            {
                ID = item.ID,
                FilterName = _entityService.Get<GeneralLookUp>(item.FilterType_GeneralLookUpID ?? 0).Result.Value,
                CouncilZoningID = item.RulesFilter_CouncilZoningTypeID,
                SubFilters = childFilterCollection
            } : new() { });
        }

        return await Task.FromResult(parentFilterCollection.ToArray());
    }

    #endregion

    #endregion
}
