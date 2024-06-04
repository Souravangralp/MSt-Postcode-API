namespace ProductMatrix.Application.Postcodes.Queries.GetPostcodeResult;

public class GetPostcodeResultValidator : AbstractValidator<GetPostcodeResult>
{
    public GetPostcodeResultValidator()
    {
        RuleFor(x => x.StateORTerritoryName)
            .NotEmpty()
            .NotEqual(string.Empty)
            .WithMessage("Please provide a valid State or Territory name.");

        RuleFor(x => x.Postcode)
            .NotEmpty()
            .NotEqual(string.Empty)
            .WithMessage("Please provide a valid Postcode.");
    }
}
