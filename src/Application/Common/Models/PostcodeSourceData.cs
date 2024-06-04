namespace ProductMatrix.Application.Common.Models;

public class PostcodeDetailDto
{
    public required int Postcode { get; set; }

    public required string Suburb { get; set; }

    public required string StateCode { get; set; }

    public bool ISIsLand { get; set; }
}
