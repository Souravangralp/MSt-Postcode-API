namespace MSt_Postcode_API.Web.Endpoints;

public class Postcodes : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .AllowAnonymous()
            .MapGet(GetPostcodeClassificationQuery, "classification")
            .MapPut(UpdatePostcodeClassification, "classifications");
    }

    [OpenApiOperation("Get location classification by postcode and state", "Get location classification by postcode and state or territory name.")]
    public async Task<PostcodeResult> GetPostcodeClassificationQuery(ISender sender, [AsParameters] GetPostcodeClassificationQuery query)
    {
        return await sender.Send(query);
    }
    
    [OpenApiOperation("Update postcode classifications", "Update postcode classification with postcode.")]
    public async Task<bool> UpdatePostcodeClassification(ISender sender, [FromBody] UpdatePostcodeClassificationCommand query)
    {
        return await sender.Send(query);
    }
}
