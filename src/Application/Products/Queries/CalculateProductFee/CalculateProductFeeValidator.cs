namespace ProductMatrix.Application.Products.Queries.CalculateProductFee;

public class CalculateProductFeeValidator : AbstractValidator<CalculateProductFee>
{
    public CalculateProductFeeValidator()
    {
        RuleFor(x => x.ProductId)
            .GreaterThan(0)
            .WithMessage("Please provide a valid Product ID.");

        RuleFor(x => x.NumberOfDwellings)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Please provide a valid Number of dwelling.");

        RuleFor(x => x.NumberOfParticipatingEntities)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Please provide a valid Number of participating entities.");

        RuleFor(x => x.DocType)
            .NotEmpty()
            .NotEqual(string.Empty)
            .WithMessage("Please provide a valid PC DocType.");

        //RuleFor(x => x.CouncilZoningCategory)
        //    .NotEmpty()
        //    .NotEqual(string.Empty)
        //    .WithMessage("Please provide a valid CouncilZoningCategory.");

        //RuleFor(x => x.CategoryType)
        //    .NotEmpty()
        //    .NotEqual(string.Empty)
        //    .WithMessage("Please provide a valid CategoryType.");

        RuleFor(x => x.LVR)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Please provide a valid LVR.");

        RuleFor(x => x.LandSize)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Please provide a valid Land size.");

        RuleFor(x => x.LoanAmount)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Please provide a valid LoanAmount.");

        //RuleFor(x => x.PCCategory)
        //    .NotEmpty()
        //    .NotEqual(string.Empty)
        //    .WithMessage("Please provide a valid PC Category.");
    }
}
