using MSt_Postcode_API.Domain.Entities;

namespace MSt_Postcode_API.Domain.Entities.Mappers;

public class PostcodeClassificationMapper : BaseAuditableEntity
{
    public int? PostcodeClassificationMapper_PostcodeClassificationID { get; set; }

    public int? PostcodeClassificationMapper_PostcodeID { get; set; }

    public Postcode? PostcodeClassificationMapper_Postcode { get; set; }

    public PostcodeClassification? PostcodeClassificationMapper_PostcodeClassification { get; set; }
}
