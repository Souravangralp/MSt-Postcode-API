namespace ProductMatrix.Application.Common.Models;

public class ProductFeeResult
{
    public double? LoanAmount { get; set; }

    public double? IncreaseSecurityAmount { get; set; }

    public double? MaximumLVR { get; set; }

    public double? ApplicationFee { get; set; }

    public double? AnnualFacilityFee { get; set; }

    public double? RiskPercent { get; set; }

    public double? RiskFee { get; set; }

    public double? EstablishmentPercent { get; set; }

    public double? EstablishmentFee { get; set; }
    
    public double? SettlementFee { get; set; }

    public double? DischargeFee { get; set; }

    public double? ConstructionAdministrationFee { get; set; }

    public double? RateLoading { get; set; }

    public double? DeedOfPriority { get; set; }

    public double? ExpressFee { get; set; }

    public bool IsSuggestion { get; set; }
}
