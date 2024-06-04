namespace ProductMatrix.Application.Common.Models.ProductFilters;

public class GuidedByTypeDto
{
    public int ID { get; set; }

    public required string GuidedByType { get; set; }

    public TextValuePair Product { get; set; } = new() { Value = "" };
}
