namespace ProductMatrix.Application.Common.Models;

public class PostcodeResult
{
    public required string Capital { get; set; }

    public required string PcCategory { get; set; }

    public bool ISMetroPlus { get; set; }

    public bool ISHighDensity { get; set; }

    public bool ISSelectedNonMetro { get; set; }
}
