namespace ProductMatrix.Domain.Constants;

public record SystemDefault(string PropertyName)
{
    public static readonly SystemDefault AdditionalFeeForDwelling = new("additionalFeeForDwelling");

    public static readonly SystemDefault AdditionalFeeForParticipants = new("additionalFeeForParticipants");

    public static readonly SystemDefault DefaultApplicationFee = new("defaultApplicationFee");

    public static readonly SystemDefault DefaultLVR = new("defaultLVR");

    public static readonly SystemDefault DefaultDwelling = new("defaultDwelling");

    public static readonly SystemDefault DwellingRate = new("dwellingRate");

    public static readonly SystemDefault DefaultParticipant = new("defaultParticipent");

    public static readonly SystemDefault ParticipatingRate = new("participatingRate");

    public static readonly SystemDefault UltraPrimeIncrementAmount = new("ultraPrimeIncrementAmount");

    public static readonly SystemDefault SuperPrimeIncrementAmount = new("superPrimeIncrementAmount");

    public static readonly SystemDefault PremiumIncrementAmount = new("premiumIncrementAmount");

    public static readonly SystemDefault OptimaxIncrementAmount = new("optimaxIncrementAmount");

    public static readonly SystemDefault TolerantIncrementAmount = new("tolerantIncrementAmount");

    public static readonly SystemDefault ProgressiveIncrementAmount = new("progressiveIncrementAmount");

    public static readonly SystemDefault DefaultLoanAmount = new("defaultLoanAmount");

    public static readonly SystemDefault DefaultIncrementLoanPercent = new("defaultIncrementLoanPercent");
}
