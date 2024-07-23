namespace MSt_Postcode_API.Infrastructure.Services;

public class SeedPostcodeSuburbService : ISeedPostcodeSuburbService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly IExcelFileService _excelFileService;

    #endregion

    #region Ctor

    public SeedPostcodeSuburbService(
        IApplicationDbContext context,
        IExcelFileService excelFileService)
    {
        _context = context;
        _excelFileService = excelFileService;
    }

    #endregion

    #region Methods

    public async Task<List<Suburb>> GetSuburbs(string fileName, string sheetName)
    {
        List<Suburb> suburbs = [];

        var suburbDetails = await GetSuburbDetails(fileName, sheetName);

        var states = await _context.States.ToListAsync();

        foreach (var suburbDetail in suburbDetails)
        {
            var state = states.FirstOrDefault(s => s.AbbreviatedName.Trim().ToLower() == suburbDetail.StateCode.Trim().ToLower())
                    ?? throw new NotFoundException(suburbDetail.StateCode, nameof(State));

            suburbs.Add(new()
            {
                Name = suburbDetail.Suburb,
                Suburb_StateID = state.ID,
                Suburb_LocationTypeID = null
            });
        }

        return suburbs;
    }

    public async Task<List<PostcodeSuburbMapper>> GetPostcodeSuburbMapper(string fileName, string sheetName)
    {
        var suburbDetails = await GetSuburbDetails(fileName, sheetName);

        var postcodes = await GetPostcodes();

        List<PostcodeSuburbMapper> postcodeSuburbMapper = [];

        foreach (var suburbDetail in suburbDetails)
        {
            foreach (var (postcode, index) in postcodes.Select((value, i) => (value, i)))
            {
                if (postcode.Code == suburbDetail.Postcode)
                {
                    postcodeSuburbMapper.Add(new PostcodeSuburbMapper()
                    {
                        PostcodeSuburbMapper_PostcodeID = (index + 1),
                        PostcodeSuburbMapper_SuburbID = suburbDetail.ID
                    });
                }
            }
        }

        return postcodeSuburbMapper;
    }

    public async Task<List<Postcode>> GetPostcodes()
    {
        List<Postcode> postcodes = [];

        try
        {
            int postcodeRange = 10000;

            for (int i = 0; i <= postcodeRange; i++)
            {
                string postcode = i.ToString("D4");

                postcodes.Add(new() { Code = postcode });
            }
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while importing postcode from excel", ex);
        }

        return await Task.FromResult(postcodes);
    }

    #region Helpers

    private async Task<List<SuburbDetail>> GetSuburbDetails(string fileName, string sheetName)
    {
        return await _excelFileService.GetExcelData<SuburbDetail>(fileName, sheetName);
    }

    #endregion

    #endregion
}

public class SuburbDetail
{
    public int ID { get; set; }

    public required string Postcode { get; set; }

    public required string Suburb { get; set; }

    public required string StateCode { get; set; }
}
