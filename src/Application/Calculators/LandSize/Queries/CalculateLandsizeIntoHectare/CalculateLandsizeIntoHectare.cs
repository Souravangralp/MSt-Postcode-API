namespace ProductMatrix.Application.Calculators.LandSize.Queries.CalculateLandsizeIntoHectare;

public class CalculateLandsizeIntoHectare : IRequest<string>
{
    public required double LandSize { get; set; }

    [DeniedValues(LandConversionTypes.Acres)]
    public LandConversionTypes ConversionTypeId { get; set; }
}

public class CalculateLandsizeIntoHectareHandler : IRequestHandler<CalculateLandsizeIntoHectare, string>
{
    public async Task<string> Handle(CalculateLandsizeIntoHectare request, CancellationToken cancellationToken)
    {
        switch (request.ConversionTypeId)
        {
            case LandConversionTypes.MeterSquare:
                return await Task.FromResult(CalculatorsUtility.SquareMetersToHectares(request.LandSize).ToString("F2"));
            case LandConversionTypes.Acres:
                return await Task.FromResult(CalculatorsUtility.AcresToHectares(request.LandSize).ToString("F2"));
            default:
                throw new NotImplementedException();
        }
    }
}
