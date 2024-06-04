namespace ProductMatrix.Domain.Entities.ProductSelectors;

public class AgeCreditReportProductSelector : BaseAuditableEntity
{
    public int? AgeCreditReportProductSelector_ProductID { get; set; }

    public required int FromDays { get; set; }

    public required int ToDays { get; set;}

    public Product? AgeCreditReportProductSelector_Product { get; set; }
}
