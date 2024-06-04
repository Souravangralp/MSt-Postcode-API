namespace ProductMatrix.Domain.Entities.Postcodes;

public class State : BaseAuditableEntity
{
    [Comment("Victoria")]
    public required string Name { get; set; }

    [Comment("Vic")]
    public required string AbbreivatedName { get; set; }

    public bool ISTerritory { get; set; }

    public List<Postcode> Postcodes { get; set; } = [];
}
