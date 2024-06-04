namespace ProductMatrix.Application.Common.Models.ProductFilters;

public class UsageTypeDto
{
    public int ID { get; set; }

    public required string UsageType { get; set; }

    public TextValuePair Product { get; set; } = new() { Value = "" };
}
