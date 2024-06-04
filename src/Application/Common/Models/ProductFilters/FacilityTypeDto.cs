namespace ProductMatrix.Application.Common.Models.ProductFilters;

public class FacilityTypeDto
{
    public int ID { get; set; }

    public required string FacilityType { get; set; }

    public TextValuePair Product { get; set; } = new() { Value = ""} ;
}
