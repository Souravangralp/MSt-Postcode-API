﻿namespace MSt_Postcode_API.Infrastructure.IntegrationTests.Services;

public class SeedPostcodeServiceTest
{
    #region Fields

    private readonly SeedPostcodeService _seedPostcodeServiceTest;

    #endregion

    #region Ctor

    public SeedPostcodeServiceTest()
    {
        var mockContext = new Mock<IApplicationDbContext>();
        var mockExcelFileService = new Mock<IExcelFileService>();

        mockContext.Setup(c => c.States).ReturnsDbSet(MockEntityExtension.MockDbSet(entities: new List<Domain.Entities.State> {
                                                                    new() { ID = 1, Name = "Australia capital territory", AbbreviatedName = "ACT" , ISTerritory = true } }).Object);

        mockExcelFileService.Setup(c => c.GetExcelData<SuburbDetail>("Postcode.xlsx", "PostcodeClassificationMapper")).ReturnsAsync(new List<SuburbDetail>(){
            new(){ ID = 1, Postcode = "0001", Suburb = "Sydney", StateCode = "ACT" }});

        _seedPostcodeServiceTest = new(context: mockContext.Object, excelFileService: mockExcelFileService.Object);
    }

    #endregion

    #region Methods

    [Test]
    public async Task GetSuburbs_WithValidSheetName_ShouldReturnPostcodeResult()
    {
        //Arrange
        ArrangeRequiredParameter(out string fileName, out string sheetName, isValidData: true);

        //Act
        var result = await _seedPostcodeServiceTest.GetSuburbs(fileName, sheetName);

        //Assert
        result.Should().NotBeNullOrEmpty();
    }

    [Test]
    public async Task GetSuburbs_WithInvalidSheetName_ShouldThrowException()
    {
        //Arrange
        ArrangeRequiredParameter(out string fileName, out string sheetName, isValidData: false);

        bool isExceptionThrown = false;

        //Act
        try { await _seedPostcodeServiceTest.GetSuburbs(fileName, sheetName); }
        catch (Exception) { isExceptionThrown = true; }

        //Assert
        Assert.IsTrue(isExceptionThrown);
    }

    [Test]
    public async Task GetPostcodeSuburbMapper_WithValidSheetName_ShouldNotThrowException()
    {
        //Arrange
        ArrangeRequiredParameter(out string fileName, out string sheetName, isValidData: true);

        //Act
        var result = await _seedPostcodeServiceTest.GetPostcodeSuburbMapper(fileName, sheetName);

        //Assert
        result.Should().NotBeNullOrEmpty();
    }

    [Test]
    public async Task GetPostcodeSuburbMapper_WithInValidSheetName_ShouldNotThrowException()
    {
        //Arrange
        ArrangeRequiredParameter(out string fileName, out string sheetName, isValidData: false);

        bool isExceptionThrown = false;

        //Act
        try { await _seedPostcodeServiceTest.GetPostcodeSuburbMapper(fileName, sheetName); }
        catch (Exception) { isExceptionThrown = true; }

        //Assert
        Assert.IsTrue(isExceptionThrown);
    }

    [Test]
    public async Task GetGetPostcodes_ShouldReturnExpectedResult()
    {
        //Act
        var result = await _seedPostcodeServiceTest.GetPostcodes();

        //Assert
        Assert.That(result.Count, Is.EqualTo(10001));
    }

    [Test]
    public async Task GetGetPostcodes_ShouldReturnUnExpectedResult()
    {
        //Act
        var result = await _seedPostcodeServiceTest.GetPostcodes();

        //Assert
        Assert.That(result.Count, !Is.EqualTo(1000));
    }

    #region Helper Methods

    private static void ArrangeRequiredParameter(out string fileName, out string sheetName, bool isValidData = false)
    {
        fileName = isValidData is true
            ? ExcelFile.Postcode.FileName
            : "test";

        sheetName = isValidData is true
           ? ExcelSheetName.PostcodeClassificationMapper.SheetName
           : "test";
    }

    #endregion

    #endregion
}
