namespace ProductMatrix.Application.Products.Queries.GetProductWithPostcode;

public class GetProductWithPostcodeValidator : AbstractValidator<GetProductWithPostcode>
{
    public GetProductWithPostcodeValidator()
    {
        //RuleFor(x => x.Postcode)
        //    .MinimumLength(4).WithMessage("Postcode should be minimum 4 digits long")
        //    .MaximumLength(5).WithMessage("Postcode should be maximum 5 digits long");

        //RuleFor(x => x.Postcode).Matches("^[0-9]+$")
        //    .WithMessage("Postcode should not contain alphanumeric value or special characters.");

        RuleFor(x => x.Postcode)
            .MinimumLength(4).WithMessage("Postcode should be minimum 4 digits long")
            .MaximumLength(4).WithMessage("Postcode should be maximum 4 digits long")
            .When(x => !string.IsNullOrEmpty(x.Postcode));

        RuleFor(x => x.Postcode)
            .Matches("^[0-9]+$")
            .WithMessage("Postcode should not contain alphanumeric value or special characters.")
            .When(x => !string.IsNullOrEmpty(x.Postcode));
    }
}
