namespace ProductMatrix.Infrastructure.Services.ProductFilter;

public class RepaymentTypeProductSelectorService : IRepaymentTypeProductSelectorService
{
    #region Fields

    private readonly IApplicationDbContext _context;

    #endregion

    #region Ctor

    public RepaymentTypeProductSelectorService(
               IApplicationDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Methods

    public async Task<List<int?>> GetProducts(string repaymentType, string? rateType, int? timeInYears, int councilZoningID)
    {
        return await _context.RepaymentTypeProductSelectors.Where(rtps => rtps.RepaymentType.Replace(" ", "").ToLower() == repaymentType.Replace(" ", "").ToLower() &&
                                                                          (rateType != null && rtps.RateType.Replace(" ", "").ToLower() == rateType.Replace(" ","").ToLower()) &&
                                                                          (rtps.TimeInYears == timeInYears) &&
                                                                          rtps.RepaymentTypeProductSelector_CouncilZoningTypeID == councilZoningID)
                                                           .AsNoTracking()
                                                           .Select(rtps => rtps.RepaymentTypeProductSelector_ProductID)
                                                           .ToListAsync();
    }

    #endregion
}
