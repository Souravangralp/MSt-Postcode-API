using Microsoft.AspNetCore.Mvc;
using MSt_Postcode_API.Application.Common.Models;
using MSt_Postcode_API.Application.Postcodes.Commands.UpdatePostcodeClassification;
using MSt_Postcode_API.Application.Postcodes.Queries.GetPostcodeClassification;
using NSwag.Annotations;

namespace MSt_Postcode_API.Web.Endpoints;

public class Postcodes : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .AllowAnonymous()
            .MapGet(GetPostcodeClassificationQuery, "Get postcode classifications")
            .MapPut(UpdatePostcodeClassification, "Update postcode classifications");
    }

    [OpenApiOperation("Get location category by postcode and state", "Get location category by postcode and state or territory name.")]
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
