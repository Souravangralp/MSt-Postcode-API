namespace ProductMatrix.Domain.Entities.Postcodes;

public class Suburb : BaseAuditableEntity
{
    public int? Suburb_SuburbStateID { get; set; }

    public required string Name { get; set; }

    public State? SuburbState { get; set; }
}
