namespace ProductMatrix.Application.Common.Models.ProductSelectors;

public record ProductSelectorRequestDto
{
    public required string Postcode { get; set; }

    public double? LoanAmount { get; set; }

    public double? LVR { get; set; }

    public string? LoanType { get; set; }

    public string? ResidencyType { get; set; }

    public int? Dwellings { get; set; }

    public string? BorrowingEntityType { get; set; }

    public string? DocType { get; set; }

    public int? LoanTermInYears { get; set; }

    //public List<string>? SecurityType { get; set; }

    public string? RepaymentType { get; set; }

    public string? RepaymentRateType { get; set; }

    public int? RepaymentTimeInYears { get; set; }

    public int? NaturalPersonAge { get; set; }
}
