namespace MSt_Postcode_API.Domain.Constants;

public record PostcodeClassificationType(string Value)
{
    public static readonly PostcodeClassificationType PCCategory = new("PCCategory");

    public static readonly PostcodeClassificationType StandardAndPoor = new("StandardAndPoor");

    public static readonly PostcodeClassificationType HighSecurity = new("HighSecurity");

    public static readonly PostcodeClassificationType Unsuitable = new("Unsuitable");
}

public record HighSecurityType(string Value) 
{
    public static readonly HighSecurityType HighDensity = new("HighDensity");

    public static readonly HighSecurityType SelectedNonMetro = new("SelectedNonMetro");

    public static readonly HighSecurityType MetroPlus = new("MetroPlus");
}
