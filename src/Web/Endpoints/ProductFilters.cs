using ProductMatrix.Application.Common.Models.ProductFilters;
using ProductMatrix.Application.ProductFilters.Commands.Create;
using ProductMatrix.Application.ProductFilters.Queries.GetAllCouncilZonings;
using ProductMatrix.Application.ProductFilters.Queries.GetAllFiltersWithCouncilZoning;

namespace ProductMatrix.Web.Endpoints;

public class ProductFilters : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.MapPost(CreateRuleCommand, "CreateRuleCommand")
            .MapPost(ProductFilterQuery, "ProductFilterQuery");
            //.MapGet(GetAllCouncilZoningsQuery, "GetAllCouncilZoningsQuery")
            //.MapGet(GetFiltersWithCouncilZoningQuery, "GetFiltersWithCouncilZoningQuery")
            //.MapGet(GetAllRulesWithFilterIDQuery, "GetAllRulesWithFilterIDQuery")
            //.MapDelete(DeleteRuleCommand, "DeleteRuleCommand")
            //.MapPut(UpdateRuleCommand, "UpdateRuleCommand");
    }

    [OpenApiOperation("Create a rule", "Create a new rule within a Filter")]
    public async Task<bool> CreateRuleCommand(ISender sender, [AsParameters] CreateRuleCommand command)
    {
        return await sender.Send(command);
    }

    [OpenApiOperation("Get product", "Get a product based on different filter.")]
    public async Task<TextValuePair[]> ProductFilterQuery(ISender sender, [FromBody] ProductFilterQuery query)
    {
        return await sender.Send(query);
    }

    [OpenApiOperation("Get a list of council Zonings", "Get a list of council Zonings.")]
    public async Task<TextValuePair[]> GetAllCouncilZoningsQuery(ISender sender, [AsParameters] GetAllCouncilZoningsQuery query)
    {
        return await sender.Send(query);
    }

    [OpenApiOperation("Get a list of filters", "Get a list of filters.")]
    public async Task<RulesFilterDto[]> GetFiltersWithCouncilZoningQuery(ISender sender, [AsParameters] GetFiltersWithCouncilZoningQuery query)
    {
        return await sender.Send(query);
    }

    [OpenApiOperation("Get a list of filters", "Get a list of filters.")]
    public async Task<Application.Common.Interfaces.ICollectionResult> GetAllRulesWithFilterIDQuery(ISender sender, [AsParameters] GetAllRulesWithFilterIDQuery query)
    {
        return await sender.Send(query);
    }

    [OpenApiOperation("Delete rule", "Delete a rule based on filter and ruleID")]
    public async Task<bool> DeleteRuleCommand(ISender sender, [AsParameters] DeleteRuleCommand command)
    {
        return await sender.Send(command);
    }

    [OpenApiOperation("Update filter", "Update the filter with its FilterId")]
    public async Task<bool> UpdateRuleCommand(ISender sender, [AsParameters] UpdateRuleCommand command)
    {
        return await sender.Send(command);
    }
}
