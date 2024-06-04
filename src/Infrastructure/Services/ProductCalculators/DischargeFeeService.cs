using ProductMatrix.Application.Common.Interfaces.ProductCalculators;

namespace ProductMatrix.Infrastructure.Services.ProductCalculators;

public class DischargeFeeService : IDischargeFeeService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly ICalculateRangeService _calculateRangeService;
    private readonly IGetDefaultSetting _getDefaultSetting;
    private readonly IGetDefaultFeeService _getDefaultFeeService;
    private readonly IEntityService _entityService;

    #endregion

    #region Ctor

    public DischargeFeeService(IApplicationDbContext context,
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

    public async Task<double> CalculateDischargeFee(string formulaType, ProductFeeDto productFeeDto)
    {
        int? docTypeId = _entityService.GetByName<DocType>(productFeeDto.DocType).Result.ID;

        var dischargeFee = await GetDefaultDischargeFee(formulaType, productFeeDto);

        var defaultLvr = await _getDefaultSetting.GetByProperty(SystemDefault.DefaultLVR.PropertyName);

        int defaultLvrId = await _calculateRangeService.GetLVR(defaultLvr);

        int lvrId = await _calculateRangeService.GetLVR(productFeeDto.Lvr) ?? 0;
        if (lvrId == defaultLvrId) { return await Task.FromResult(dischargeFee); }

        int count = defaultLvrId - lvrId;
        count = Math.Abs(count);

        var percent = await _context.ProductFeeLVRRates.Where(pfLVRRate => pfLVRRate.FeeType == FeeType.DischargeFee.FeeName &&
                                                                           pfLVRRate.ProductFeeLVRRate_ProductID == productFeeDto.ProductId &&
                                                                           pfLVRRate.ProductFeeLVRRate_DocTypeID == docTypeId &&
                                                                           pfLVRRate.LVRFrom < productFeeDto.Lvr && pfLVRRate.LVRTo >= productFeeDto.Lvr)
                                                      .Select(pfLVRRate => pfLVRRate.RatePercentIncrementDecrement)
                                                      .FirstOrDefaultAsync();

        for (int i = 1; i <= count; i++)
        {
            dischargeFee = Math.Ceiling((dischargeFee * percent / 100) / 5) * 5;
        }

        return dischargeFee;
    }

    #region Helpers

    private async Task<double> GetDefaultDischargeFee(string formulaType, ProductFeeDto productFeeDto)
    {
        int? docTypeId = _entityService.GetByName<DocType>(productFeeDto.DocType).Result.ID;

        var defaultDischargeFee = await _context.DefaultFees.Where(x => x.DefaultFee_DocTypeID == docTypeId &&
                                                                        x.DefaultFee_ProductID == productFeeDto.ProductId)
                                                            .Select(x => x.DischargeFee)
                                                            .FirstOrDefaultAsync();

        defaultDischargeFee += await _getDefaultFeeService.GetFee(FeeType.DischargeFee.FeeName, formulaType, docTypeId ?? 0);

        return await Task.FromResult(defaultDischargeFee ?? 0.0);
    }

    #endregion

    #endregion
}
