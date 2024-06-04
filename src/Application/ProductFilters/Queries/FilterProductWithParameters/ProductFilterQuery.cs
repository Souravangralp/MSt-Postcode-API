namespace ProductMatrix.Application.ProductFilters.Queries.FilterProductWithParameters;

public class ProductFilterQuery : IRequest<TextValuePair[]>
{
    public required ProductFilterDto ProductFilterDto { get; set; }
}

public class ProductFilterQueryHandler : IRequestHandler<ProductFilterQuery, TextValuePair[]>
{
    #region Fields

    private readonly IPostcodeProductSelectorService _postcodeProductSelectorService;
    private readonly IProductFilterService _productFilterService;
    private readonly IDwellingProductSelectorService _dwellingProductSelectorService;
    private readonly IDocTypeProductSelectorService _docTypeProductSelectorService;
    private readonly IBorrowingEntityProductSelectorService _borrowingEntityProductSelectorService;
    private readonly ILoanAmountProductSelectorService _loanAmountProductSelector;
    private readonly ILvrProductSelectorService _lvrProductSelectorService;
    private readonly IRepaymentTypeProductSelectorService _repaymentTypeProductSelectorService;
    private readonly INaturalPersonAgeProductSelectorsService _naturalPersonAgeProductSelectorsService;
    private readonly INumeralClassificationService _numeralClassificationService;
    private readonly IPurchaseTypeProductSelectorService _purchaseTypeProductSelectorService;
    private readonly IEmploymentClassificationProductSelectorService _employmentClassificationProductSelectorService;
    private readonly ISelfEmployedClassificationProductSelectorService _selfEmployedClassificationProductSelectorService;
    private readonly IEmployerClassificationProductSelectorService _employerClassificationProductSelectorService;
    private readonly IZoningTypeProductSelectorService _zoiningTypeProductSelectorService;
    private readonly IOtherIncomeProductSelectorService _otherIncomeProductSelectorService;
    private readonly IPotentialImpactfulConsiderationProductSelectorService _potentialImpactfulConsiderationProductSelectorService;
    private readonly IAgeCreditReportProductSelectorService _ageCreditReportProductSelectorService;
    private readonly IConstructionProductSelectorService _constructionProductSelectorService;
    private readonly ICashOutProductSelectorService _cashOutProductSelectorService;
    private readonly IApplicationDbContext _context;
    private readonly IUnitsApartmentProductSelectorService _unitsApartmentProductSelectorService;
    private readonly IFacilityTypeProductSelectorService _facilityTypeProductSelectorService;
    private readonly IGuidedByTypeProductSelectorService _guidedByTypeProductSelectorService;
    private readonly IHeedFullPointsProductSelectorsService _heedFullPointsProductSelectorsService;
    private readonly ISecurityTypeProductSelectorService _securityTypeProductSelectorService;
    private readonly ITitleTypeProductSelectorService _titleTypeProductSelectorService;
    private readonly IServiceTypeProductSelectorsService _serviceTypeProductSelectorsService;
    private readonly IUsageTypeProductSelectorService _usageTypeProductSelectorService;
    private readonly ILandSizeProductSelectorService _landSizeProductSelectorService;
    private readonly IButtonTypeProductSelectorService _buttonTypeProductSelectorService;
    private readonly IApplicationObjectiveProductSelectorService _applicationObjectiveProductSelectorService;

    #endregion

    #region Ctor

