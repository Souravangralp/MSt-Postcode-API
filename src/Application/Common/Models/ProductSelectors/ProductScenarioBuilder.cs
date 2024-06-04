namespace ProductMatrix.Application.Common.Models.ProductSelectors;

public class ProductScenarioBuilder
{
    public required int ProductCategoryID { get; set; }

    public required string DocType { get; set; }

    public double? LVR { get; set; } // LVR 

    public double? LoanAmount { get; set; } // LVR 

    public required PostCodeScenarioDto PostCodeScenarioDto { get; set; }
}
