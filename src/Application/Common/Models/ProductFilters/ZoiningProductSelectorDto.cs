namespace ProductMatrix.Application.Common.Models.ProductFilters;

public class ZoiningProductSelectorDto
{
    public int ID { get; set; }

    public required string State { get; set; }

    public required string Council { get; set; }

    public required string Zone { get; set; }

    public TextValuePair Product { get; set; } = new TextValuePair() { Value = "" };
}
