using ProductMatrix.Application.Common.Interfaces.Numeral;

namespace ProductMatrix.Infrastructure.Services.Numeral;

public class NumeralClassificationService : INumeralClassificationService
{
    #region Fields

    private readonly IApplicationDbContext _context;

    #endregion

    #region Ctor

    public NumeralClassificationService(IApplicationDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Methods

    public async Task<string?> GetNumeralType(double loanAmount)
    {
        return await _context.NumeralClassifications.Where(nc => nc.LoanAmountFrom < loanAmount &&
                                                                 nc.LoanAmountTo >= loanAmount)
                                                    .AsNoTracking()
                                                    .Select(nc => nc.NumeralType)
                                                    .FirstOrDefaultAsync();
    }

    #region Helpers

    #endregion

    #endregion
}
