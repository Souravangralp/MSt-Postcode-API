using MSt_Postcode_API.Domain.Entities.Generals;

namespace MSt_Postcode_API.Domain.Constants;

public record ExcelFile(string FileName)
{
    public static readonly ExcelFile Postcode = new("Postcode.xlsx");
}


public record ExcelSheetName(string SheetName)
{
    public static readonly ExcelSheetName GeneralLookUps = new("GeneralLookUps");

    public static readonly ExcelSheetName Suburbs = new("Suburbs");

    public static readonly ExcelSheetName PostcodeClassifications = new("PostcodeClassifications");

    public static readonly ExcelSheetName PostcodeClassificationMapper = new("PostcodeClassificationMapper");
}
