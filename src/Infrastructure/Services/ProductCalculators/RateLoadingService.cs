using ProductMatrix.Application.Common.Interfaces.ProductCalculators;

namespace ProductMatrix.Infrastructure.Services.ProductCalculators;

public class RateLoadingService : IRateLoadingService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly ICalculateRangeService _calculateRangeService;
    private readonly IGetDefaultSetting _getDefaultSetting;
    private readonly IGetDefaultFeeService _getDefaultFeeService;
    private readonly IEntityService _entityService;

    #endregion

    #region Ctor

    public RateLoadingService(IApplicationDbContext context,
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

    public async Task<double> CalculateRateLoading(string formulaType, ProductFeeDto productFeeDto)
    {
        int? docTypeId = _entityService.GetByName<DocType>(productFeeDto.DocType).Result.ID;

        var baseLVR = await _getDefaultSetting.GetByProperty(SystemDefault.DefaultLVR.PropertyName);

        int baselvrId = await _calculateRangeService.GetLVR(baseLVR);

        var rateLoading = await GetDefaultRateLoading(formulaType, baselvrId, productFeeDto);

        int lvrId = await _calculateRangeService.GetLVR(productFeeDto.Lvr) ?? 0;

        if (lvrId == baselvrId) { return await Task.FromResult(rateLoading); }

        int count = baselvrId - lvrId;
        count = Math.Abs(count);

        var percent = await _context.ProductFeeLVRRates
                        .Where(bip => bip.ProductFeeLVRRate_ProductID == productFeeDto.ProductId &&
                                      bip.ProductFeeLVRRate_DocTypeID == docTypeId &&
                                      bip.FeeType.ToLower() == FeeType.RateLoading.FeeName.Replace(" ", "").ToLower() &&
                                      (bip.LVRFrom < productFeeDto.Lvr && bip.LVRTo >= productFeeDto.Lvr))
                        .Select(bip => bip.RatePercentIncrementDecrement)
                        .FirstOrDefaultAsync();

        for (int i = 1; i <= count; i++)
        {
            double newValue = rateLoading * percent / 100;
            rateLoading = Math.Round(newValue, 2);
        }

        return rateLoading;
    }

    #region Helpers

    private async Task<double> GetDefaultRateLoading(string formulaType, int lvrId, ProductFeeDto productFeeDto)
    {
        int? docTypeId = _entityService.GetByName<DocType>(productFeeDto.DocType).Result.ID;

        var defaultRateLoading = await _context.DefaultFees
                                          .Where(df => df.DefaultFee_ProductID == productFeeDto.ProductId &&
                                                 df.DefaultFee_DocTypeID == docTypeId &&
                                                 df.DefaultFee_LoanToValueRatioID == lvrId &&
                                                 df.RateLoadingFee != null)
                                          .Select(x => x.RateLoadingFee)
                                          .FirstOrDefaultAsync() ?? 0.00;

        var defaultFee = await _getDefaultFeeService.GetFee(FeeType.RateLoading.FeeName, formulaType, docTypeId ?? 0);

        return Math.Round((defaultRateLoading *= defaultFee / 100), 2, MidpointRounding.AwayFromZero);
    }

    #endregion

    #endregion
}
