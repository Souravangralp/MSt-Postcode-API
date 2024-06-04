namespace MSt_Postcode_API.Domain.Entities;

public class PostcodeClassification : BaseAuditableEntity
{
    public required string Name { get; set; }

    public required string Value { get; set; }
}
