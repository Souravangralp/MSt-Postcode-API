namespace ProductMatrix.Application.Products.Queries.GetProductWithPostcode;

public record GetProductWithPostcode : IRequest<TextValuePair[]>
{
    public required string DocType { get; set; }

    public required double LoanAmount { get; set; }

    public required string UsageType { get; set; }

    public double? LVR { get; set; }

    public string? State { get; set; }

    public string? Postcode { get; set; }

    public string? Suburb { get; set; }

    public string? ResidencyType { get; set; }

    public int? Dwellings { get; set; }

    public string? BorrowingEntityType { get; set; }

    public int? LoanTermInYears { get; set; }

    public string? RepaymentType { get; set; }

    public string? RepaymentRateType { get; set; }

    public int? RepaymentTimeInYears { get; set; }

    public int? NaturalPersonAge { get; set; }

    //==public SecurityTypeDto? securityTypeDto { get; set; }

    public string? EmploymentStatusType { get; set; }

    public int? ExperienceOfWorkInMonths { get; set; }

    public int? SelfEmployedTimeInMonths { get; set; }

    public bool? ISSameLineOfWork { get; set; }

    public string? EmployerType { get; set; }

    public string? CouncilZoiningCategory { get; set; }

    public string? Zone { get; set; }

    public string? OtherIncomeType { get; set; }

    public string? PotentialImpactfulType { get; set; }

    public int? AgeCreditReport { get; set; }

    public string? BuilderType { get; set; }

    public string? ConstructionType { get; set; }

    public string? RenovationType { get; set; }

    public bool ISGreenRated { get; set; }

    public string? CashOutType { get; set; }

    public string? BusinessFinanceType { get; set; }

    public required string CouncilZoningType { get; set; }

    public double? UnitApartmentSize { get; set; }

    public string? FacilityType { get; set; }

    public string? GuidedByType { get; set; }

    public string? HeedFullPointsType { get; set; }
}

public class GetProductWithPostcodeHandler : IRequestHandler<GetProductWithPostcode, TextValuePair[]>
{
    #region Fields

    private readonly IPostcodeProductSelectorService _postcodeProductSelectorService;
    private readonly IProductFilterService _productFilterService;
    private readonly IDwellingProductSelectorService _dwellingProductSelectorService;
    private readonly IDocTypeProductSelectorService _docTypeProductSelectorService;
    private readonly IBorrowingEntityProductSelectorService _borrowingEntityProductSelectorService;
    private readonly ILoanAmountProductSelectorService _loanAmountProductSelector;
    private readonly ILvrProductSelectorService _lvrProductSelectorService;
    private readonly ISecurityTypeProductSelectorService _securityTypeProductSelectorService;
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

    #endregion

    #region Ctor

    public GetProductWithPostcodeHandler(
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
        IHeedFullPointsProductSelectorsService heedFullPointsProductSelectorsService)
    {
        _postcodeProductSelectorService = postcodeProductSelectorService;
        _productFilterService = productFilterService;
        _dwellingProductSelectorService = dwellingProductSelectorService;
        _docTypeProductSelectorService = docTypeProductSelectorService;
        _borrowingEntityProductSelectorService = borrowingEntityProductSelectorService;
        _loanAmountProductSelector = loanAmountProductSelector;
        _lvrProductSelectorService = lvrProductSelectorService;
        _securityTypeProductSelectorService = securityTypeProductSelectorService;
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
    }

    #endregion

    #region Methods

    public async Task<TextValuePair[]> Handle(GetProductWithPostcode request, CancellationToken cancellationToken)
    {
        List<int?> productIds = await GetValidProducts(request);
        string? numeral = string.Empty;

        var distinctProductIds = await _productFilterService.RemoveDuplicates(productIds);

        var products = await _productFilterService.GetEligibleProducts(distinctProductIds);

        numeral = await GetNumeralType(request.LoanAmount, distinctProductIds);

        return GetProductsIDWithDefaultSelected(products, numeral);
    }

    #region Helpers

    // we have to change this on the basics of good borrower and specialist
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

