namespace ProductMatrix.Domain.Entities.Postcodes;

public class PostcodeClassificationMapper : BaseAuditableEntity
{
    public int? PostcodeClassificationMapper_PostcodeClassificationID { get; set; }

    public int? PostcodeClassificationMapper_PostcodeID { get; set; }

    public Postcode? PostcodeClassificationMapper_Postcode { get; set; }

    public PostcodeClassification? PostcodeClassificationMapper_PostcodeClassification { get; set; }
}
