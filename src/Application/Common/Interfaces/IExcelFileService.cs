namespace ProductMatrix.Application.Common.Interfaces;

public interface IExcelFileService
{
    Task<List<T>> GetExcelData<T>(string fileName, string sheetName) where T : class;
}
