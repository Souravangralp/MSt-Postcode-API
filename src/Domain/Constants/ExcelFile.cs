namespace ProductMatrix.Domain.Constants;

public record ExcelFile(string FileName)
{
    public static readonly ExcelFile Products = new("Products.xlsx");

    public static readonly ExcelFile ProductFee = new("SeedProductFee.xlsx");

    public static readonly ExcelFile Postcode = new("Postcode.xlsx");

    public static readonly ExcelFile BaseFeesWithScenario = new("BaseFeesWithScenario.xlsx");

    public static readonly ExcelFile ProductSelectionMetrics = new("ProductSelectionCatelogue.xlsx");

    public static readonly ExcelFile ProductSelector = new("ProductSelector.xlsx");

    public static readonly ExcelFile NumeralClassification = new("NumeralClassification.xlsx");

    public static readonly ExcelFile ProductClassification = new("ProductClassification.xlsx");

    public static readonly ExcelFile GeneralLookUp = new("GeneralLookUp.xlsx");
}
