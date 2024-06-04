namespace ProductMatrix.Domain.Entities.Postcodes;

public class PostcodeSuburbMapper : BaseAuditableEntity
{
    public int PostcodeSuburbMapper_PostcodeID { get; set; }

    public int? PostcodeSuburbMapper_SuburbID { get; set; }

    public bool ISIsLand {  get; set; }

    public Suburb? PostcodeSuburbMapper_Suburb { get; set; }

    public Postcode? PostcodeSuburbMapper_Postcode { get; set; }
}
