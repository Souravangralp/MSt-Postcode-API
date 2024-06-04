namespace ProductMatrix.Domain.Entities.ProductSelectors;

public class UnitsApartmentProductSelector : BaseAuditableEntity
{
    public int? UnitsApartmentProductSelector_ProductID { get; set; }

    public required double LivingAreaFrom { get; set; }

    public required double LivingAreaTo { get; set; }

    public Product? UnitsApartmentProductSelector_Product { get; set; }
}
