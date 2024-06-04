namespace ProductMatrix.Domain.Entities.Postcodes;

public class Postcode : BaseAuditableEntity
{
    public required string Code { get; set; }

    public int? Postcode_StateID { get; set; }

    public bool ISIsLand { get; set; }

    public State? Postcode_State { get; set; }
}
