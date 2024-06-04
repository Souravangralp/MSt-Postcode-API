namespace ProductMatrix.Application.Common.Models;

public class TextValuePair
{
    public int Key { get; set; }

    public required string Value { get; set; }

    public bool ISDefault { get; set; }
}
