using ProductMatrix.Application.Common.Interfaces.ProductCalculators;

namespace ProductMatrix.Infrastructure.Services.ProductCalculators;

public class ApplicationFeeService : IApplicationFeeService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly ICalculateRangeService _calculateRangeService;
    private readonly IGetDefaultSetting _getDefaultSetting;
    private readonly IGetDefaultFeeService _getDefaultFeeService;
    private readonly IEntityService _entityService;

    #endregion

    #region Ctor

    public ApplicationFeeService(
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

    public async Task<double> CalculateApplicationFee(string formulaType, ProductFeeDto productFeeDto)
    {
        return await CalculateBaseApplicationFee(formulaType, productFeeDto);
    }

    #region Helpers

    private async Task<double> CalculateBaseApplicationFee(string formulaType, ProductFeeDto productFeeDto)
    {
        var calculatedValueBasedDwellings = await GetApplicationFeeBasedOnProduct(formulaType, productFeeDto);

        var landSizeID = await _context.LandSizes.Where(ls => ls.From < productFeeDto.LandSize && ls.To >= productFeeDto.LandSize).Select(ls => ls.ID).FirstOrDefaultAsync();

        int? docTypeId = _entityService.GetByName<DocType>(productFeeDto.DocType).Result.ID;

        var landSizeIncreaseRate = await _context.AdditionalFees.Where(aaf => aaf.AdditionalFee_LandSizeID == landSizeID &&
                                                                              aaf.AdditionalFee_DocTypeID == docTypeId)
                                                                .Select(aaf => aaf.IncrementFee)
                                                                .FirstOrDefaultAsync();

        var applicationFee = CalculatorsUtility.RoundToNearestMultipleOfFive((double)(calculatedValueBasedDwellings + landSizeIncreaseRate));

        applicationFee = await BaseApplicationFeeCalculator(productFeeDto, applicationFee);

        return await GetAdditionalApplicationFeeBasedOnLoanAmount(productFeeDto, applicationFee);
    }

    private async Task<double> GetApplicationFeeBasedOnProduct(string formulaType, ProductFeeDto productFeeDto)
    {
        var defaultLvr = await _getDefaultSetting.GetByProperty(SystemDefault.DefaultLVR.PropertyName);

        int lvrId = await _calculateRangeService.GetLVR(defaultLvr);

        int? docTypeId = _entityService.GetByName<DocType>(productFeeDto.DocType).Result.ID;

        var defaultValue = await _context.DefaultFees
                                        .Where(x => x.DefaultFee_ProductID == productFeeDto.ProductId &&
                                                    x.DefaultFee_LoanToValueRatioID == lvrId)
                                        .Select(x => x.ApplicationFee)
                                        .FirstOrDefaultAsync();

        var defaultDwelling = await _getDefaultSetting.GetByProperty(SystemDefault.DefaultDwelling.PropertyName);
        var dwellingRate = await _getDefaultSetting.GetByProperty(SystemDefault.DwellingRate.PropertyName);
        var defaultParticipant = await _getDefaultSetting.GetByProperty(SystemDefault.DefaultParticipant.PropertyName);
        var participatingRate = await _getDefaultSetting.GetByProperty(SystemDefault.ParticipatingRate.PropertyName);
        var defaultApplicationFee = await _getDefaultSetting.GetByProperty(SystemDefault.DefaultApplicationFee.PropertyName);

        var incrementAmounts = new Dictionary<int, double>
        {
            { 1, await _getDefaultSetting.GetByProperty(SystemDefault.UltraPrimeIncrementAmount.PropertyName) },
            { 3, await _getDefaultSetting.GetByProperty(SystemDefault.SuperPrimeIncrementAmount.PropertyName) },
            { 4, await _getDefaultSetting.GetByProperty(SystemDefault.PremiumIncrementAmount.PropertyName) },
            { 5, await _getDefaultSetting.GetByProperty(SystemDefault.OptimaxIncrementAmount.PropertyName) },
            { 6, await _getDefaultSetting.GetByProperty(SystemDefault.TolerantIncrementAmount.PropertyName) },
            { 7, await _getDefaultSetting.GetByProperty(SystemDefault.ProgressiveIncrementAmount.PropertyName) }
        };

        if (incrementAmounts.ContainsKey(productFeeDto.ProductId))
        {
            defaultApplicationFee = Convert.ToDouble(defaultApplicationFee + (productFeeDto.NumberOfDwellings - defaultDwelling) * dwellingRate + (productFeeDto.NumberOfParticipatingEntities - defaultParticipant) * participatingRate + incrementAmounts[productFeeDto.ProductId]);
        }
        else
        {
            return defaultValue ?? 0.00;
        }

        defaultApplicationFee += await _getDefaultFeeService.GetFee(FeeType.ApplicationFee.FeeName, formulaType, docTypeId ?? 0);

        return defaultApplicationFee;
    }

    private async Task<double> BaseApplicationFeeCalculator(ProductFeeDto productFeeDto, double applicationFee)
    {
        int lvrId = await _calculateRangeService.GetLVR(productFeeDto.Lvr) ?? 0;

        var defaultLvr = await _getDefaultSetting.GetByProperty(SystemDefault.DefaultLVR.PropertyName);

        int? docTypeId = _entityService.GetByName<DocType>(productFeeDto.DocType).Result.ID;

        int defaultLVRID = await _calculateRangeService.GetLVR(defaultLvr);

        if (lvrId == defaultLVRID) { return await Task.FromResult(applicationFee); }

        int count = defaultLVRID - lvrId;
        count = Math.Abs(count);

        if (count < 0) { return await Task.FromResult(applicationFee); }

        var percent = await _context.ProductFeeLVRRates.Where(pfLVRRate => pfLVRRate.FeeType == FeeType.ApplicationFee.FeeName &&
                                                                           pfLVRRate.ProductFeeLVRRate_ProductID == productFeeDto.ProductId &&
                                                                           pfLVRRate.ProductFeeLVRRate_DocTypeID == docTypeId &&
                                                                           pfLVRRate.LVRFrom < productFeeDto.Lvr && pfLVRRate.LVRTo >= productFeeDto.Lvr)
                                                       .Select(pfLVRRate => pfLVRRate.RatePercentIncrementDecrement)
                                                       .FirstOrDefaultAsync();

        for (int i = 1; i <= count; i++)
        {
            double newValue = applicationFee * percent / 100;
            newValue = Math.Ceiling(newValue / 5) * 5; // Round up to the next multiple of 5
            applicationFee = newValue;
        }

       return CalculatorsUtility.RoundToNearestMultipleOfFive(applicationFee);
    }

    private async Task<double> GetAdditionalApplicationFeeBasedOnLoanAmount(ProductFeeDto productFeeDto, double applicationFee)
    {
        var loanAmount = await _getDefaultSetting.GetByProperty(SystemDefault.DefaultLoanAmount.PropertyName);

        return productFeeDto.LoanAmount > loanAmount
                            ? CalculatorsUtility.RoundToNearestMultipleOfFive(applicationFee + (applicationFee * (await _getDefaultSetting.GetByProperty(SystemDefault.DefaultIncrementLoanPercent.PropertyName))))
                            : CalculatorsUtility.RoundToNearestMultipleOfFive(applicationFee);
    }

    #endregion

    #endregion
}
