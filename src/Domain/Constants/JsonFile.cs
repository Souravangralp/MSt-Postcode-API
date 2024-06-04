namespace MSt_Postcode_API.Domain.Constants;

public record JsonFile(string FileName)
{
    public static readonly JsonFile State = new("state.json");
}
