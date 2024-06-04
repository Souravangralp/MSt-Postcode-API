namespace ProductMatrix.Application.ProductFilters.Queries.GetAllCouncilZonings;

public record GetAllCouncilZoningsQuery : IRequest<TextValuePair[]>;

public class GetAllCouncilZoningsQueryHandler : IRequestHandler<GetAllCouncilZoningsQuery, TextValuePair[]>
{
    #region Fileds

    private readonly IApplicationDbContext _context;

    #endregion

    #region Ctor

    public GetAllCouncilZoningsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    #endregion

    public async Task<TextValuePair[]> Handle(GetAllCouncilZoningsQuery request, CancellationToken cancellationToken)
    {
        var list = await _context.CouncilZoningCategories.Where(czc => czc.Name.Replace(" ", "").Trim() == "Commercial".Replace(" ", "").Trim() ||
                                                                czc.Name.Replace(" ", "").Trim() == "SMSF Residential".Replace(" ", "").Trim() ||
                                                                czc.Name.Replace(" ", "").Trim() == "Residential".Replace(" ", "").Trim())
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return list.Select(l => new TextValuePair()
        {
            Value = l.Name,
            Key = l.ID
        }).ToArray();
    }
}
