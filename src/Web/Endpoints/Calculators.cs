namespace ProductMatrix.Web.Endpoints;

public class Calculators : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .AllowAnonymous()
            .MapGet(CalculateLoanToValueRatio, "CalculateLvr")
            .MapGet(CalculateLandsizeIntoHectare, "CalculateLandSize");
    }

    [OpenApiOperation("Calculate loan to value ratio", "Get loan to value ratio based on security amount and loan amount.")]
    public async Task<string> CalculateLoanToValueRatio(ISender sender, [AsParameters] CalculateLoanToValueRatio query)
    {
        return await sender.Send(query);
    }
    
    [OpenApiOperation("Calculate land size to hectare", "Get land size calculated in hectares from meters square and acres. (1 denotes to meter squares whereas 2 denotes to acres)")]
    public async Task<string> CalculateLandsizeIntoHectare(ISender sender, [AsParameters] CalculateLandsizeIntoHectare query)
    {
        return await sender.Send(query);
    }
}
