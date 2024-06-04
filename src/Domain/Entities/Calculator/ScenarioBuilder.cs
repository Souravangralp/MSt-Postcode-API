namespace ProductMatrix.Domain.Entities.Calculator;

public class ScenarioBuilder : BaseAuditableEntity
{
    public string? CategoryType { get; set; }

    public int? ScenarioBuilder_VacantLandCategoryID { get; set; }

    public int? ScenarioBuilder_RelocationServicingID { get; set; }

    public string? PCCategory { get; set; }

    public bool ISOwnerOccupied { get; set; }

    public string? CouncilZoning { get; set; }

    public bool ISSelectedMetro { get; set; }

    public bool ISNaturalPerson { get; set; }

    public bool ISHighDensity { get; set; }

    public string? FormulaType { get; set; }

    public CouncilZoningCategory? ScenarioBuilder_CouncilZoningCategory { get; set; }

    public VacantLandCategory? ScenarioBuilder_VacantLandCategory { get; set; }

    public RelocationServicing? ScenarioBuilder_RelocationServicing { get; set; }
}
