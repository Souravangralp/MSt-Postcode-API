namespace ProductMatrix.Application.Common.Models.ProductFilters;

public class LandSizeDto
{
    public int ID { get; set; }

    public double LandSizeFrom { get; set; }

    public double LandSizeTo { get; set; }

    public TextValuePair Product { get; set; } = new() { Value = "" };
}
