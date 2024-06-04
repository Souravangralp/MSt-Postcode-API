namespace ProductMatrix.Domain.Entities.ProductSelectors;

public class PotentialImpactfulConsiderationProductSelector : BaseAuditableEntity
{
    public int? PotentialImpactfulConsiderationProductSelector_ProductID { get; set; }

    public required string Type { get; set; }

    public Product? PotentialImpactfulConsiderationProductSelector_Product { get; set; }
}
