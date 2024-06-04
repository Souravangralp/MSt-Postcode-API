namespace ProductMatrix.Domain.Entities.Calculator;

public class DefaultSetting : BaseAuditableEntity
{
    public required string Property { get; set; }

    public required string Value { get; set; }

    public required string DataType { get; set; }

    public string? Description { get; set; }
}
