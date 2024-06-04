namespace MSt_Postcode_API.Application.Postcodes.Queries.GetPostcodeClassification;

public class GetPostcodeClassificationQueryValidator : AbstractValidator<GetPostcodeClassificationQuery>
{
    public GetPostcodeClassificationQueryValidator()
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
