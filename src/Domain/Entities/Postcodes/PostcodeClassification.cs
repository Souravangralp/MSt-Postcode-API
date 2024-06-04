namespace ProductMatrix.Domain.Entities.Postcodes;

public class PostcodeClassification : BaseAuditableEntity
{
    public required string Name { get; set; }

    public required string Value { get; set; }
}
