namespace ProductMatrix.Web.Endpoints;

public class Postcodes : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .AllowAnonymous()
            .MapGet(GetCategoryWithPostCode, "Category")
            .MapPut(UpdatePostcodeClassification, "Update");
    }

    [OpenApiOperation("Get location category by postcode and state", "Get location category by postcode and state or territory name.")]
    public async Task<PostcodeResult> GetCategoryWithPostCode(ISender sender, [AsParameters] GetPostcodeResult query)
    {
        return await sender.Send(query);
    }
    
    [OpenApiOperation("Update postcode classifications", "Update postcode classification with postcode.")]
    public async Task<bool> UpdatePostcodeClassification(ISender sender, [FromBody] UpdatePostcodeClassificationCommand query)
    {
        return await sender.Send(query);
    }
}
