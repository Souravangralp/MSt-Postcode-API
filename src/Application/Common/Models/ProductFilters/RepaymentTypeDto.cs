namespace ProductMatrix.Application.Common.Models.ProductFilters;

public class RepaymentTypeDto
{
    public int? ID { get; set; }

    public required string RepaymentType { get; set;}

    public string? RateType { get; set; }

    public int TimeInYears { get; set; }

    public TextValuePair Product { get; set; } = new() { Value = "" };
}
