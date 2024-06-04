namespace ProductMatrix.Domain.Entities.Products;

public class ProductCatalogue : BaseAuditableEntity
{
    public required string RuleDescription { get; set; }

    public bool ISUltraPrimeI { get; set; }
    public bool ISUltraPrimeII { get; set; }
    public bool ISUltraPrimeIII { get; set; }
    public bool ISUltraPrimeIV { get; set; }
    public bool ISUltraPrimeV { get; set; }

    public bool ISSuperPrimeI { get; set; }
    public bool ISSuperPrimeII { get; set; }
    public bool ISSuperPrimeIII { get; set; }
    public bool ISSuperPrimeIV { get; set; }
    public bool ISSuperPrimeV { get; set; }

    public bool ISPremiumI { get; set; }
    public bool ISPremiumII { get; set; }
    public bool ISPremiumIII { get; set; }
    public bool ISPremiumIV { get; set; }
    public bool ISPremiumV { get; set; }

    public bool ISOptimaxI { get; set; }
    public bool ISOptimaxII { get; set; }
    public bool ISOptimaxIII { get; set; }
    public bool ISOptimaxIV { get; set; }
    public bool ISOptimaxV { get; set; }

    public bool ISTolerantI { get; set; }
    public bool ISTolerantII { get; set; }
    public bool ISTolerantIII { get; set; }
    public bool ISTolerantIV { get; set; }
    public bool ISTolerantV { get; set; }

    public bool ISProgressiveI { get; set; }
    public bool ISProgressiveII { get; set; }
    public bool ISProgressiveIII { get; set; }
    public bool ISProgressiveIV { get; set; }
    public bool ISProgressiveV { get; set; }

    public bool ISReceptiveI { get; set; }
    public bool ISReceptiveII { get; set; }
    public bool ISReceptiveIII { get; set; }
    public bool ISReceptiveIV { get; set; }
    public bool ISReceptiveV { get; set; }

    public bool ISLiberalI { get; set; }
    public bool ISLiberalII { get; set; }
    public bool ISLiberalIII { get; set; }
    public bool ISLiberalIV { get; set; }
    public bool ISLiberalV { get; set; }
}
