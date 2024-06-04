namespace ProductMatrix.Application.Common.Models.ProductFilters;

public class DocTypeProductSelectorDto
{
    public int ID { get; set; }

    public required string DocType { get; set; }

    public int MinimumLoanTermInYears { get; set; }

    public int MaximumLoanTermInYears { get; set; }

    public TextValuePair Product { get; set; } = new TextValuePair() { Value = "" };
}
