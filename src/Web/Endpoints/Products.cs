namespace ProductMatrix.Web.Endpoints;

public class Products : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetCategories, "Category")
            .MapGet(GetProducts)
            .MapGet(CalculateProductFee, "CalculateFee")
            .MapDelete(DeleteProductSelectorCommand, "DeleteProductSelectorCommand")
            .MapPut(UpdateProductSelectorCommand, "UpdateProductSelectorCommand");
    }

    [OpenApiOperation("Get all product categories", "Get a list of product categories.")]
    public async Task<TextValuePair[]> GetCategories(ISender sender, [AsParameters] GetAllProductCategories query)
    {
        return await sender.Send(query);
    }

    [OpenApiOperation("Get a product by product category id and loanAmount", "Get a product by product category id and loanAmount.")]
    public async Task<TextValuePair[]> GetProducts(ISender sender, [AsParameters] GetProductWithCategoryId query)
    {
        return await sender.Send(query);
    }

    [OpenApiOperation("Calculate product fee", "Get a precise calculated product fee based on LoanAmount, LVR, ProductId, LocationCategoryID, DocTypeId, etc.")]
    public async Task<ProductFeeResult> CalculateProductFee(ISender sender, [AsParameters] CalculateProductFee query)
    {
        return await sender.Send(query);
    }

    [OpenApiOperation("Delete rule", "Delete a rule based on filter and ruleID")]
    public async Task<bool> DeleteProductSelectorCommand(ISender sender, [AsParameters] DeleteRuleCommand command) 
    {
        return await sender.Send(command);
    }
    
    [OpenApiOperation("Update filter", "Update the filter with its FilterId")]
    public async Task<bool> UpdateProductSelectorCommand(ISender sender, [AsParameters] UpdateRuleCommand command) 
    {
        return await sender.Send(command);
    }
}
