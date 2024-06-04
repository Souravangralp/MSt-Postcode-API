using Microsoft.EntityFrameworkCore;

namespace MSt_Postcode_API.Domain.Entities;

public class State : BaseAuditableEntity
{
    [Comment("Victoria")]
    public required string Name { get; set; }

    [Comment("Vic")]
    public required string AbbreviatedName { get; set; }

    public bool ISTerritory { get; set; }

    public List<Suburb> Suburbs { get; set; } = [];
}
