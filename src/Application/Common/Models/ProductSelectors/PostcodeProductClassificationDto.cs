namespace ProductMatrix.Application.Common.Models.ProductSelectors;

public class PostcodeProductClassificationDto
{
    public string PCCategory { get; set; } = string.Empty;

    public string HighSecurity1 { get; set; } = string.Empty;

    public string HighSecurity2 { get; set; } = string.Empty;

    public string StandardAndPoor { get; set; } = string.Empty;
}
