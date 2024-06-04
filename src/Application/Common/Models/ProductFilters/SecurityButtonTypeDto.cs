namespace ProductMatrix.Application.Common.Models.ProductFilters;

public class SecurityButtonTypeDto
{
    public int ID { get; set; }

    public required string ButtonType { get; set; }

    public TextValuePair Product { get; set; } = new() { Value = "" };
}