    private async Task<List<int?>> GetValidProducts(GetProductWithPostcode request)
    {
        List<int?> compareProductIds = [];
        List<int?> productIds = CommonUtility.GetDefaultProducts();


        var councilZoning = await _context.CouncilZoningCategories
                                                      .Where(czc => czc.Name.Replace(" ", "").ToLower() == request.CouncilZoningType.Replace(" ", "").ToLower())
                                                      .FirstOrDefaultAsync() ?? throw new NotFoundException(request.CouncilZoningType, nameof(CouncilZoningCategory));

        if (request.Postcode is not null)
        {
            compareProductIds = await _postcodeProductSelectorService.GetProducts(request.Postcode, request.State, request.Suburb);

            productIds = ProductFilterUtility.GetCommonProducts(productIds, compareProductIds);
        }
        if (request.Dwellings is not null && request.Postcode is not null)
        {
            compareProductIds = await _dwellingProductSelectorService.GetProducts(request.Postcode, (int)request.Dwellings);

            productIds = ProductFilterUtility.GetCommonProducts(productIds, compareProductIds);
        }
        if (!string.IsNullOrWhiteSpace(request.DocType) && request.LoanTermInYears.HasValue)
        {
            compareProductIds = await _docTypeProductSelectorService.GetProducts(request.DocType, (int)request.LoanTermInYears, councilZoning.ID);

            productIds = ProductFilterUtility.GetCommonProducts(productIds, compareProductIds);
        }
        if (request.BorrowingEntityType is not null)
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
        //if (request.securityTypeDto is not null)
        //{
        //    compareProductIds = await _securityTypeProductSelectorService.GetProducts(request.securityTypeDto);

        //    productIds = ProductFilterUtility.GetCommonProducts(productIds, compareProductIds);
        //}
        if (request.LVR is not null)
        {
            compareProductIds = await _purchaseTypeProductSelectorService.GetProducts(request.DocType, request.UsageType, (double)request.LVR, councilZoning.ID);

            productIds = ProductFilterUtility.GetCommonProducts(productIds, compareProductIds);
        }
        if (request.EmploymentStatusType is not null && request.ExperienceOfWorkInMonths is not null && request.ISSameLineOfWork is not null)
        {
            compareProductIds = await _employmentClassificationProductSelectorService.GetProducts(request.EmploymentStatusType, (int)request.ExperienceOfWorkInMonths, (bool)request.ISSameLineOfWork, councilZoning.ID);

            productIds = ProductFilterUtility.GetCommonProducts(productIds, compareProductIds);
        }
        if (request.SelfEmployedTimeInMonths is not null)
        {
            compareProductIds = await _selfEmployedClassificationProductSelectorService.GetProducts(request.DocType, (int)request.SelfEmployedTimeInMonths);

            productIds = ProductFilterUtility.GetCommonProducts(productIds, compareProductIds);
        }
        if (request.EmployerType is not null)
        {
            compareProductIds = await _employerClassificationProductSelectorService.GetProducts(request.EmployerType);

            productIds = ProductFilterUtility.GetCommonProducts(productIds, compareProductIds);
        }
        if (request.Zone is not null && request.CouncilZoiningCategory is not null && request.State is not null)
        {
            compareProductIds = await _zoiningTypeProductSelectorService.GetProducts(request.CouncilZoiningCategory, request.Zone, request.State, councilZoning.ID);

            productIds = ProductFilterUtility.GetCommonProducts(productIds, compareProductIds);
        }
        if (request.OtherIncomeType is not null)
        {
            compareProductIds = await _otherIncomeProductSelectorService.GetProducts(request.OtherIncomeType);

            productIds = ProductFilterUtility.GetCommonProducts(productIds, compareProductIds);
        }
        if (request.PotentialImpactfulType is not null)
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
            ProductMatrix.Application.Common.Models.ProductSelectors.ConstructionProductSelectorDto constructionProductSelectorDto = new()
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
        if (request.CashOutType is not null && request.BusinessFinanceType is not null)
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

    #endregion

    #endregion
}
