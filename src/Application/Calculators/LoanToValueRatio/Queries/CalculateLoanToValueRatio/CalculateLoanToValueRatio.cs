namespace ProductMatrix.Application.Calculators.LoanToValueRatio.Queries.CalculateLoanToValueRatio;

public record CalculateLoanToValueRatio : IRequest<string>
{
    public required double LoanAmount { get; set; }

    public required double SecurityAmount { get; set; }
}

public class CalculateLoanToValueRatioHandler : IRequestHandler<CalculateLoanToValueRatio, string>
{
    public async Task<string> Handle(CalculateLoanToValueRatio request, CancellationToken cancellationToken)
    {
        double lvr = request.LoanAmount / request.SecurityAmount * 100.0;

        return await Task.FromResult(lvr.ToString("F2") + "%");
    }
}
