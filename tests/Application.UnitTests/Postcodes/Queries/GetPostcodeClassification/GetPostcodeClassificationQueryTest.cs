namespace MSt_Postcode_API.Application.UnitTests.Postcodes.Queries.GetPostcodeClassification;

public class GetPostcodeClassificationQueryTest
{
    #region Fields

    private readonly GetPostcodeClassificationQueryHandler _getPostcodeClassificationQueryHandler;
    private readonly CancellationToken _cancellationToken = default;

    #endregion

    #region Ctor

    public GetPostcodeClassificationQueryTest()
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



        _getPostcodeClassificationQueryHandler = new(context: mockContext.Object);
    }

    #endregion

    #region Methods

    [Test]
    public async Task GetPostcodeClassification_WithValidPostcodeClassificationParameterInfo_ShouldReturnPostcodeResult()
    {
        //Arrange
        ArrangeRequiredParameter(getPostcodeClassificationQuery: out GetPostcodeClassificationQuery getPostcodeClassificationQuery, isValidData: true);

        //Act
        var result = await _getPostcodeClassificationQueryHandler.Handle(getPostcodeClassificationQuery, _cancellationToken);

        //Assert
        // result.Exception is null only when Task is completed successfully
        PostcodeResult expectedResult = new() { Capital = "Excluded", PcCategory = "Unlisted", ISHighDensity = false };
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Test]
    public async Task GetPostcodeClassification_WithInvalidPostcodeClassificationParameterInfo_ShouldThrowException()
    {
        //Arrange
        ArrangeRequiredParameter(getPostcodeClassificationQuery: out GetPostcodeClassificationQuery getPostcodeClassificationQuery);

        bool isExceptionThrown = false;

        ////Act
        try { await _getPostcodeClassificationQueryHandler.Handle(getPostcodeClassificationQuery, _cancellationToken); }
        catch (Exception) { isExceptionThrown = true; }

        ////Assert
        Assert.IsTrue(isExceptionThrown);
    }

    #region Helper Methods

    private static void ArrangeRequiredParameter(out GetPostcodeClassificationQuery getPostcodeClassificationQuery, bool isValidData = false)
    {
        getPostcodeClassificationQuery = isValidData is true
            ? new() { Suburb = "sydney", StateORTerritoryName = "ACT", Postcode = "0001" }
            : new() { Suburb = "wrong sydney", StateORTerritoryName = "Wrong ACT", Postcode = "" };     
    }

    #endregion

    #endregion
}
