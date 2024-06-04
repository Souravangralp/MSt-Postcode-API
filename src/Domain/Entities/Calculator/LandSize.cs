namespace ProductMatrix.Domain.Entities.Calculator;

public class LandSize : BaseAuditableEntity
{
     public required double From { get; set; }
    
     public required double To { get; set; } 
}
