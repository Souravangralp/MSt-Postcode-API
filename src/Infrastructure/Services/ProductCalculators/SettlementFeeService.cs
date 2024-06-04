using ProductMatrix.Application.Common.Interfaces.ProductCalculators;

namespace ProductMatrix.Infrastructure.Services.ProductCalculators;

public class SettlementFeeService : ISettlementFeeService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly ICalculateRangeService _calculateRangeService;
    private readonly IEntityService _entityService;
    private readonly IGetDefaultSetting _getDefaultSetting;
    private readonly IGetDefaultFeeService _getDefaultFeeService;

    #endregion

    #region Ctor

    public SettlementFeeService(IApplicationDbContext context,
        ICalculateRangeService calculateRangeService,
        IEntityService entityService,
        IGetDefaultSetting getDefaultSetting,
        IGetDefaultFeeService getDefaultFeeService
        )
    {
        _context = context;
        _calculateRangeService = calculateRangeService;
        _entityService = entityService;
        _getDefaultSetting = getDefaultSetting;
        _getDefaultFeeService = getDefaultFeeService;
    }

    #endregion

    #region Methods

    public async Task<double> CalculateSettlementFee(string formulaType, ProductFeeDto productFeeDto)
    {
        int? docTypeId = _entityService.GetByName<DocType>(productFeeDto.DocType).Result.ID;

        var baseLVR = await _getDefaultSetting.GetByProperty(SystemDefault.DefaultLVR.PropertyName);

        int baselvrId = await _calculateRangeService.GetLVR(baseLVR);

        var settlementFee = await GetDefaultSettlementFee(formulaType, baselvrId, productFeeDto);

        int lvrId = await _calculateRangeService.GetLVR(productFeeDto.Lvr) ?? 0;

        if (lvrId == baselvrId) { return await Task.FromResult(settlementFee); }

        int count = baselvrId - lvrId;
        count = Math.Abs(count);

        var percent = await _context.ProductFeeLVRRates
                        .Where(bip => bip.ProductFeeLVRRate_ProductID == productFeeDto.ProductId &&
                                      bip.ProductFeeLVRRate_DocTypeID == docTypeId &&
                                      bip.FeeType.ToLower() == FeeType.SettlementFee.FeeName.Replace(" ", "").ToLower() &&
                                      (bip.LVRFrom < productFeeDto.Lvr && bip.LVRTo >= productFeeDto.Lvr))
                        .Select(bip => bip.RatePercentIncrementDecrement)
                        .FirstOrDefaultAsync();

        for (int i = 1; i <= count; i++)
        {
            settlementFee = Math.Ceiling((settlementFee * percent / 100) / 5) *5;   
        }

        return settlementFee;
    }

    #region Helpers

    private async Task<double> GetDefaultSettlementFee(string formulaType, int lvrId, ProductFeeDto productFeeDto)
    {
        int? docTypeId = _entityService.GetByName<DocType>(productFeeDto.DocType).Result.ID;

        var baseSettlementFee = await _context.DefaultFees
                                          .Where(df => df.DefaultFee_ProductID == productFeeDto.ProductId &&
                                                 df.DefaultFee_DocTypeID == docTypeId &&
                                                 df.DefaultFee_LoanToValueRatioID == lvrId &&
                                                 df.SettlementFee != null)
                                          .Select(x => x.SettlementFee)
                                          .FirstOrDefaultAsync() ?? 0.00;

        var defaultFee = await _getDefaultFeeService.GetFee(FeeType.SettlementFee.FeeName, formulaType, docTypeId ?? 0);

        return baseSettlementFee += defaultFee;
    }

    #endregion

    #endregion
}
