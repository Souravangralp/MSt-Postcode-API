namespace ProductMatrix.Application.Common.Models.ProductFilters;

public class SecurityTypeDto
{
    public int ID { get; set; }

    public required string SecurityType { get; set; }

    public TextValuePair Product { get; set; } = new() { Value = "" };
}
