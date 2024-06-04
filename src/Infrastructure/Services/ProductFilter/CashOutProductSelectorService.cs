namespace ProductMatrix.Infrastructure.Services.ProductFilter;

public class CashOutProductSelectorService : ICashOutProductSelectorService
{

    #region Fields

    private readonly IApplicationDbContext _context;

    #endregion

    #region Ctor

    public CashOutProductSelectorService(IApplicationDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Methods

    public async Task<List<int?>> GetProducts(string cashOutType, string businessFinanceType)
    {
        var cashOut = await _context.CashOutTypes.Where(ct => ct.Value.Replace(" ", "").ToLower() == cashOutType.Replace(" ", "").ToLower())
                                                 .AsNoTracking()
                                                 .FirstOrDefaultAsync() ?? throw new NotFoundException(cashOutType, nameof(CashOutType));

        var businessFinance = await _context.BusinessFinanceTypes.Where(ct => ct.Value.Replace(" ", "").ToLower() == businessFinanceType.Replace(" ", "").ToLower())
                                                                 .AsNoTracking()
                                                                 .FirstOrDefaultAsync() ?? throw new NotFoundException(businessFinanceType, nameof(BusinessFinanceType));

        return await _context.CashOutProductSelectors
                                    .Where(cps => cps.CashOutProductSelector_CashOutTypeID == cashOut.ID &&
                                                  cps.CashOutProductSelector_BusinessFinanceTypeID == businessFinance.ID)
                                    .AsNoTracking()
                                    .Select(cps => cps.CashOutProductSelector_ProductID)
                                    .ToListAsync();
    }

    #endregion
}
