namespace ProductMatrix.Domain.Entities;

public class GeneralLookUp : BaseAuditableEntity
{
    public required string Type { get; set; }

    public required string Value { get; set; }

    public bool ISArchived { get; set; }

    public bool ISDefault { get; set; }

    public int DisplayOrder { get; set; }

    public string? Description { get; set; }
}
