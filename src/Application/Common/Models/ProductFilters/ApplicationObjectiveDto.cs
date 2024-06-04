namespace ProductMatrix.Application.Common.Models.ProductFilters;

public class ApplicationObjectiveDto
{
    public int? ID { get; set; }

    public required string EquityType { get; set; }

    public required string UsageType { get; set; }

    public string? BankType { get; set; }

    public int? ConsolidateForm { get; set; }

    public int? ConsolidateTo { get; set; }

    public TextValuePair Product { get; set; } = new() { Value = "" };
}
