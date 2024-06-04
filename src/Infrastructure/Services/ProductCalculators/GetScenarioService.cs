using ProductMatrix.Application.Common.Interfaces.ProductCalculators;
using ProductMatrix.Application.Products.Queries.CalculateProductFee;

namespace ProductMatrix.Infrastructure.Services.ProductCalculators;

public class GetScenarioService : IGetScenarioService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly IEntityService _entityService;

    #endregion

    #region Ctor

    public GetScenarioService(
        IApplicationDbContext context,
        IEntityService entityService)
    {
        _context = context;
        _entityService = entityService;
    }

    #endregion

    #region Methods

    public async Task<string> GetFormula(CalculateProductFee request)
    {
        int? relocationServicingId = string.IsNullOrWhiteSpace(request.RelocationServicingCategory) ? null : _entityService.GetByName<RelocationServicing>(request.RelocationServicingCategory ?? "").Result.ID;
        int? vacantLandId = string.IsNullOrWhiteSpace(request.VacantLandCategory) ? null : _entityService.GetByName<VacantLandCategory>(request.VacantLandCategory ?? "").Result.ID;

        return await _context.ScenarioBuilders
                    .Where(sb => sb.ISNaturalPerson == request.ISNaturalPerson &&
                           sb.ISOwnerOccupied == request.ISOwnerOccupied &&
                           sb.ISHighDensity == request.ISHighDensity &&
                           sb.ISSelectedMetro == request.ISSelectedNonMetro &&
                           sb.ScenarioBuilder_RelocationServicingID == relocationServicingId &&
                           sb.ScenarioBuilder_VacantLandCategoryID == vacantLandId &&
                           (sb.PCCategory != null && sb.PCCategory.Replace(" ", "").ToLower() == request.PCCategory.Replace(" ", "").ToLower()) &&
                           (sb.CouncilZoning != null && sb.CouncilZoning.Replace(" ", "").ToLower() == request.CouncilZoningCategory.Replace(" ", "").ToLower()) &&
                           (sb.CategoryType != null && sb.CategoryType.Replace(" ", "").ToLower() == request.CategoryType.Replace(" ", "").ToLower()))
                    .Select(sb => sb.FormulaType)
                    .FirstOrDefaultAsync() ?? string.Empty;
    }

    #region Helpers

    #endregion

    #endregion
}
