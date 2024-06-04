using ProductMatrix.Application.Common.Interfaces.ProductCalculators;

namespace ProductMatrix.Infrastructure.Services.ProductCalculators;

public class RiskFeeService : IRiskFeeService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly ICalculateRangeService _calculateRangeService;
    private readonly IGetDefaultSetting _getDefaultSetting;
    private readonly IGetDefaultFeeService _getDefaultFeeService;
    private readonly IEntityService _entityService;

    #endregion

    #region Ctor

    public RiskFeeService(IApplicationDbContext context,
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

    public async Task<double> CalculateRiskPercent(string formulaType, ProductFeeDto productFeeDto)
    {
        int? docTypeId = _entityService.GetByName<DocType>(productFeeDto.DocType).Result.ID;

        var baseLVR = await _getDefaultSetting.GetByProperty(SystemDefault.DefaultLVR.PropertyName) + 5; //base lvr for risk rate will be 85 need to get it from db.

        int baselvrId = await _calculateRangeService.GetLVR(baseLVR);

        double defaultRiskFee = await GetDefaultRiskPercent(formulaType, baselvrId, productFeeDto);

        int lvrId = await _calculateRangeService.GetLVR(productFeeDto.Lvr) ?? 0;

        if (lvrId == baselvrId) { return defaultRiskFee; }

        int count = baselvrId - lvrId;
        count = Math.Abs(count);

        var percent = await _context.ProductFeeLVRRates
                        .Where(bip => bip.ProductFeeLVRRate_ProductID == productFeeDto.ProductId &&
                                      bip.ProductFeeLVRRate_DocTypeID == docTypeId &&
                                      bip.FeeType.ToLower() == FeeType.RiskPercent.FeeName.Replace(" ", "").ToLower() &&
                                      (bip.LVRFrom < productFeeDto.Lvr && bip.LVRTo >= productFeeDto.Lvr))
                        .Select(bip => bip.RatePercentIncrementDecrement)
                        .FirstOrDefaultAsync();

        for (int i = 1; i <= count; i++)
        {
            defaultRiskFee = defaultRiskFee * percent / 100;
        }

        return CalculatorsUtility.CustomRound(defaultRiskFee, 2);
    }

    public async Task<double> CalculateRiskFee(double loanAmount, double riskFee)
    {
        return await Task.FromResult(Math.Ceiling((loanAmount * riskFee / 100) / 5) * 5);
    }

    #region Helpers

    private async Task<double> GetDefaultRiskPercent(string formulaType, int lvrId, ProductFeeDto productFeeDto)
    {
        int? docTypeId = _entityService.GetByName<DocType>(productFeeDto.DocType).Result.ID;

        var defaultRiskFee = await _context.DefaultFees
                                          .Where(df => df.DefaultFee_ProductID == productFeeDto.ProductId &&
                                                 df.DefaultFee_DocTypeID == docTypeId &&
                                                 df.DefaultFee_LoanToValueRatioID == lvrId &&
                                                 df.RiskFee != null)
                                          .Select(x => x.RiskFee)
                                          .FirstOrDefaultAsync() ?? 0.00;

        var defaultFee = await _getDefaultFeeService.GetFee(FeeType.RiskPercent.FeeName, formulaType, docTypeId ?? 0);

        return CalculatorsUtility.CustomRound(defaultRiskFee, 2);
    }   

    #endregion

    #endregion
}
