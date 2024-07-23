namespace MSt_Postcode_API.Infrastructure.Data;

public static class InitialiserExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

        await initialiser.InitialiseAsync();

        await initialiser.SeedAsync();
    }
}

public class ApplicationDbContextInitialiser
{
    #region Fields

    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;
    private readonly ISeedPostcodeSuburbService _seedPostcodeSuburbService;
    private readonly ISeedPostcodeClassificationService _seedPostcodeClassificationService;
    private readonly IExcelFileService _excelFileService;

    #endregion

    #region Ctor

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger,
        ApplicationDbContext context,
        ISeedPostcodeSuburbService seedPostcodeSuburbService,
        ISeedPostcodeClassificationService seedPostcodeClassificationService,
        IExcelFileService excelFileService)
    {
        _logger = logger;
        _context = context;
        _seedPostcodeSuburbService = seedPostcodeSuburbService;
        _seedPostcodeClassificationService = seedPostcodeClassificationService;
        _excelFileService = excelFileService;
    }

    #endregion

    #region Methods

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        await SeedExcel<GeneralLookup>(ExcelFile.Postcode.FileName, ExcelSheetName.GeneralLookUps.SheetName);

        await _excelFileService.SeedJson<State>();

        await SeedPostcodes();

        await SeedSuburb();

        await SeedPostcodesSuburbMapper();

        await SeedExcel<PostcodeClassification>(ExcelFile.Postcode.FileName, ExcelSheetName.PostcodeClassifications.SheetName);

        await SeedPostcodesClassificationMapper();
    }

    #endregion

    #region Helpers

    #region Postcode

    public async Task SeedPostcodes()
    {
        if (!_context.Postcodes.Any())
        {
            var postcodes = await _seedPostcodeSuburbService.GetPostcodes();

            await _context.Postcodes.AddRangeAsync(postcodes);

            await _context.SaveChangesAsync();
        }
    }

    public async Task SeedSuburb()
    {
        if (!_context.Suburbs.Any())
        {
            var suburbs = await _seedPostcodeSuburbService.GetSuburbs(ExcelFile.Postcode.FileName, ExcelSheetName.Suburbs.SheetName);

            await _context.Suburbs.AddRangeAsync(suburbs);

            await _context.SaveChangesAsync();
        }
    }

    public async Task SeedPostcodesSuburbMapper()
    {
        if (!_context.PostcodeSuburbMapper.Any())
        {
            var postcodeSuburbMapper = await _seedPostcodeSuburbService.GetPostcodeSuburbMapper(ExcelFile.Postcode.FileName, ExcelSheetName.Suburbs.SheetName);

            await _context.PostcodeSuburbMapper.AddRangeAsync(postcodeSuburbMapper);

            await _context.SaveChangesAsync();
        }
    }

    public async Task SeedPostcodesClassificationMapper()
    {
        if (!_context.PostcodeClassificationMapper.Any())
        {
            var postcodeClassificationMapper = await _seedPostcodeClassificationService.GetAll(ExcelFile.Postcode.FileName, ExcelSheetName.PostcodeClassificationMapper.SheetName);

            await _context.PostcodeClassificationMapper.AddRangeAsync(postcodeClassificationMapper);

            await _context.SaveChangesAsync();
        }
    }

    #endregion

    /// <summary>
    /// This method is used to seed data from excel sheet based on given sheet
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <param name="fileName"></param>
    /// <param name="sheetName"></param>
    private async Task SeedExcel<TEntity>(string fileName, string sheetName) where TEntity : class
    {
        if (!_context.Set<TEntity>().Any())
        {
            var data = await _excelFileService.GetExcelData<TEntity>
                                                             (fileName, sheetName);

            await SaveCollection(data);
        }
    }

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

    #endregion
}
