namespace ProductMatrix.Application.Common.Models.ProductFilters;

public class ServiceTypeDto
{
    public int ID { get; set; }

    public required string ServiceType { get; set; }

    public TextValuePair Product { get; set; } = new() { Value = "" };
}
