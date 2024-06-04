namespace ProductMatrix.Application.Common.Models.ProductFilters;

public class ConstructionProductSelectorDto
{
    public int ID { get; set; }

    public int ConstructionTypeID { get; set; }

    public int BuilderTypeID { get; set; }

    public required string Rule { get; set; }

    public TextValuePair Product { get; set; } = new TextValuePair() { Value = "" };
}
