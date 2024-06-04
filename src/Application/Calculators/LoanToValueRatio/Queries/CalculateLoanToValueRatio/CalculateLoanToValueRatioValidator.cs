namespace ProductMatrix.Application.Calculators.LoanToValueRatio.Queries.CalculateLoanToValueRatio;

public class CalculateLoanToValueRatioValidator : AbstractValidator<CalculateLoanToValueRatio>
{
    public CalculateLoanToValueRatioValidator()
    {
        RuleFor(x => x.LoanAmount)
            .GreaterThan(0)
            .WithMessage("LoanAmount should be greater than 0.");

        RuleFor(x => x.SecurityAmount)
            .GreaterThan(0)
            .WithMessage("SecurityAmount should be greater than 0.");

        RuleFor(x => x)
            .Must(x => x.SecurityAmount >= x.LoanAmount)
            .WithMessage("SecurityAmount should be greater than LoanAmount.");
    }
}
