using ProductMatrix.Domain.Entities.ProductSelectors;

namespace ProductMatrix.Domain.Entities;

public class SelfEmployedClassification : BaseAuditableEntity
{
    public int? SelfEmployedClassification_DocTypeID { get; set; }

    public required int MinimumTimeInMonths { get; set; }

    public required int MaximumTimeInMonths { get; set; }

    public List<SelfEmployedClassificationProductSelector> SelfEmployedClassificationProductSelectors { get; set; } = [];
}
