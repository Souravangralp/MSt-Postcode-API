namespace ProductMatrix.Application.Products.Queries.CalculateProductFee;

public record CalculateProductFee : IRequest<ProductFeeResult>
{
    public required int ProductId { get; set; }

    public string? VacantLandCategory { get; set; }

    public string? RelocationServicingCategory { get; set; }

    public required string CouncilZoningCategory { get; set; }

    public required int NumberOfDwellings { get; set; }

    public required int NumberOfParticipatingEntities { get; set; }

    public required string DocType { get; set; }

    public required string CategoryType { get; set; }

    public required double LVR { get; set; }

    public required double LandSize { get; set; }

    public required double LoanAmount { get; set; }

    public required string PCCategory { get; set; }

    [DefaultValue(false)]
    public bool ISOwnerOccupied { get; set; }

    [DefaultValue(false)]
    public bool ISNaturalPerson { get; set; }

    [DefaultValue(false)]
    public bool ISHighDensity { get; set; }

    [DefaultValue(false)]
    public bool ISSelectedNonMetro { get; set; }
}

public class CalculateProductFeeHandler : IRequestHandler<CalculateProductFee, ProductFeeResult>
{
    #region Fields

    private readonly ICalculatorService _calculatorService;
    private readonly IGetScenarioService _getScenarioService;

    #endregion

    #region Ctor

    public CalculateProductFeeHandler(
        ICalculatorService calculatorService,
        IGetScenarioService getScenarioService)
    {
        _calculatorService = calculatorService;
        _getScenarioService = getScenarioService;
    }

    #endregion

    #region Methods

    public async Task<ProductFeeResult> Handle(CalculateProductFee request, CancellationToken cancellationToken)
    {
        var formula = await _getScenarioService.GetFormula(request);

        return await _calculatorService.CalculateProductFee(formula, request);
    }

    #endregion

    #region Helpers

    //private async Task<ProductFeeResult> GetAdditionalFee(CalculateProductFee request, ProductFee productFee)
    //{
    //    var result = _mapper.Map<ProductFeeResult>(productFee);

    //    var lvr = await _entityService.Get<LoanToValueRatio>(productFee.ProductFee_LoanToValueRatioID ?? 0);
    //    result.MaximumLVR = lvr.To;
    //    result.LoanAmount = request.LoanAmount;

    //    result.ApplicationFee += CalculatorsUtility.GetAdditionalFeeForDwelling(request.NumberOfDwellings);
    //    result.ApplicationFee += CalculatorsUtility.GetAdditionalFeeForParticipients(request.NumberOfParticipatingEntities);

    //    var additionalApplicationFee = _context.AdditionalFees.FirstOrDefault(x => x.LoanAmountFrom <= request.LoanAmount && x.LoanAmountTo >= request.LoanAmount);

    //    if (additionalApplicationFee is not null)
    //    {
    //        result.ApplicationFee = CalculatorsUtility.CalculateApplicationFeeWithIncrementRate(result.ApplicationFee.RoundOff(), additionalApplicationFee.IncrementRate);
    //    }

    //    return result;
    //}

    //private async Task<ProductFee> GetProductFee(CalculateProductFee request, CancellationToken cancellationToken)
    //{
    //    int councilZoningCategoryId = _entityService.GetByName<CouncilZoningCategory>(request.CouncilZoningCategory).Result.ID;
    //    int? vacantLandCategoryId = string.IsNullOrWhiteSpace(request.VacantLandCategory) ? null :  _entityService.GetByName<VacantLandCategory>(request.VacantLandCategory ?? string.Empty).Result.ID;
    //    int docTypeId = _entityService.GetByName<DocType>(request.DocType ?? string.Empty).Result.ID;
    //    int categoryTypeId = _entityService.GetByName<CategoryType>(request.CategoryType ?? string.Empty).Result.ID;

    //    var lvrId = await _calculateRangeService.GetLVR(request.LVR);

    //    var productFees = await _context.ProductFees
    //        .Where(product => product.ProductFee_ProductID == request.ProductId &&
    //                product.ProductFee_LoanToValueRatioID == lvrId)
    //        .ToListAsync(cancellationToken);

    //    return productFees.Where(x => x.ProductFee_CategoryTypeID == categoryTypeId && x.ProductFee_DocTypeID == docTypeId &&
    //                      x.ProductFee_VacantLandCategoryID == vacantLandCategoryId &&
    //                      x.ProductFee_CouncilZoningCategoryID == councilZoningCategoryId &&
    //                      x.LandSize == request.LandSize && x.PCCategory.Replace(" ", "").ToLower() == request.PCCategory.Replace(" ", "").ToLower() &&
    //                      x.ISOwnerOccupied == request.ISOwnerOccupied && x.ISNaturalPerson == request.ISNaturalPerson &&
    //                      x.ISHighDensity == request.ISHighDensity && x.ISSelectedNonMetro == request.ISSelectedNonMetro)
    //        .FirstOrDefault() ?? throw new NotFoundException($"{request.ProductId}", nameof(Product));
    //}

    #endregion
}
