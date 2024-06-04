using AutoMapper;
using ProductMatrix.Application.Common.Interfaces.ProductCalculators;
using ProductMatrix.Application.Products.Queries.CalculateProductFee;

namespace ProductMatrix.Infrastructure.Services;

public class CalculatorService : ICalculatorService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IApplicationFeeService _applicationFeeService;
    private readonly IRiskFeeService _riskFeeService;
    private readonly ISettlementFeeService _settlementFeeService;
    private readonly IDischargeFeeService _dischargeFeeService;
    private readonly IDeedOfPriorityService _deedOfPriorityService;
    private readonly IExpressFeeService _expressFeeService;
    private readonly IEstablishmentFeeService _establishmentFeeService;
    private readonly IRateLoadingService _rateLoadingService;
    private readonly IEntityService _entityService;
    private readonly ICalculateRangeService _calculateRangeService;
    private readonly IAnnualFacilityFeeService _annualFacilityFeeService;

    #endregion

    #region Ctor

    public CalculatorService(
         IApplicationDbContext context,
         IMapper mapper,
         IApplicationFeeService applicationFeeService,
         IRiskFeeService riskFeeService,
         ISettlementFeeService settlementFeeService,
         IDischargeFeeService dischargeFeeService,
         IDeedOfPriorityService deedOfPriorityService,
         IExpressFeeService expressFeeService,
         IEstablishmentFeeService establishmentFeeService,
         IRateLoadingService rateLoadingService,
         IEntityService entityService,
         ICalculateRangeService calculateRangeService,
         IAnnualFacilityFeeService annualFacilityFeeService)
    {
        _context = context;
        _mapper = mapper;
        _applicationFeeService = applicationFeeService;
        _riskFeeService = riskFeeService;
        _settlementFeeService = settlementFeeService;
        _dischargeFeeService = dischargeFeeService;
        _deedOfPriorityService = deedOfPriorityService;
        _expressFeeService = expressFeeService;
        _establishmentFeeService = establishmentFeeService;
        _rateLoadingService = rateLoadingService;
        _entityService = entityService;
        _calculateRangeService = calculateRangeService;
        _annualFacilityFeeService = annualFacilityFeeService;
    }

    #endregion

    #region Methods

    public async Task<ProductFeeResult> CalculateProductFee(string formulaType, CalculateProductFee calculateProductFee)
    {
        var doctypId = await _entityService.GetByName<DocType>(calculateProductFee.DocType);

        var productFee = _mapper.Map<ProductFeeDto>(calculateProductFee);

        //productFee.DocTypeId = doctypId.ID;

        return await GetProductFee(formulaType, calculateProductFee.LoanAmount, productFee);
    }

    public async Task<List<ProductFeeResult>> GetSuggestedProductFees(string formulaType, ProductFeeDto productFeeDto)
    {
        List<ProductFeeResult> productFeeResults = [];

        if (productFeeDto.Lvr >= 20 && productFeeDto.Lvr <= 60) { productFeeDto.Lvr -= 10; }
        if (productFeeDto.Lvr >= 65 && productFeeDto.Lvr <= 110) { productFeeDto.Lvr -= 5; }

        productFeeResults.Add(await GetProductFee(formulaType, productFeeDto.LoanAmount, productFeeDto));

        if (productFeeDto.Lvr >= 20 && productFeeDto.Lvr <= 60) { productFeeDto.Lvr -= 10; }
        if (productFeeDto.Lvr >= 65 && productFeeDto.Lvr <= 110) { productFeeDto.Lvr -= 5; }

        productFeeResults.Add(await GetProductFee(formulaType, productFeeDto.LoanAmount, productFeeDto));

        return productFeeResults;
    }

    private async Task<ProductFeeResult> GetProductFee(string formulaType, double loanAmount, ProductFeeDto productFee, bool isSuggestion = false)
    {
        var riskPercent = await _riskFeeService.CalculateRiskPercent(formulaType, productFee);
        var establishmentPercent = await _establishmentFeeService.CalculateEstablishmentPercent(formulaType, productFee);

        var lvrId = await _calculateRangeService.GetLVR(productFee.Lvr);

        var lvr = await _entityService.Get<LoanToValueRatio>(lvrId ?? 0);

        double increaseSecurityAmount = 0.00;

        if (isSuggestion) { increaseSecurityAmount = Math.Round((loanAmount / productFee.Lvr), 2); }

        return new ProductFeeResult()
        {
            MaximumLVR = lvr.To,
            ApplicationFee = await _applicationFeeService.CalculateApplicationFee(formulaType, productFee),
            AnnualFacilityFee = await _annualFacilityFeeService.CalculateAnnualFacilityFee(formulaType, productFee),
            RiskPercent = riskPercent,
            RiskFee = await _riskFeeService.CalculateRiskFee(loanAmount, riskPercent),
            SettlementFee = await _settlementFeeService.CalculateSettlementFee(formulaType, productFee),
            DischargeFee = await _dischargeFeeService.CalculateDischargeFee(formulaType, productFee),
            DeedOfPriority = await _deedOfPriorityService.CalculateDeedOfPriority(formulaType, productFee),
            ExpressFee = await _expressFeeService.CalculateExpressFee(formulaType, productFee),
            EstablishmentPercent = establishmentPercent,
            EstablishmentFee = await _establishmentFeeService.CalculateEstablishmentFee(loanAmount, establishmentPercent),
            RateLoading = await _rateLoadingService.CalculateRateLoading(formulaType, productFee),
            LoanAmount = loanAmount,
            IsSuggestion = isSuggestion,
            IncreaseSecurityAmount = increaseSecurityAmount
        };
    }

    #endregion
}
