using ProductMatrix.Application.Common.Interfaces.ProductCalculators;

namespace ProductMatrix.Infrastructure.Services.ProductCalculators;

public class GetDefaultFeeService : IGetDefaultFeeService
{
    #region Fields 

    private readonly IApplicationDbContext _context;

    #endregion

    #region Ctor

    public GetDefaultFeeService(IApplicationDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Methods

    public async Task<double> GetFee(string feeType, string formulaType, int docTypeId)
    {
        return await _context.AdditionalFeeDocTypeVariations
             .Where(af => af.FeeType.Replace(" ", "").ToLower() == feeType.Replace(" ", "").ToLower() &&
                    af.FormulaType.Replace(" ", "").ToLower() == formulaType.Replace(" ", "").ToLower() &&
                    af.AdditionalFeeDocTypeVariation_DocTypeID == docTypeId)
             .Select(af => af.Value)
             .FirstOrDefaultAsync();
    }

    #region Helpers

    #endregion

    #endregion
}