    public ProductFilterQueryHandler(
        IPostcodeProductSelectorService postcodeProductSelectorService,
        IProductFilterService productFilterService,
        IDwellingProductSelectorService dwellingProductSelectorService,
        IDocTypeProductSelectorService docTypeProductSelectorService,
        IBorrowingEntityProductSelectorService borrowingEntityProductSelectorService,
        ILoanAmountProductSelectorService loanAmountProductSelector,
        ILvrProductSelectorService lvrProductSelectorService,
        ISecurityTypeProductSelectorService securityTypeProductSelectorService,
        IRepaymentTypeProductSelectorService repaymentTypeProductSelectorService,
        INaturalPersonAgeProductSelectorsService naturalPersonAgeProductSelectorsService,
        INumeralClassificationService numeralClassificationService,
        IPurchaseTypeProductSelectorService purchaseTypeProductSelectorService,
        IEmploymentClassificationProductSelectorService employmentClassificationProductSelectorService,
        ISelfEmployedClassificationProductSelectorService selfEmployedClassificationProductSelectorService,
        IEmployerClassificationProductSelectorService employerClassificationProductSelectorService,
        IZoningTypeProductSelectorService zoiningTypeProductSelectorService,
        IOtherIncomeProductSelectorService otherIncomeProductSelectorService,
        IPotentialImpactfulConsiderationProductSelectorService potentialImpactfulConsiderationProductSelectorService,
        IAgeCreditReportProductSelectorService ageCreditReportProductSelectorService,
        IConstructionProductSelectorService constructionProductSelectorService,
        ICashOutProductSelectorService cashOutProductSelectorService,
        IApplicationDbContext context,
        IUnitsApartmentProductSelectorService unitsApartmentProductSelectorService,
        IFacilityTypeProductSelectorService facilityTypeProductSelector,
        IGuidedByTypeProductSelectorService guidedByTypeProductSelectorService,
        IHeedFullPointsProductSelectorsService heedFullPointsProductSelectorsService,
        ITitleTypeProductSelectorService titleTypeProductSelectorService,
        IServiceTypeProductSelectorsService serviceTypeProductSelectorsService,
        IUsageTypeProductSelectorService usageTypeProductSelectorService,
        ILandSizeProductSelectorService landSizeProductSelectorService,
        IButtonTypeProductSelectorService buttonTypeProductSelectorService,
        IApplicationObjectiveProductSelectorService applicationObjectiveProductSelectorService)
    {
        _postcodeProductSelectorService = postcodeProductSelectorService;
        _productFilterService = productFilterService;
        _dwellingProductSelectorService = dwellingProductSelectorService;
        _docTypeProductSelectorService = docTypeProductSelectorService;
        _borrowingEntityProductSelectorService = borrowingEntityProductSelectorService;
        _loanAmountProductSelector = loanAmountProductSelector;
        _lvrProductSelectorService = lvrProductSelectorService;
        _repaymentTypeProductSelectorService = repaymentTypeProductSelectorService;
        _naturalPersonAgeProductSelectorsService = naturalPersonAgeProductSelectorsService;
        _numeralClassificationService = numeralClassificationService;
        _purchaseTypeProductSelectorService = purchaseTypeProductSelectorService;
        _employmentClassificationProductSelectorService = employmentClassificationProductSelectorService;
        _selfEmployedClassificationProductSelectorService = selfEmployedClassificationProductSelectorService;
        _employerClassificationProductSelectorService = employerClassificationProductSelectorService;
        _zoiningTypeProductSelectorService = zoiningTypeProductSelectorService;
        _otherIncomeProductSelectorService = otherIncomeProductSelectorService;
        _potentialImpactfulConsiderationProductSelectorService = potentialImpactfulConsiderationProductSelectorService;
        _ageCreditReportProductSelectorService = ageCreditReportProductSelectorService;
        _constructionProductSelectorService = constructionProductSelectorService;
        _cashOutProductSelectorService = cashOutProductSelectorService;
        _context = context;
        _unitsApartmentProductSelectorService = unitsApartmentProductSelectorService;
        _facilityTypeProductSelectorService = facilityTypeProductSelector;
        _guidedByTypeProductSelectorService = guidedByTypeProductSelectorService;
        _heedFullPointsProductSelectorsService = heedFullPointsProductSelectorsService;
        _securityTypeProductSelectorService = securityTypeProductSelectorService;
        _titleTypeProductSelectorService = titleTypeProductSelectorService;
        _serviceTypeProductSelectorsService = serviceTypeProductSelectorsService;
        _usageTypeProductSelectorService = usageTypeProductSelectorService;
        _landSizeProductSelectorService = landSizeProductSelectorService;
        _buttonTypeProductSelectorService = buttonTypeProductSelectorService;
        _applicationObjectiveProductSelectorService = applicationObjectiveProductSelectorService;
    }

    #endregion

    #region Methods

