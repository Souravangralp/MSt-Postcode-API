namespace MSt_Postcode_API.Domain.Entities.Mappers;

public class PostcodeSpecificationMapper : BaseAuditableEntity
{
    public int? PostcodeClassification_SAndPID { get; set; }

    public int? PostcodeClassification_HighSecurityID { get; set; }

    public int? PostcodeClassification_PCCategoryID { get; set; }

    public PostcodeClassification? PostcodeClassification_PCCategory { get; set; }

    public PostcodeClassification? PostcodeClassification_HighSecurity { get; set; }

    public PostcodeClassification? PostcodeClassification_SAndP { get; set; }
}
