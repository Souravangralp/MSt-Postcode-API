namespace MSt_Postcode_API.Domain.Entities;

public class Suburb : BaseAuditableEntity
{
    public int? Suburb_StateID { get; set; }

    public int? Suburb_LocationTypeID { get; set; }

    public required string Name { get; set; }

    public State? Suburb_State { get; set; }

    public GeneralLookup? Suburb_LocationType { get; set; }

    public List<Postcode> Postcodes { get; set; } = [];
}
