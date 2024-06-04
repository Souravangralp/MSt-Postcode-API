namespace ProductMatrix.Domain.Constants;

public record ProductType(string ProductName)
{
    public static readonly ProductType UltraPrime = new("Ultra prime"); 

    public static readonly ProductType UltraPrimeII = new("Ultra prime II");

    public static readonly ProductType UltraPrimeIII = new("Ultra prime III");

    public static readonly ProductType UltraPrimeIV = new("Ultra prime IV");

    public static readonly ProductType UltraPrimeV = new("Ultra prime V");

    public static readonly ProductType SuperPrime = new("Super prime");

    public static readonly ProductType SuperPrimeII = new("Super prime II");

    public static readonly ProductType SuperPrimeIII = new("Super prime III");

    public static readonly ProductType SuperPrimeIV = new("Super prime IV");

    public static readonly ProductType SuperPrimeV = new("Super prime V");

    public static readonly ProductType Premium = new("Premium");

    public static readonly ProductType PremiumII = new ("Premium II");

    public static readonly ProductType PremiumIII = new ("Premium III");

    public static readonly ProductType PremiumIV = new ("Premium IV");

    public static readonly ProductType PremiumV = new ("Premium V");

    public static readonly ProductType Optimax = new ("Optimax");

    public static readonly ProductType OptimaxII = new ("Optimax II");

    public static readonly ProductType OptimaxIII = new ("Optimax III");

    public static readonly ProductType OptimaxIV = new ("Optimax IV");

    public static readonly ProductType OptimaxV = new ("Optimax V");

    public static readonly ProductType Tolerant = new("Tolerant");

    public static readonly ProductType TolerantII = new("Tolerant II");

    public static readonly ProductType TolerantIII = new("Tolerant III");

    public static readonly ProductType TolerantIV = new("Tolerant IV");

    public static readonly ProductType TolerantV = new("Tolerant V");

    public static readonly ProductType ProgressiveII = new ("Progressive II");

    public static readonly ProductType ProgressiveIII = new ("Progressive III");

    public static readonly ProductType ProgressiveIV = new ("Progressive IV");

    public static readonly ProductType ProgressiveV = new ("Progressive V");

    public static readonly ProductType Receptive = new("Receptive");

    public static readonly ProductType ReceptiveII = new ("Receptive II");

    public static readonly ProductType ReceptiveIII = new ("Receptive III");

    public static readonly ProductType ReceptiveIV = new ("Receptive IV");

    public static readonly ProductType ReceptiveV = new ("Receptive V");

    public static readonly ProductType Liberal = new("Liberal");

    public static readonly ProductType LiberalII = new("Liberal II");

    public static readonly ProductType LiberalIII = new("Liberal III");

    public static readonly ProductType LiberalIV = new("Liberal IV");

    public static readonly ProductType LiberalV = new("Liberal V");

    public static readonly ProductType LiberalHL = new ("Liberal HL");
}
