namespace ProductMatrix.Domain.Entities.ProductSelectors;

public class PostcodeProductSelector : BaseAuditableEntity
{
    public int? PostcodeProductSelector_ProductID { get; set; }

    public int? PostcodeProductSelector_PostcodeSpecificationMapperID { get; set; }

    public Product? PostcodeProductSelector_Product { get; set; }

    public PostcodeSpecificationMapper? PostcodeProductSelector_PostcodeSpecificationMapper { get; set; }
}
