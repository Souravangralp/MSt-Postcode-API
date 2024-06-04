using ProductMatrix.Application.Common.Interfaces.ProductCalculators;

namespace ProductMatrix.Infrastructure.Services.ProductCalculators;

public class EstablishmentFeeService : IEstablishmentFeeService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly ICalculateRangeService _calculateRangeService;
    private readonly IGetDefaultSetting _getDefaultSetting;
    private readonly IGetDefaultFeeService _getDefaultFeeService;
    private readonly IEntityService _entityService;

    #endregion

    #region Ctor

    public EstablishmentFeeService(
        IApplicationDbContext context,
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

    public async Task<double> CalculateEstablishmentPercent(string formulaType, ProductFeeDto productFeeDto)
    {
        int? docTypeId = _entityService.GetByName<DocType>(productFeeDto.DocType).Result.ID;

        var defaultEstablishmentFee = await GetDefaultEstablishmentFee(formulaType, productFeeDto);

        var defaultLvr = await _getDefaultSetting.GetByProperty(SystemDefault.DefaultLVR.PropertyName);

        int defaultLvrId = await _calculateRangeService.GetLVR(defaultLvr);


        int lvrId = await _calculateRangeService.GetLVR(productFeeDto.Lvr) ?? 0;

        if (lvrId == defaultLvrId) { return await Task.FromResult(defaultEstablishmentFee); }

        int count = defaultLvrId - lvrId;
        count = Math.Abs(count);

        var percent = await _context.ProductFeeLVRRates.Where(pfLVRRate => pfLVRRate.FeeType == FeeType.EstablishmentPercent.FeeName &&
                                                                           pfLVRRate.ProductFeeLVRRate_ProductID == productFeeDto.ProductId &&
                                                                           pfLVRRate.ProductFeeLVRRate_DocTypeID == docTypeId &&
                                                                           pfLVRRate.LVRFrom < productFeeDto.Lvr && pfLVRRate.LVRTo >= productFeeDto.Lvr)
                                                      .Select(pfLVRRate => pfLVRRate.RatePercentIncrementDecrement)
                                                      .FirstOrDefaultAsync();

        for (int i = 1; i <= count; i++)
        {
            defaultEstablishmentFee = (defaultEstablishmentFee * percent) / 100;
        }

        return CalculatorsUtility.CustomRound(defaultEstablishmentFee, 2);
    }

    public async Task<double> CalculateEstablishmentFee(double loanAmount, double establishmentPercent)
    {
        return await Task.FromResult(Math.Ceiling((loanAmount * establishmentPercent / 100) / 5) * 5);
    }

    #region Helper

    private async Task<double> GetDefaultEstablishmentFee(string formulaType, ProductFeeDto productFeeDto)
    {
        int? docTypeId = _entityService.GetByName<DocType>(productFeeDto.DocType).Result.ID;


        var defaultEstablishmentFee = await _context.DefaultFees.Where(x => x.DefaultFee_DocTypeID == docTypeId &&
                                                                        x.DefaultFee_ProductID == productFeeDto.ProductId)
                                                            .Select(x => x.EstablishmentFee)
                                                            .FirstOrDefaultAsync();

        defaultEstablishmentFee *= (await _getDefaultFeeService.GetFee(FeeType.EstablishmentPercent.FeeName, formulaType, docTypeId ?? 0)/100);

        return await Task.FromResult(defaultEstablishmentFee ?? 0.0);
    }   

    #endregion

    #endregion
}
