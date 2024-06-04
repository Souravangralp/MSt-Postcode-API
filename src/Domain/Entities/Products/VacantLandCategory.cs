namespace ProductMatrix.Domain.Entities.Products;

public class VacantLandCategory : BaseAuditableEntity
{
    public required string Name { get; set; }

    public string? Description { get; set; }
}
