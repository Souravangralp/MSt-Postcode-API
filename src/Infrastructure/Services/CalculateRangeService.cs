namespace ProductMatrix.Infrastructure.Services;

public class CalculateRangeService : ICalculateRangeService
{
    #region Fields

    private readonly IApplicationDbContext _context;

    #endregion

    #region Ctor

    public CalculateRangeService(IApplicationDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Methods

    public async Task<int?> GetLVR(double value)
    {
        return await _context.LoanToValueRatios
            .Where(lvr => lvr.From <= value && lvr.To >= value)
            .Select(lvr => lvr.ID)
            .FirstOrDefaultAsync();
    }

    //public async Task<int?> GetDwelling(int count)
    //{
    //    return await _context.Dwellings
    //        .Where(dwl => dwl.Count == count)
    //        .Select(dwl => dwl.ID)
    //        .FirstOrDefaultAsync();
    //}

    #endregion
}
