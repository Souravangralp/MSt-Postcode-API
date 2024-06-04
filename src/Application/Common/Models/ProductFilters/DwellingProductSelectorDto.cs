namespace ProductMatrix.Application.Common.Models.ProductFilters;

public class DwellingProductSelectorDto
{
    public int ID { get; set; }

    public required string PCCategory { get; set; }

    public required int DwellingCount { get; set; }

    public TextValuePair Product { get; set; } = new() { Value = "" };
}
