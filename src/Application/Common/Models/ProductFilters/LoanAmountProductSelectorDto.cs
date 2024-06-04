namespace ProductMatrix.Application.Common.Models.ProductFilters;

public class LoanAmountProductSelectorDto
{
    public int ID { get; set; }

    public required string DocType { get; set; }

    public required string LoanType { get; set; }

    public TextValuePair Product { get; set; } = new TextValuePair() { Value = "" };
}
