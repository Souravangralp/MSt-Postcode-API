using MSt_Postcode_API.Application.Postcodes.Commands.UpdatePostcodeClassification;

namespace MSt_Postcode_API.Application.UnitTests.Postcodes.Commands.UpdatePostcodeClassification;

public class UpdatePostcodeClassificationCommandTest
{
    #region Fields

    private readonly UpdatePostcodeClassificationCommandHandler _updatePostcodeClassificationCommandHandler;
    private readonly CancellationToken _cancellationToken = default;

    #endregion

    #region Ctor

    public UpdatePostcodeClassificationCommandTest()
    {
        var mockContext = new Mock<IApplicationDbContext>();

        List<Postcode> postcodes = [];

        postcodes.Add(new()
        {
            Code = "0001",
            Postcode_SuburbID = 1
        });

        mockContext.Setup(c => c.States).ReturnsDbSet(MockEntityExtension.MockDbSet(entities: new List<Domain.Entities.State> {
                                                                    new() { ID = 1, Name = "Australia capital territory", AbbreviatedName = "ACT" , ISTerritory = true } }).Object);

        mockContext.Setup(c => c.Suburbs).ReturnsDbSet(MockEntityExtension.MockDbSet(entities: new List<Suburb> {
                                                                    new() { ID = 1, Name = "Sydney", Suburb_StateID = 1 , Postcodes = postcodes } }).Object);

        mockContext.Setup(c => c.PostcodeSuburbMapper).ReturnsDbSet(MockEntityExtension.MockDbSet(entities: new List<PostcodeSuburbMapper> {
                                                                    new() { ID = 1, PostcodeSuburbMapper_PostcodeID = 1, PostcodeSuburbMapper_SuburbID = 1 } }).Object);

        mockContext.Setup(c => c.PostcodeClassifications).ReturnsDbSet(MockEntityExtension.MockDbSet(entities: new List<PostcodeClassification> {
                                                                    new() { ID = 1, Name = "test", Value = "test" } }).Object);

        mockContext.Setup(c => c.PostcodeClassificationMapper).ReturnsDbSet(MockEntityExtension.MockDbSet(entities: new List<PostcodeClassificationMapper> {
                                                                    new() { ID = 1, PostcodeClassificationMapper_PostcodeClassificationID = 1, PostcodeClassificationMapper_PostcodeID = 1 } }).Object);

        mockContext.Setup(c => c.Postcodes).ReturnsDbSet(MockEntityExtension.MockDbSet(entities: new List<Postcode> {
                                                                    new() { ID = 1, Code = "0001" } }).Object);



        _updatePostcodeClassificationCommandHandler = new(context: mockContext.Object);
    }

    #endregion

    #region Methods

    [Test]
    public async Task UpdatePostcodeClassification_WithValidPostcodeClassificationParameter_ShouldReturnTrue()
    {
        //Arrange
        ArrangeRequiredParameter(updatePostcodeClassificationCommand: out UpdatePostcodeClassificationCommand updatePostcodeClassificationCommand, isValidData: true);

        //Act
        var result = await _updatePostcodeClassificationCommandHandler.Handle(updatePostcodeClassificationCommand, _cancellationToken);

        //Assert
        // result.Exception is null only when Task is completed successfully
        Assert.That(result, Is.EqualTo(true));
    }

    [Test]
    public async Task UpdatePostcodeClassification_WithInvalidPostcodeClassificationParameter_ShouldThrowException()
    {
        //Arrange
        ArrangeRequiredParameter(updatePostcodeClassificationCommand: out UpdatePostcodeClassificationCommand updatePostcodeClassificationCommand);

        bool isExceptionThrown = false;

        ////Act
        try { await _updatePostcodeClassificationCommandHandler.Handle(updatePostcodeClassificationCommand, _cancellationToken); }
        catch (Exception) { isExceptionThrown = true; }

        ////Assert
        Assert.IsTrue(isExceptionThrown);
    }

    #region Helper Methods

    private static void ArrangeRequiredParameter(out UpdatePostcodeClassificationCommand updatePostcodeClassificationCommand, bool isValidData = false)
    {
        updatePostcodeClassificationCommand = isValidData is true
            ? new() { Postcode = "0001", PCCategory = "Category 1", StandardAndPoor = "Metro", HighSecurity = ["HighDensity", "SelectedNonMetro"] }
            : new() { Postcode = "0002", PCCategory = "Category 4", StandardAndPoor = "Metro", HighSecurity = ["HighDensity", "SelectedNonMetro"] };
    }

    #endregion

    #endregion
}
