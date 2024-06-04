using ProductMatrix.Application.Common.Interfaces.ProductCalculators;

namespace ProductMatrix.Infrastructure.Services.ProductCalculators;

public class ExpressFeeService : IExpressFeeService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly ICalculateRangeService _calculateRangeService;
    private readonly IGetDefaultSetting _getDefaultSetting;
    private readonly IGetDefaultFeeService _getDefaultFeeService;
    private readonly IEntityService _entityService;

    #endregion

    #region Ctor

    public ExpressFeeService(IApplicationDbContext context,
        ICalculateRangeService calculateRangeService,
        IGetDefaultSetting getDefaultSetting,
        IGetDefaultFeeService getDefaultFeeService,
        IEntityService entityService)
    {
        _context = context;
        _calculateRangeService = calculateRangeService;
        _getDefaultSetting = getDefaultSetting;
        _getDefaultFeeService = getDefaultFeeService;
        _entityService = entityService;
    }

    #endregion

    #region Methods

    public async Task<double> CalculateExpressFee(string formulaType, ProductFeeDto productFeeDto)
    {
        int? docTypeId = _entityService.GetByName<DocType>(productFeeDto.DocType).Result.ID;

        var baseLVR = await _getDefaultSetting.GetByProperty(SystemDefault.DefaultLVR.PropertyName);

        int baselvrId = await _calculateRangeService.GetLVR(baseLVR);

        var expressFee = await GetExpressFee(formulaType, baselvrId, productFeeDto);

        int lvrId = await _calculateRangeService.GetLVR(productFeeDto.Lvr) ?? 0;
        if (lvrId == baselvrId) { return await Task.FromResult(expressFee); }

        int count = baselvrId - lvrId;
        count = Math.Abs(count);

        var percent = await _context.ProductFeeLVRRates
                        .Where(bip => bip.ProductFeeLVRRate_ProductID == productFeeDto.ProductId &&
                                      bip.ProductFeeLVRRate_DocTypeID == docTypeId &&
                                      bip.FeeType.ToLower() == FeeType.ExpressFee.FeeName.Replace(" ", "").ToLower() &&
                                      (bip.LVRFrom < productFeeDto.Lvr && bip.LVRTo >= productFeeDto.Lvr))
                        .Select(bip => bip.RatePercentIncrementDecrement)
                        .FirstOrDefaultAsync();

        for (int i = 1; i <= count; i++)
        {
            double newValue = expressFee * percent / 100;
            expressFee = (Math.Ceiling(newValue / 5) * 5) - 0.05;
        }

        return expressFee;
    }

    #region Helpers

    private async Task<double> GetExpressFee(string formulaType, int lvrId, ProductFeeDto productFeeDto)
    {
        int? docTypeId = _entityService.GetByName<DocType>(productFeeDto.DocType).Result.ID;

        var defaultExpressFee = await _context.DefaultFees
                                          .Where(df => df.DefaultFee_ProductID == productFeeDto.ProductId &&
                                                 df.DefaultFee_DocTypeID == docTypeId &&
                                                 df.DefaultFee_LoanToValueRatioID == lvrId && 
                                                 df.ExpressFee != null)
                                          .Select(x => x.ExpressFee)
                                          .FirstOrDefaultAsync() ?? 0.00;

        var defaultFee = await _getDefaultFeeService.GetFee(FeeType.ExpressFee.FeeName, formulaType, docTypeId ?? 0);

        return (defaultExpressFee * defaultFee / 100);
    }

    #endregion

    #endregion
}
