namespace ProductMatrix.Application.Common.Models.ProductSelectors;

public class ConstructionProductSelectorDto
{
    public required string ConstructionType { get; set; }

    public required string BuilderType { get; set; }

    public required int CouncilZoiningID { get; set; }

    public string? RenovationType { get; set; }

    public bool ISGreenRated { get; set; }
}
