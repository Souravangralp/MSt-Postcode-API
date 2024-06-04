namespace ProductMatrix.Domain.Entities.ProductSelectors;

public class PurchaseTypeProductSelector : BaseAuditableEntity
{
    public int? PurchaseTypeProductSelector_DocTypeID { get; set; }
    
    public int? PurchaseTypeProductSelector_ProductID { get; set; }

    public int? PurchaseTypeProductSelector_CouncilZoningTypeID { get; set; }

    public required string OccupancyType {  get; set; }

    public required double MinimumLVR { get; set; }

    public required double MaximumLVR { get; set; }

    public DocType? PurchaseTypeProductSelector_DocType { get; set; }

    public Product? PurchaseTypeProductSelector_Product { get; set; }

    public CouncilZoningCategory? PurchaseTypeProductSelector_CouncilZoningType { get; set; }
}
