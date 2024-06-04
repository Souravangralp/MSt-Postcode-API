using ProductMatrix.Domain;
using static ProductMatrix.Domain.Constants.Worksheet;

namespace ProductMatrix.Infrastructure.Data;

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
    //private readonly UserManager<ApplicationUser> _userManager;
    //private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IReadExcelService _readExcelService;
    private readonly IPostcodeService _postcodeService;
    private readonly ISuburbService _suburbService;
    private readonly IExcelFileService _excelFileService;

    #endregion

    #region Ctor

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger,
        ApplicationDbContext context,
        //UserManager<ApplicationUser> userManager,
        //RoleManager<IdentityRole> roleManager,
        IReadExcelService readExcelService,
        IPostcodeService postcodeService,
        ISuburbService suburbService,
        IExcelFileService excelFileService)
    {
        _logger = logger;
        _context = context;
        //_userManager = userManager;
        //_roleManager = roleManager;
        _readExcelService = readExcelService;
        _postcodeService = postcodeService;
        _suburbService = suburbService;
        _excelFileService = excelFileService;
    }

    #endregion

    #region Methods

    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsSqlServer()) { await _context.Database.MigrateAsync(); }
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
            #region seed general look ups

            await SeedExcel<GeneralLookUp>(ExcelFile.GeneralLookUp.FileName, Worksheet.GeneralLookUps.GeneralLookUp);

            #endregion

            #region seed from Json

            await SeedJson<DocType>();

            await SeedJson<CategoryType>();

            await SeedJson<ProductCategory>();

            await SeedJson<LoanToValueRatio>();

            await SeedJson<State>();

            await SeedJson<VacantLandCategory>();

            await SeedJson<RelocationServicing>();

            await SeedJson<CouncilZoningCategory>();

            await SeedJson<DefaultSetting>();

            await SeedJson<BorrowingEntityType>();

            await SeedJson<SelfEmployedClassification>();

            await SeedJson<OtherIncomeType>();

            await SeedJson<ConstructionType>();

            await SeedJson<BuilderType>();

            await SeedJson<CashOutType>();

            await SeedJson<BusinessFinanceType>();

            await SeedJson<RenovationType>();

            await SeedJson<RulesFilter>();

            #endregion

            #region seed from Excel

            #region Product classifications

            await SeedExcel<EmploymentClassification>(ExcelFile.ProductClassification.FileName, ProductClassification.EmploymentClassification);

            await SeedExcel<PostcodeClassification>(ExcelFile.Postcode.FileName, Worksheet.Postcode.PostcodeClassification);

            await SeedExcel<LandSizeClassification>(ExcelFile.ProductClassification.FileName, Worksheet.ProductClassification.LandSizeClassification);

            await SeedExcel<ApplicationObjectiveClassification>(ExcelFile.ProductClassification.FileName, Worksheet.ProductClassification.ApplicationObjective);

            #endregion

            await SeedExcel<Product>(ExcelFile.Products.FileName, Worksheet.Products.Product);

            await SeedPostcodes();

            await SeedExcel<PostcodeSpecificationMapper>(ExcelFile.ProductClassification.FileName, ProductClassification.PostCodeScenarioBuilder);

            await SeedPostcodeClassificationMapper();

            await SeedExcel<ProductFeeLVRRate>(ExcelFile.BaseFeesWithScenario.FileName, ProductMatric.ProductFeeLVRRate); //---> BaseIncrementPercent

            await SeedExcel<LandSize>(ExcelFile.BaseFeesWithScenario.FileName, ProductMatric.LandSizes); //---> LandSize

            await AdditionalFee();

            await ScenarioBuilder();

            await DefaultFee();

            await AdditionalFeeDocTypeVariations();

            await SeedProductCatalogue();

            #region ProductSelector

            await SeedExcel<PostcodeProductSelector>(ExcelFile.ProductSelector.FileName, ProductSelector.PostcodeProductSelector);

            await SeedExcel<DwellingsProductSelector>(ExcelFile.Postcode.FileName, ProductSelector.DwellingsProductSelectors);

            await SeedExcel<DocTypeProductSelector>(ExcelFile.ProductSelector.FileName, ProductSelector.DocTypeProductSelector);

            await SeedExcel<BorrowingEntityProductSelector>(ExcelFile.ProductSelector.FileName, ProductSelector.BorrowingEntityProductSelector);

            await SeedExcel<LoanAmountProductSelector>(ExcelFile.ProductSelector.FileName, ProductSelector.LoanAmountProductSelectors);

            await SeedExcel<LvrProductSelector>(ExcelFile.ProductSelector.FileName, ProductSelector.LvrProductSelectors);

            await SeedExcel<SecurityTypeProductSelector>(ExcelFile.ProductSelector.FileName, ProductSelector.SecurityTypeProductSelector);

            await SeedExcel<RepaymentTypeProductSelector>(ExcelFile.ProductSelector.FileName, ProductSelector.RepaymentTypeProductSelectors);

            await SeedExcel<NaturalPersonAgeProductSelector>(ExcelFile.ProductSelector.FileName, ProductSelector.NaturalPersonAgeProductSelector);

            await SeedExcel<NumeralClassification>(ExcelFile.NumeralClassification.FileName, NumeralClassifications.NumeralSelector);

            await SeedExcel<PurchaseTypeProductSelector>(ExcelFile.ProductSelector.FileName, ProductSelector.PurchaseTypeProductSelector);

            await SeedExcel<EmploymentClassificationProductSelector>(ExcelFile.ProductSelector.FileName, ProductSelector.EmploymentProductSelector);

            await SeedExcel<SelfEmployedClassificationProductSelector>(ExcelFile.ProductSelector.FileName, ProductSelector.SelfEmployedProductSelector);

            await SeedExcel<EmployerClassificationProductSelector>(ExcelFile.ProductSelector.FileName, ProductSelector.EmployerClassificationProductSelector);

            await SeedExcel<ZoningTypeProductSelector>(ExcelFile.ProductSelector.FileName, ProductSelector.ZoiningTypeProductSelector);

            await SeedExcel<OtherIncomeTypeProductSelector>(ExcelFile.ProductSelector.FileName, ProductSelector.OtherIncomeTypeProductSelector);

            await SeedExcel<PotentialImpactfulConsiderationProductSelector>(ExcelFile.ProductSelector.FileName, ProductSelector.PotentialImpactfulProductSelector);

            await SeedExcel<AgeCreditReportProductSelector>(ExcelFile.ProductSelector.FileName, ProductSelector.AgeCreditProductSelector);

            await SeedExcel<ConstructionProductSelector>(ExcelFile.ProductSelector.FileName, ProductSelector.ConstructionTypeProductSelector);

            await SeedExcel<CashOutProductSelector>(ExcelFile.ProductSelector.FileName, ProductSelector.CashOutProductSelector);

            await SeedExcel<UnitsApartmentProductSelector>(ExcelFile.ProductSelector.FileName, ProductSelector.UnitsApartmentProductSelector);

            await SeedExcel<FacilityTypeProductSelector>(ExcelFile.ProductSelector.FileName, ProductSelector.FacilityTypeProductSelectors);

            await SeedExcel<GuidedByTypeProductSelector>(ExcelFile.ProductSelector.FileName, ProductSelector.GuidedByTypeProductSelector);

            await SeedExcel<HeedFullPointTypeProductSelector>(ExcelFile.ProductSelector.FileName, ProductSelector.HeedFullPointProductSelector);

            await SeedExcel<TitleTypeProductSelector>(ExcelFile.ProductSelector.FileName, ProductSelector.TitleTypeProductSelector);

            await SeedExcel<ServiceTypeProductSelector>(ExcelFile.ProductSelector.FileName, ProductSelector.ServiceTypeProductSelector);

            await SeedExcel<UsageTypeProductSelector>(ExcelFile.ProductSelector.FileName, ProductSelector.UsageTypeProductSelector);

            await SeedExcel<LandSizeProductSelector>(ExcelFile.ProductSelector.FileName, ProductSelector.LandSizeProductSelector);

            await SeedExcel<ButtonTypeProductSelector>(ExcelFile.ProductSelector.FileName, ProductSelector.ButtonTypeProductSelector);

            await SeedExcel<ApplicationObjectiveProductSelector>(ExcelFile.ProductSelector.FileName, ProductSelector.ApplicationObjectiveProductSelector);

            await SeedExcel<MaritalStatusProductSelector>(ExcelFile.ProductSelector.FileName, ProductSelector.MaritalStatusProductSelectors);

            #endregion

            #region Postcode suburb mapper

            await SeedPostcodeSourceData();

            #endregion

            #endregion
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    #region Helpers

    private async Task SeedPostcodes()
    {
        if (!_context.Postcodes.Any())
        {
            var postcodes = await _readExcelService.GetPostcodes();

            await _context.Postcodes.AddRangeAsync(postcodes);

            await _context.SaveChangesAsync();
        }
    }

    private async Task SeedPostcodeClassificationMapper()
    {
        if (!_context.PostcodeClassificationMapper.Any())
        {
            var postcodeClassificationMapper = await _postcodeService.GetPostcodeClassificationMapper();

            await _context.PostcodeClassificationMapper.AddRangeAsync(postcodeClassificationMapper);

            await _context.SaveChangesAsync();
        }
    }

    private async Task AdditionalFee()
    {
        if (!_context.AdditionalFees.Any())
        {
            var additionFees = await _readExcelService.GetAdditionalFee();

            await _context.AdditionalFees.AddRangeAsync(additionFees);

            await _context.SaveChangesAsync();
        }
    }

    private async Task ScenarioBuilder()
    {
        if (!_context.ScenarioBuilders.Any())
        {
            var scenarioBuilder = await _readExcelService.GetScenarioBuilder();

            await _context.ScenarioBuilders.AddRangeAsync(scenarioBuilder);

            await _context.SaveChangesAsync();
        }
    }

    private async Task DefaultFee()
    {
        if (!_context.DefaultFees.Any())
        {
            var defaultFees = await _readExcelService.GetDefaultFee();

            await _context.DefaultFees.AddRangeAsync(defaultFees);

            await _context.SaveChangesAsync();
        }
    }

    private async Task AdditionalFeeDocTypeVariations()
    {
        if (!_context.AdditionalFeeDocTypeVariations.Any())
        {
            var additionalFeeDocTypeVariations = await _readExcelService.GetAdditionalFeeDocTypeVariations();

            await _context.AdditionalFeeDocTypeVariations.AddRangeAsync(additionalFeeDocTypeVariations);

            await _context.SaveChangesAsync();
        }
    }

    private async Task SeedProductCatalogue()
    {
        if (!_context.ProductCatalogues.Any())
        {
            var productCatalogues = await _readExcelService.GetProductCatalogue();

            await _context.ProductCatalogues.AddRangeAsync(productCatalogues);

            await _context.SaveChangesAsync();
        }
    }

    private async Task SeedNumeralClassification()
    {
        if (!_context.NumeralClassifications.Any())
        {
            var numeralClassifications = await _readExcelService.GetNumeralClassification();

            await _context.NumeralClassifications.AddRangeAsync(numeralClassifications);

            await _context.SaveChangesAsync();
        }
    }

    private async Task SeedPostcodeSourceData()
    {
        if (!_context.Suburbs.Any())
        {
            var postcodeSourceData = await _readExcelService.GetPostcodeDetails();

            await _suburbService.GetSuburbDetails(postcodeSourceData);
        }
    }

    /// <summary>
    /// This method is being used to seed data from a json file to db.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    private async Task SeedJson<TEntity>() where TEntity : class
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

    #endregion
}
