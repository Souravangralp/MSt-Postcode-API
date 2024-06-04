namespace ProductMatrix.Application.Common.Models;

public class ProductFeeDto
{
    public required string DocType { get; set; }

    public required double LandSize { get; set; }

    public required double Lvr { get; set; }

    public required double LoanAmount { get; set; }

    public required int ProductId { get; set; }

    public required int NumberOfDwellings { get; set; }

    public required int NumberOfParticipatingEntities { get; set; }
}
