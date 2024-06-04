namespace ProductMatrix.Application.Products.Queries.GetProductWithCategory;

public class GetProductWithCategoryIdValidator : AbstractValidator<GetProductWithCategoryId>
{
    public GetProductWithCategoryIdValidator()
    {
        //RuleFor(x => x.ProductScenarioBuilder.ProductCategoryID)
        //   .NotEqual(0)
        //   .WithMessage("Please provide a valid category id.");

        //RuleFor(x => x.ProductScenarioBuilder.LoanAmount)
        //    .Must(x => x > 1)
        //    .WithMessage("Please provide a valid loan amount.");
    }
}
