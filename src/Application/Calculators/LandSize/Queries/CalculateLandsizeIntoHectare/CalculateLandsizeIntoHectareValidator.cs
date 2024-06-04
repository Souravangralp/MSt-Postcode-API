namespace ProductMatrix.Application.Calculators.LandSize.Queries.CalculateLandsizeIntoHectare;

public class CalculateLandsizeIntoHectareValidator : AbstractValidator<CalculateLandsizeIntoHectare>
{
    public CalculateLandsizeIntoHectareValidator()
    {
        RuleFor(x => x.LandSize)
            .GreaterThan(0)
            .WithMessage("Please provide a valid land size.");
    }
}
