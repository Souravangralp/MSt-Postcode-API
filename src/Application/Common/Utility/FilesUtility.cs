using ProductMatrix.Domain.Constants;

namespace ProductMatrix.Application.Common.Utility;

public static class FilesUtility 
{
    public static string GetJsonPath<TEntity>() where TEntity : class
    {
        string jsonString = "";

        var original = Path.Combine(Directory.GetCurrentDirectory());

        string jsonFilePath = Path.Combine(original, LocalPath.Resources);

        jsonFilePath = Path.Combine(jsonFilePath, GetFileName<TEntity>());

        if (File.Exists(jsonFilePath))
            jsonString = File.ReadAllText(jsonFilePath);

        return jsonString;
    }

    private static string GetFileName<T>()
    {
        string entityName = typeof(T).Name;

        return entityName switch
        {
            nameof(JsonFile.DocType) => JsonFile.DocType.FileName,
            nameof(JsonFile.CategoryType) => JsonFile.CategoryType.FileName,
            nameof(JsonFile.ProductCategory) => JsonFile.ProductCategory.FileName,
            nameof(JsonFile.LoanToValueRatio) => JsonFile.LoanToValueRatio.FileName,
            nameof(JsonFile.Postcode) => JsonFile.Postcode.FileName,
            nameof(JsonFile.StandardAndPoorPostcode) => JsonFile.StandardAndPoorPostcode.FileName,
            nameof(JsonFile.ProductFee) => JsonFile.ProductFee.FileName,
            nameof(JsonFile.State) => JsonFile.State.FileName,
            nameof(JsonFile.AdditionalFee) => JsonFile.AdditionalFee.FileName,
            nameof(JsonFile.RelocationServicing) => JsonFile.RelocationServicing.FileName,
            nameof(JsonFile.VacantLandCategory) => JsonFile.VacantLandCategory.FileName,
            nameof(JsonFile.CouncilZoningCategory) => JsonFile.CouncilZoningCategory.FileName,
            nameof(JsonFile.DefaultSetting) => JsonFile.DefaultSetting.FileName,
            nameof(JsonFile.BorrowingEntityType) => JsonFile.BorrowingEntityType.FileName,
            nameof(JsonFile.CommonDropdownClassification) => JsonFile.CommonDropdownClassification.FileName,
            nameof(JsonFile.EmploymentClassification) => JsonFile.EmploymentClassification.FileName,
            nameof(JsonFile.SelfEmployedClassification) => JsonFile.SelfEmployedClassification.FileName,
            nameof(JsonFile.ZoiningType) => JsonFile.ZoiningType.FileName,
            nameof(JsonFile.OtherIncomeType) => JsonFile.OtherIncomeType.FileName,
            nameof(JsonFile.ConstructionType) => JsonFile.ConstructionType.FileName,
            nameof(JsonFile.BuilderType) => JsonFile.BuilderType.FileName,
            nameof(JsonFile.CashOutType) => JsonFile.CashOutType.FileName,
            nameof(JsonFile.BusinessFinanceType) => JsonFile.BusinessFinanceType.FileName,
            nameof(JsonFile.RenovationType) => JsonFile.RenovationType.FileName,
            nameof(JsonFile.RulesFilter) => JsonFile.RulesFilter.FileName,
            _ => throw new ArgumentException($"Unknown entity: {entityName}"),
        };
    }

    public static string GetFilePath(string fileName)
    {
        var original = Path.Combine(Directory.GetCurrentDirectory());

        string excelFilePath = Path.Combine(original, LocalPath.Resources);

        excelFilePath = Path.Combine(excelFilePath, fileName);

        return excelFilePath;
    }
}
