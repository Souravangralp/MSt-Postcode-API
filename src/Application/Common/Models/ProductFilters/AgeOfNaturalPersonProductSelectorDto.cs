namespace ProductMatrix.Application.Common.Models.ProductFilters;

public class AgeOfNaturalPersonProductSelectorDto
{
    public int ID { get; set; }

    public int MinimumAge { get; set; }

    public int MaximumAge { get; set; }

    public TextValuePair Product { get; set; } = new TextValuePair() { Value = "" };
}
