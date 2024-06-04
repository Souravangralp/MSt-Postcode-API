namespace ProductMatrix.Application.Common.Models.ProductFilters;

public class HeedFullPointTypeDto
{
    public int ID { get; set; }

    public required string HeedFullPointType { get; set; }

    public TextValuePair Product { get; set; } = new() { Value = "" };
}
