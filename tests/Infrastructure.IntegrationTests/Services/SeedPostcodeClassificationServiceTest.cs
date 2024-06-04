using FluentAssertions;
using MSt_Postcode_API.Application.Common.Interfaces;
using MSt_Postcode_API.Application.Common.Models;

namespace MSt_Postcode_API.Infrastructure.IntegrationTests.Services;

public class SeedPostcodeClassificationServiceTest
{
    #region Fields

    private readonly SeedPostcodeClassificationService _seedPostcodeClassificationService;

    #endregion

    #region Ctor

    public SeedPostcodeClassificationServiceTest()
    {
        var mockExcelFileService = new Mock<IExcelFileService>();

        mockExcelFileService.Setup(c => c.GetExcelData<PostcodeClassificationDto>("Postcode.xlsx", "PostcodeClassificationMapper")).ReturnsAsync(new List<PostcodeClassificationDto>(){
            new(){ RangeFrom = 1, RangeTo = 5, Classification1 = 1, Classification2 = 2 }});

        _seedPostcodeClassificationService = new(excelFileService: mockExcelFileService.Object);
    }

    #endregion

    #region Methods

    [Test]
    public async Task GetSuburbs_WithValidSheetName_ShouldReturnPostcodeResult()
    {
        //Arrange
        ArrangeRequiredParameter(out string fileName, out string sheetName, isValidData: true);

        //Act
        var result = await _seedPostcodeClassificationService.GetAll(fileName, sheetName);

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
        try { await _seedPostcodeClassificationService.GetAll(fileName, sheetName); }
        catch (Exception) { isExceptionThrown = true; }

        //Assert
        Assert.IsTrue(isExceptionThrown);
    }

    #region Helper Methods

    private static void ArrangeRequiredParameter(out string fileName, out string sheetName, bool isValidData = false)
    {
        fileName = isValidData is true
            ? "Postcode.xlsx"
            : "test";

        sheetName = isValidData is true
           ? "PostcodeClassificationMapper"
           : "test";
    }

    #endregion

    #endregion
}
