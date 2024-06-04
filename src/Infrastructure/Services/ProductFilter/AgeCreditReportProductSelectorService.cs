namespace ProductMatrix.Infrastructure.Services.ProductFilter;

public class AgeCreditReportProductSelectorService : IAgeCreditReportProductSelectorService
{
    #region Fields

    private readonly IApplicationDbContext _context;

    #endregion

    #region Ctor

    public AgeCreditReportProductSelectorService(
               IApplicationDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Methods

    public async Task<List<int?>> GetProducts(int ageCreditReport)
    {
        return await _context.AgeCreditReportProductSelectors.Where(acrps => acrps.FromDays < ageCreditReport &&
                                                                             acrps.ToDays >= ageCreditReport)
                                                             .AsNoTracking()
                                                             .Select(acrps => acrps.AgeCreditReportProductSelector_ProductID)
                                                             .ToListAsync();
    }

    #endregion
}