    public async Task<TextValuePair[]> Handle(ProductFilterQuery request, CancellationToken cancellationToken)
    {
        List<int?> productIds = await GetValidProducts(request.ProductFilterDto);
        string? numeral = string.Empty;

        var distinctProductIds = await _productFilterService.RemoveDuplicates(productIds);

        var products = await _productFilterService.GetEligibleProducts(distinctProductIds);

        numeral = await GetNumeralType(request.ProductFilterDto.LoanAmount, distinctProductIds);

        return GetProductsIDWithDefaultSelected(products, numeral);
    }

    #region Helpers

    private async Task<List<int?>> GetValidProducts(ProductFilterDto request)
    {
        List<int?> compareProductIds = [];
        List<int?> productIds = CommonUtility.GetDefaultProducts();

        var councilZoning = await _context.CouncilZoningCategories
                                                      .Where(czc => czc.Name.Replace(" ", "").ToLower() == request.CouncilZoningType.Replace(" ", "").ToLower())
                                                      .FirstOrDefaultAsync() ?? throw new NotFoundException(request.CouncilZoningType, nameof(CouncilZoningCategory));

        if (!string.IsNullOrWhiteSpace(request.Postcode))
        {
            compareProductIds = await _postcodeProductSelectorService.GetProducts(request.Postcode, request.State, request.Suburb);

            productIds = ProductFilterUtility.GetCommonProducts(productIds, compareProductIds);
        }
        if (request.Dwellings is not null && !string.IsNullOrWhiteSpace(request.Postcode))
        {
            compareProductIds = await _dwellingProductSelectorService.GetProducts(request.Postcode, (int)request.Dwellings);

            productIds = ProductFilterUtility.GetCommonProducts(productIds, compareProductIds);
        }
        if (!string.IsNullOrWhiteSpace(request.DocType) && request.LoanTermInYears.HasValue)
        {
            compareProductIds = await _docTypeProductSelectorService.GetProducts(request.DocType, (int)request.LoanTermInYears, councilZoning.ID);

            productIds = ProductFilterUtility.GetCommonProducts(productIds, compareProductIds);
        }
        if (!string.IsNullOrWhiteSpace(request.BorrowingEntityType))
        {
            compareProductIds = await _borrowingEntityProductSelectorService.GetProducts(request.BorrowingEntityType, councilZoning.ID);

            productIds = ProductFilterUtility.GetCommonProducts(productIds, compareProductIds);
        }
        if (request.LVR is not null && !string.IsNullOrWhiteSpace(request.ResidencyType))
        {
            compareProductIds = await _lvrProductSelectorService.GetProducts(request.ResidencyType, (double)request.LVR);

            productIds = ProductFilterUtility.GetCommonProducts(productIds, compareProductIds);
        }
        if (request.LoanAmount > 1 && !string.IsNullOrWhiteSpace(request.DocType) && !string.IsNullOrWhiteSpace(request.UsageType))
        {
            compareProductIds = await _loanAmountProductSelector.GetProducts(request.UsageType, request.DocType, (int)request.LoanAmount, councilZoning.ID);

            productIds = ProductFilterUtility.GetCommonProducts(productIds, compareProductIds);
        }
        if (!string.IsNullOrWhiteSpace(request.RepaymentType))
        {
            compareProductIds = await _repaymentTypeProductSelectorService.GetProducts(request.RepaymentType, request.RepaymentRateType, request.RepaymentTimeInYears, councilZoning.ID);

            productIds = ProductFilterUtility.GetCommonProducts(productIds, compareProductIds);
        }
        if (request.NaturalPersonAge is not null)
        {
            compareProductIds = await _naturalPersonAgeProductSelectorsService.GetProducts((int)request.NaturalPersonAge, councilZoning.ID);

            productIds = ProductFilterUtility.GetCommonProducts(productIds, compareProductIds);
        }
        if (request.LVR is not null)
        {
            compareProductIds = await _purchaseTypeProductSelectorService.GetProducts(request.DocType, request.UsageType, (double)request.LVR, councilZoning.ID);

            productIds = ProductFilterUtility.GetCommonProducts(productIds, compareProductIds);
        }
        if (!string.IsNullOrWhiteSpace(request.EmploymentStatusType) && request.ExperienceOfWorkInMonths is not null && request.ISSameLineOfWork is not null)
        {
            compareProductIds = await _employmentClassificationProductSelectorService.GetProducts(request.EmploymentStatusType, (int)request.ExperienceOfWorkInMonths, (bool)request.ISSameLineOfWork, councilZoning.ID);

            productIds = ProductFilterUtility.GetCommonProducts(productIds, compareProductIds);
        }
        if (request.SelfEmployedTimeInMonths is not null)
        {
            compareProductIds = await _selfEmployedClassificationProductSelectorService.GetProducts(request.DocType, (int)request.SelfEmployedTimeInMonths);

            productIds = ProductFilterUtility.GetCommonProducts(productIds, compareProductIds);
        }
        if (!string.IsNullOrWhiteSpace(request.EmployerType))
        {
            compareProductIds = await _employerClassificationProductSelectorService.GetProducts(request.EmployerType);

            productIds = ProductFilterUtility.GetCommonProducts(productIds, compareProductIds);
        }
        if (request.Zone is not null && !string.IsNullOrWhiteSpace(request.CouncilZoiningCategory) && !string.IsNullOrWhiteSpace(request.State))
        {
            compareProductIds = await _zoiningTypeProductSelectorService.GetProducts(request.CouncilZoiningCategory, request.Zone, request.State, councilZoning.ID);

            productIds = ProductFilterUtility.GetCommonProducts(productIds, compareProductIds);
        }
        if (request.OtherIncomeType is not null)
        {
            compareProductIds = await GetOtherIncomeTypeProduct(request.OtherIncomeType);

            productIds = ProductFilterUtility.GetCommonProducts(productIds, compareProductIds);
        }
        if (!string.IsNullOrWhiteSpace(request.PotentialImpactfulType))
        {
            compareProductIds = await _potentialImpactfulConsiderationProductSelectorService.GetProducts(request.PotentialImpactfulType);

            productIds = ProductFilterUtility.GetCommonProducts(productIds, compareProductIds);
        }
        if (request.AgeCreditReport is not null)
        {
            compareProductIds = await _ageCreditReportProductSelectorService.GetProducts((int)request.AgeCreditReport);

            productIds = ProductFilterUtility.GetCommonProducts(productIds, compareProductIds);
        }
        if (!string.IsNullOrWhiteSpace(request.ConstructionType) && !string.IsNullOrWhiteSpace(request.BuilderType))
        {
            Common.Models.ProductSelectors.ConstructionProductSelectorDto constructionProductSelectorDto = new()
            {
                BuilderType = request.BuilderType ?? "",
                ConstructionType = request.ConstructionType ?? "",
                ISGreenRated = request.ISGreenRated,
                CouncilZoiningID = councilZoning.ID,
                RenovationType = request.RenovationType,
            };

            compareProductIds = await _constructionProductSelectorService.GetProducts(constructionProductSelectorDto);

            productIds = ProductFilterUtility.GetCommonProducts(productIds, compareProductIds);
        }
        if (!string.IsNullOrWhiteSpace(request.CashOutType) && !string.IsNullOrWhiteSpace(request.BusinessFinanceType))
        {
            compareProductIds = await _cashOutProductSelectorService.GetProducts(request.CashOutType, request.BusinessFinanceType);

            productIds = ProductFilterUtility.GetCommonProducts(productIds, compareProductIds);
        }
        if (request.UnitApartmentSize is not null)
        {
            compareProductIds = await _unitsApartmentProductSelectorService.GetProducts((double)request.UnitApartmentSize);

            productIds = ProductFilterUtility.GetCommonProducts(productIds, compareProductIds);
        }
        if (!string.IsNullOrWhiteSpace(request.FacilityType))
        {
            compareProductIds = await _facilityTypeProductSelectorService.GetProducts(request.FacilityType);

            productIds = ProductFilterUtility.GetCommonProducts(productIds, compareProductIds);
        }
        if (!string.IsNullOrWhiteSpace(request.GuidedByType))
        {
            compareProductIds = await _guidedByTypeProductSelectorService.GetProducts(request.GuidedByType);

            productIds = ProductFilterUtility.GetCommonProducts(productIds, compareProductIds);
        }
        if (!string.IsNullOrWhiteSpace(request.HeedFullPointsType))
        {
            compareProductIds = await _heedFullPointsProductSelectorsService.GetProducts(request.HeedFullPointsType);

            productIds = ProductFilterUtility.GetCommonProducts(productIds, compareProductIds);
        }
        if (!string.IsNullOrWhiteSpace(request.SecurityType))
        {
            compareProductIds = await _securityTypeProductSelectorService.GetProducts(request.SecurityType, councilZoning.ID);

            productIds = ProductFilterUtility.GetCommonProducts(productIds, compareProductIds);
        }
        if (!string.IsNullOrWhiteSpace(request.TitleType))
        {
            compareProductIds = await _titleTypeProductSelectorService.GetProducts(request.TitleType, councilZoning.ID);

            productIds = ProductFilterUtility.GetCommonProducts(productIds, compareProductIds);
        }
        if (!string.IsNullOrWhiteSpace(request.ServiceType))
        {
            compareProductIds = await _serviceTypeProductSelectorsService.GetProducts(request.ServiceType, councilZoning.ID);

            productIds = ProductFilterUtility.GetCommonProducts(productIds, compareProductIds);
        }
        if (!string.IsNullOrWhiteSpace(request.SecondaryUsageType))
        {
            compareProductIds = await _usageTypeProductSelectorService.GetProducts(request.SecondaryUsageType, councilZoning.ID);

            productIds = ProductFilterUtility.GetCommonProducts(productIds, compareProductIds);
        }
        if (request.LandSize is not null)
        {
            compareProductIds = await _landSizeProductSelectorService.GetProducts((int)request.LandSize, councilZoning.ID);

            productIds = ProductFilterUtility.GetCommonProducts(productIds, compareProductIds);
        }
        if (request.ButtonTypeDto is not null)
        {
            compareProductIds = await GetProductButtonType(request.ButtonTypeDto);

            productIds = ProductFilterUtility.GetCommonProducts(productIds, compareProductIds);
        }
        if (!string.IsNullOrWhiteSpace(request.EquityType) && request.ConsolidateLoan is not null)
        {
            compareProductIds = await _applicationObjectiveProductSelectorService.GetProducts(request.EquityType, request.UsageType, request.AwayBankType, (int)request.ConsolidateLoan, councilZoning.ID);

            productIds = ProductFilterUtility.GetCommonProducts(productIds, compareProductIds);
        }

        return productIds;
    }

