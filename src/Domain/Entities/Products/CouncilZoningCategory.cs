namespace ProductMatrix.Domain.Entities.Products;

public class CouncilZoningCategory : BaseAuditableEntity
{
    public required string Name { get; set; }

    public string? Description { get; set; }
}
