namespace ProductMatrix.Application.Common.Models.ProductFilters;

public record ProductFilterDto
{
    [DefaultValue("")]
    public required string DocType { get; set; }

    public required double LoanAmount { get; set; }

    [DefaultValue("")]
    public required string UsageType { get; set; }

    public double? LVR { get; set; }

    [DefaultValue("")]
    public string? State { get; set; }

    [DefaultValue("")]
    public string? Postcode { get; set; }

    [DefaultValue("")]
    public string? Suburb { get; set; }

    [DefaultValue("")]
    public string? ResidencyType { get; set; }

    public int? Dwellings { get; set; }

    [DefaultValue("")]
    public string? BorrowingEntityType { get; set; }

    public int? LoanTermInYears { get; set; }

    [DefaultValue("")]
    public string? RepaymentType { get; set; }

    [DefaultValue("")]
    public string? RepaymentRateType { get; set; }

    public int? RepaymentTimeInYears { get; set; }

    public int? NaturalPersonAge { get; set; }

    [DefaultValue("")]
    public string? EmploymentStatusType { get; set; }

    public int? ExperienceOfWorkInMonths { get; set; }

    public int? SelfEmployedTimeInMonths { get; set; }

    [DefaultValue(false)]
    public bool? ISSameLineOfWork { get; set; }

    [DefaultValue("")]
    public string? EmployerType { get; set; }

    [DefaultValue("")]
    public string? CouncilZoiningCategory { get; set; }

    [DefaultValue("")]
    public string? Zone { get; set; }

    public List<string>? OtherIncomeType { get; set; }

    [DefaultValue("")]
    public string? PotentialImpactfulType { get; set; }

    public int? AgeCreditReport { get; set; }

    [DefaultValue("")]
    public string? BuilderType { get; set; }

    [DefaultValue("")]
    public string? ConstructionType { get; set; }

    [DefaultValue("")]
    public string? RenovationType { get; set; }

    [DefaultValue(false)]
    public bool ISGreenRated { get; set; }

    [DefaultValue("")]
    public string? CashOutType { get; set; }

    [DefaultValue("")]
    public string? BusinessFinanceType { get; set; }

    [DefaultValue("")]
    public required string CouncilZoningType { get; set; }

    public double? UnitApartmentSize { get; set; }

    [DefaultValue("")]
    public string? FacilityType { get; set; }

    [DefaultValue("")]
    public string? GuidedByType { get; set; }

    [DefaultValue("")]
    public string? HeedFullPointsType { get; set; }

    [DefaultValue("")]
    public string? SecurityType { get; set; }

    [DefaultValue("")]
    public string? TitleType { get; set; }

    [DefaultValue("")]
    public string? ServiceType { get; set; }

    [DefaultValue("")]
    public string? SecondaryUsageType { get; set; }

    public int? LandSize { get; set; }

    [DefaultValue("")]
    public string? EquityType { get; set; }
        
    [DefaultValue("")]
    public string? AwayBankType { get; set; }

    public int? ConsolidateLoan { get; set; }

    public ButtonTypeDto? ButtonTypeDto { get; set; }
}

public record ButtonTypeDto
{
    [DefaultValue("")]
    public string? OffThePlan { get; set; }

    [DefaultValue("")]
    public string? SellSoonAfter { get; set; }

    [DefaultValue("")]
    public string? InterStateProperty { get; set; }

    [DefaultValue("")]
    public string? GenuineSaving { get; set; }

    [DefaultValue("")]
    public string? PledgeLoan { get; set; }

    [DefaultValue("")]
    public string? GiftOf { get; set; }

    [DefaultValue("")]
    public string? VenderRebate { get; set; }

    [DefaultValue("")]
    public string? BuilderRebate { get; set; }

    [DefaultValue("")]
    public string? FHOG { get; set; }
}
