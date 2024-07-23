namespace MSt_Postcode_API.Infrastructure.Services;

public class SeedPostcodeClassificationService : ISeedPostcodeClassificationService
{
    #region Fields

    private readonly IExcelFileService _excelFileService;

    #endregion

    #region Ctor

    public SeedPostcodeClassificationService(IExcelFileService excelFileService)
    {
        _excelFileService = excelFileService;
    }

    #endregion

    #region Methods

    public async Task<List<PostcodeClassificationMapper>> GetAll(string fileName, string sheetName)
    {
        var postcodeClassifications = await _excelFileService.GetExcelData<PostcodeClassificationDto>(fileName, sheetName);

        return PostcodeUtility.GetPostcodeClassificationMapper(postcodeClassifications);
    }

    #endregion
}
