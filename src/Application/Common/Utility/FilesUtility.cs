using MSt_Postcode_API.Domain.Constants;

namespace MSt_Postcode_API.Application.Common.Utility;

public static class FilesUtility
{
    public static string GetFilePath(string fileName)
    {
        var original = Path.Combine(Directory.GetCurrentDirectory());

        string excelFilePath = Path.Combine(original, LocalPath.Resources);

        excelFilePath = Path.Combine(excelFilePath, fileName);

        return excelFilePath;
    }

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
            nameof(JsonFile.State) => JsonFile.State.FileName,
            _ => throw new ArgumentException($"Unknown entity: {entityName}"),
        };
    }
}