    private async Task<string?> GetNumeralType(double? loanAmount, List<int>? distinctProductIds)
    {
        string? numeral = string.Empty;

        if (distinctProductIds is not null && distinctProductIds.Contains((int)ProductTypes.LiberalHL))
        {
            return numeral;
        }

        if (loanAmount is not null)
        {
            numeral = await _numeralClassificationService.GetNumeralType((double)loanAmount);

            numeral = numeral is not null ? " " + numeral : string.Empty;
        }

        return numeral;
    }

    private static TextValuePair[] GetProductsIDWithDefaultSelected(TextValuePair[] products, string? numeral)
    {
        var textValuePairs = products
           .Select((product, index) => new TextValuePair()
           {
               Key = product.Key,
               Value = product.Value + numeral,
               ISDefault = index == products.Count() - 1
           })
           .ToArray();

        return textValuePairs;
    }

    private async Task<List<int?>> GetProductButtonType(ButtonTypeDto buttonTypeDto)
    {
        List<int?> productIds = [];
        List<int?> compareProductIds = [];

        var result = CommonUtility.GetPropertyValues(buttonTypeDto);

        foreach (var item in result)
        {
            compareProductIds = await _buttonTypeProductSelectorService.GetProducts(item, 8);

            if (!productIds.Any())
            {
                productIds.AddRange(compareProductIds);
            }
            else
            {
                productIds = ProductFilterUtility.GetCommonProducts(productIds, compareProductIds);
            }
        }

        return productIds;
    }

    private async Task<List<int?>> GetOtherIncomeTypeProduct(List<string> otherIncomes)
    {
        List<int?> productIds = [];

        foreach (var otherIncome in otherIncomes)
        {
            productIds.AddRange(await _otherIncomeProductSelectorService.GetProducts(otherIncome));
        }

        return productIds.Distinct().ToList();
    }


    #endregion

    #endregion
}
