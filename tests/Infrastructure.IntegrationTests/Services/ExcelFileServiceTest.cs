using FluentAssertions;

namespace MSt_Postcode_API.Infrastructure.IntegrationTests.Services;

public class ExcelFileServiceTest
{
    #region Fields

    private readonly ExcelFileService _excelFileService;

    #endregion

    #region Ctor

    public ExcelFileServiceTest()
    {
        DbContextOptions<ApplicationDbContext> dbContextOptions = new DbContextOptions<ApplicationDbContext>();
        var mockContext = new Mock<ApplicationDbContext>(dbContextOptions);

        mockContext.Setup(c => c.Set<State>())
                 .ReturnsDbSet(MockEntityExtension.MockDbSet(new List<State>()).Object);

        _excelFileService = new(context: mockContext.Object);
    }

    #endregion

    #region Methods

    [Test]
    public async Task GetExcelData_WithValidSheetName_ShouldReturnPostcodeResult()
    {
        //Arrange
        ArrangeRequiredParameter(out string fileName, out string sheetName, isValidData: true);

        //Act
        var result = await _excelFileService.GetExcelData<PostcodeClassificationMapper>(fileName, sheetName);

        //Assert
        result.Should().NotBeNullOrEmpty();
    }

    [Test]
    public async Task GetExcelData_WithInvalidSheetName_ShouldThrowException()
    {
        //Arrange
        ArrangeRequiredParameter(out string fileName, out string sheetName, isValidData: false);

        bool isExceptionThrown = false;

        //Act
        try { await _excelFileService.GetExcelData<PostcodeClassificationMapper>(fileName, sheetName); }
        catch (Exception) { isExceptionThrown = true; }

        //Assert
        Assert.IsTrue(isExceptionThrown);
    }

    [Test]
    public async Task GetJsonData_WithValidEntityName_ShouldNotThrowException()
    {
        //Arrange
        SetCurrentDirectory();
        bool isExceptionThrown = false;

        //Act
        try { await _excelFileService.SeedJson<Domain.Entities.State>(); }
        catch (Exception) { isExceptionThrown = true; }

        //Assert
        Assert.IsFalse(isExceptionThrown);
    }

    [Test]
    public async Task GetJsonData_WithInvalidValidEntityName_ShouldNotThrowException()
    {
        //Arrange
        SetCurrentDirectory();
        bool isExceptionThrown = false;

        //Act
        try { await _excelFileService.SeedJson<PostcodeClassificationMapper>(); }
        catch (Exception) { isExceptionThrown = true; }

        //Assert
        Assert.IsTrue(isExceptionThrown);
    }

    #region Helper Methods

    private static void ArrangeRequiredParameter(out string fileName, out string sheetName, bool isValidData = false)
    {
        SetCurrentDirectory();

        fileName = isValidData is true
            ? ExcelFile.Postcode.FileName
            : "test";

        sheetName = isValidData is true
           ? ExcelSheetName.PostcodeClassificationMapper.SheetName
           : "test";
    }

    private static void SetCurrentDirectory()
    {
        var directory = Directory.GetCurrentDirectory();
        directory = Path.GetDirectoryName(directory);
        directory = Path.GetDirectoryName(directory);
        directory = Path.GetDirectoryName(directory);
        directory = Path.GetDirectoryName(directory);
        directory = Path.GetDirectoryName(directory);
        directory = Path.Combine(directory ?? "", "src/web");
        Directory.SetCurrentDirectory(directory);
    }

    #endregion

    #endregion
}
