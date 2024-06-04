namespace ProductMatrix.Infrastructure.Services.ProductFilter;

public class LoanAmountProductSelectorService : ILoanAmountProductSelectorService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly IEntityService _entityService;

    #endregion

    #region Ctor

    public LoanAmountProductSelectorService(IApplicationDbContext context,
        IEntityService entityService)
    {
        _context = context;
        _entityService = entityService;
    }

    #endregion

    #region Methods

    public async Task<List<int?>> GetProducts(string loanType, string doctype, double loanAmount, int councilZoningID)
    {
        int? docTypeId = _entityService.GetByName<DocType>(doctype).Result.ID;

        return await _context.LoanAmountProductSelectors.Where(laps => laps.LoanAmountProductSelector_DocTypeID == docTypeId &&
                                                                       laps.LoanAmountProductSelector_CouncilZoningTypeID == councilZoningID &&
                                                                       (laps.LoanType != null && laps.LoanType.ToLower().Replace(" ", "") == loanType.ToLower().Replace(" ", "")))
                                                        .AsNoTracking()
                                                        .Select(laps => laps.LoanAmountProductSelector_ProductID)
                                                        .ToListAsync();
    }

    #endregion
}
