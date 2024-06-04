namespace ProductMatrix.Domain.Constants;

public record FeeType(string FeeName)
{
    public static readonly FeeType ApplicationFee = new("applicationFee");

    public static readonly FeeType AnnualFacilityFee = new("annualFacilityFee");

    public static readonly FeeType RiskPercent = new("riskPercent");

    public static readonly FeeType EstablishmentPercent = new("establishmentPercent");

    public static readonly FeeType SettlementFee = new("settlementFee");

    public static readonly FeeType DischargeFee = new("dischargeFee");

    public static readonly FeeType RateLoading = new("rateLoading");

    public static readonly FeeType DeedOfPriority = new("deedOfPriority");

    public static readonly FeeType ExpressFee = new("expressFee");
}
