namespace ProductMatrix.Application.Common.Models.ProductSelectors;

public class PostCodeScenarioDto
{
    public string? PCCategory { get; set; } // Metro, NonMetro, InnerCity, Unlisted

    public string? ISHighDensity { get; set; } // true, false

    public string? Capital { get; set; } // Category 1, Category 2, Category 3, Unlisted

    public string? LoanType { get; set; } // OwnerOccupied and Investment

    public int? Dwellings { get; set; } // number of dwellings on one title.
}
