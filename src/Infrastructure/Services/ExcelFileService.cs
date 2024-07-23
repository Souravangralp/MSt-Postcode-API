namespace MSt_Postcode_API.Infrastructure.Services;

public class ExcelFileService : IExcelFileService
{
    #region Fields

    private readonly ApplicationDbContext _context;

    #endregion

    #region Ctor

    public ExcelFileService(ApplicationDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Methods

    public async Task<List<T>> GetExcelData<T>(string fileName, string sheetName) where T : class
    {
        ExcelWorksheet workbook = await GetWorkbook(fileName, sheetName);

        return GetDataFromExcelWorksheet<T>(workbook);
    }

    /// <summary>
    /// This method is being used to seed data from a json file to db.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public async Task SeedJson<TEntity>() where TEntity : class
    {
        if (!_context.Set<TEntity>().Any())
        {
            var jsonString = FilesUtility.GetJsonPath<TEntity>();

            if (!string.IsNullOrWhiteSpace(jsonString))
            {
                var data = JsonConvert.DeserializeObject<List<TEntity>>(jsonString);

                if (data is not null && data.Count != 0)
                {
                    _context.Set<TEntity>().AddRange(data);

                    await _context.SaveChangesAsync();
                }
            }
        }
    }

    #region Helpers

    /// <summary>
    /// This method is used to seed excel data collection to Db
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <param name="data"></param>
    /// <returns></returns>
    public async Task SaveCollection<TEntity>(List<TEntity> data) where TEntity : class
    {
        try
        {
            var entityType = _context.Model.FindEntityType(typeof(TEntity));

            if (entityType == null)
            {
                return;
            }

            using var transaction = _context.Database.BeginTransaction();

            await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT " + entityType.GetTableName() + " ON");

            await _context.Set<TEntity>().AddRangeAsync(data);

            await _context.SaveChangesAsync();

            await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT " + entityType.GetTableName() + " OFF");

            transaction.Commit();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }

    }


    /// <summary>
    /// This method is being used to get a specific workbook from the excel sheet.
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="sheetName"></param>
    /// <returns>ExcelWorksheet</returns>
    /// <exception cref="Exception"></exception>
    private static async Task<ExcelWorksheet> GetWorkbook(string fileName, string sheetName)
    {
        string workbookName = "";

        try
        {
            string filePath = FilesUtility.GetFilePath(fileName);

            var memoryStream = await GetExcelWorkSheet(filePath);

            ExcelPackage package = new(memoryStream);

            ExcelWorksheet worksheet = package.Workbook.Worksheets[sheetName];

            workbookName = worksheet.Name;

            return worksheet;
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while reading excel Workbook for {fileName} @ {workbookName}", ex);
        }

    }

    /// <summary>
    /// This method is being used to extract data of an specific type to given class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="worksheet"></param>
    /// <returns>List<T></returns>
    /// <exception cref="ArgumentException"></exception>
    public static List<T> GetDataFromExcelWorksheet<T>(ExcelWorksheet worksheet) where T : class
    {
        var properties = GetAllClassProperties<T>(); //--> class properties

        var headers = GetExcelHeaders(worksheet); //---> properties from excel sheet.

        var columns = headers.Where(property => properties.Contains(property.PropertyName)) //---> filter the properties which data is required for seeding.
            .ToList();

        List<T> dataList = new List<T>();

        for (int row = worksheet.Cells[4, 2].Value.GetValue("int"); row <= worksheet.Dimension.End.Row; row++)
        {
            T obj = Activator.CreateInstance<T>(); //---> Instantiating the object of specific type with Activator to avoid compiler error (if class has some required properties we must declare that property on the time of object instantiation!)

            foreach (var column in columns)
            {
                PropertyInfo property = typeof(T).GetProperty(column.PropertyName) ?? throw new ArgumentException();

                if (property != null && property.CanWrite) //---> Checking if property can be written 
                {
                    if (property.Name == column.PropertyName)
                    {
                        property.SetValue(obj, worksheet.Cells[row, column.Column].Value.GetValue(column.DataType));
                    }
                }
            }

            dataList.Add(obj); //---> Add the object to the list after setting all properties            
        }

        return dataList;
    }

    /// <summary>
    /// This method will read all the headers from excel sheet. 
    /// Header presents property name of a class.
    /// </summary>
    /// <param name="worksheet"></param>
    /// <returns>propertyDetail</returns>
    private static List<PropertyDetail> GetExcelHeaders(ExcelWorksheet worksheet)
    {
        List<PropertyDetail> propertyDetails = [];

        var rowStartCount = worksheet.Cells[3, 2].GetValue<int>();
        var excelCollStartCount = worksheet.Cells[1, 2].GetValue<int>();
        var excelCollEndCount = worksheet.Cells[2, 2].GetValue<int>();

        for (int row = rowStartCount; row == rowStartCount; row++)
        {
            if (row == rowStartCount + 1)
                break;
            else
            {
                for (int col = excelCollStartCount; col <= excelCollEndCount; col++)
                {
                    propertyDetails.Add(
                        new()
                        {
                            Column = col,
                            DataType = worksheet.Cells[row, col].Value.GetValue("string") ?? "",
                            PropertyName = worksheet.Cells[(row + 1), col].Value.GetValue("string") ?? ""
                        });
                }
            }
        }

        return propertyDetails;
    }

    /// <summary>
    /// This method will extract all the properties of an specific class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns>List<Properties></returns>
    private static List<string> GetAllClassProperties<T>()
    {
        var properties = new List<string>();

        PropertyInfo[] propertiesInfo = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var property in propertiesInfo)
        {
            properties.Add(property.Name);
        }

        return properties;
    }

    private static async Task<MemoryStream> GetExcelWorkSheet(string filePath)
    {
        try
        {
            MemoryStream memoryStream = new();

            using (FileStream fileStream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                await fileStream.CopyToAsync(memoryStream);
            }

            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            return memoryStream;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while getting excel file", ex);
        }
    }

    public class PropertyDetail
    {
        public required string PropertyName { get; set; }

        public required string DataType { get; set; }

        public required int Column { get; set; }
    }

    #endregion

    #endregion
}
