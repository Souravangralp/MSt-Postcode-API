namespace MSt_Postcode_API.Domain.Entities;

public class Postcode : BaseAuditableEntity
{
    public required string Code { get; set; }

    public int? Postcode_SuburbID { get; set; }

    public Suburb? Postcode_Suburb { get; set; }
}
