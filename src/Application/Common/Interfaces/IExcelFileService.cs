namespace MSt_Postcode_API.Application.Common.Interfaces;

public interface IExcelFileService
{
    Task<List<T>> GetExcelData<T>(string fileName, string sheetName) where T : class;

    Task SeedJson<TEntity>() where TEntity : class;
}
