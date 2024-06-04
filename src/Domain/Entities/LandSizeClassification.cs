namespace ProductMatrix.Domain.Entities;

public class LandSizeClassification : BaseAuditableEntity
{
    public int? LandSizeClassification_CouncilZoningTypeID { get; set; }

    public double From { get; set; }

    public double To { get; set; }

    public int? HeedFulPoints { get; set; }

    public CouncilZoningCategory? LandSizeClassification_CouncilZoningType { get; set; }
}
