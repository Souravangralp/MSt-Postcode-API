namespace ProductMatrix.Infrastructure.Services;

public class PostcodeService : IPostcodeService
{
    #region Fields

    private readonly IApplicationDbContext _context;

    #endregion

    #region Ctor

    public PostcodeService(IApplicationDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Methods

    public async Task<List<PostcodeClassificationMapper>> GetPostcodeClassificationMapper()
    {
        List<PostcodeClassificationMapper> postcodeClassificationMapper = [];

        try
        {
            string filePath = FilesUtility.GetFilePath(ExcelFile.Postcode.FileName);

            var memoryStream = await GetExcelWorkSheet(filePath);

            using ExcelPackage package = new(memoryStream);

            ExcelWorksheet worksheet = package.Workbook.Worksheets[2];

            List<PostcodeClassificationDto> postcodeClassifications = [];

            postcodeClassifications.Clear();

            postcodeClassifications.AddRange(GetPostcodeClassificationsFromExcel(worksheet));

            postcodeClassificationMapper = GetPostcodeClassificationMapper(postcodeClassifications);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while exporting Postcode Classification Mapper from excel", ex);

        }

        return postcodeClassificationMapper;
    }

    #region Helpers

    private static List<PostcodeClassificationDto> GetPostcodeClassificationsFromExcel(ExcelWorksheet worksheet)
    {
        List<PostcodeClassificationDto> postcodeClassifications = [];

        var rowStartCount = 7;
        int excelRowCount = worksheet.Dimension.End.Row;
        if (excelRowCount > 0)
        {
            for (int row = rowStartCount; row <= excelRowCount; row++)
            {
                if (row == excelRowCount + 1)
                    break;
                else
                    postcodeClassifications.Add(
                       new()
                       {
                           RangeFrom = worksheet.Cells[row, 3].Value.GetValue<int>(),
                           RangeTo = worksheet.Cells[row, 4].Value.GetValue<int>(),
                           Classification1 = worksheet.Cells[row, 5].Value.GetValue<int>(),
                           Classification2 = worksheet.Cells[row, 6].Value.GetValue<int>(),
                           Classification3 = worksheet.Cells[row, 7].Value.GetValue<int>(),
                           Classification4 = worksheet.Cells[row, 8].Value.GetValue<int>(),
                       });
            }
        }

        return postcodeClassifications;
    }

    private static List<PostcodeClassificationMapper> GetPostcodeClassificationMapper(List<PostcodeClassificationDto> postcodeClassifications)
    {
        List<PostcodeClassificationMapper> postcodeClassificationMapper = [];

        var postcodeRange = 3200; // we have postcode classifications till 9999 range.

        for (int i = 0; i < postcodeRange; i++)
        {
            foreach (var pc in postcodeClassifications)
            {
                if (pc.RangeFrom <= i && pc.RangeTo >= i)
                {
                    postcodeClassificationMapper.AddRange(new List<PostcodeClassificationMapper>()
                        {
                            new()
                            {
                                PostcodeClassificationMapper_PostcodeID = (i + 1), // ----> (i + 1) because the iteration starts from 0.
                                PostcodeClassificationMapper_PostcodeClassificationID = pc.Classification1,
                            },
                            new()
                            {
                                PostcodeClassificationMapper_PostcodeID = (i + 1),  // ----> (i + 1) because the iteration starts from 0.
                                PostcodeClassificationMapper_PostcodeClassificationID = pc.Classification2,
                            }
                        });

                    if (pc.Classification3 > 0)  // ----> checking if classification3 is not 0.
                    {
                        postcodeClassificationMapper.Add(new()
                        {
                            PostcodeClassificationMapper_PostcodeID = (i + 1), // ----> (i + 1) because the iteration starts from 0.
                            PostcodeClassificationMapper_PostcodeClassificationID = pc.Classification3
                        });
                    }
                    if (pc.Classification4 > 0)  // ----> checking if classification3 is not 0.
                    {
                        postcodeClassificationMapper.Add(new()
                        {
                            PostcodeClassificationMapper_PostcodeID = (i + 1), // ----> (i + 1) because the iteration starts from 0.
                            PostcodeClassificationMapper_PostcodeClassificationID = pc.Classification4
                        });
                    }
                }
            }
        }

        return postcodeClassificationMapper;
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
            throw new Exception("An error occurred while exporting data from excel", ex);
        }
    }

    #endregion

    #endregion
}
