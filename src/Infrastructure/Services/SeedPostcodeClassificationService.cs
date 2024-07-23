namespace MSt_Postcode_API.Infrastructure.Services;

public class SeedPostcodeClassificationService : ISeedPostcodeClassificationService
{
    private readonly IExcelFileService _excelFileService;

    public SeedPostcodeClassificationService(IExcelFileService excelFileService)
    {
        _excelFileService = excelFileService;
    }

    public async Task<List<PostcodeClassificationMapper>> GetAll(string fileName, string sheetName)
    {
        var postcodeClassifications = await _excelFileService.GetExcelData<PostcodeClassificationDto>(fileName, sheetName);

        return GetPostcodeClassificationMapper(postcodeClassifications);
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
}
