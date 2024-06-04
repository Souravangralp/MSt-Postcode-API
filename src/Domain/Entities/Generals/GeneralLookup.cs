namespace MSt_Postcode_API.Domain.Entities.Generals;

public class GeneralLookup : BaseAuditableEntity
{
    public required string Type { get; set; }

    public required string Value { get; set; }

    public bool ISDefault { get; set; }
}
