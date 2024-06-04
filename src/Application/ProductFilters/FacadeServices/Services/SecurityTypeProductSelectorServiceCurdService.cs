using ProductMatrix.Domain.Constants;

namespace ProductMatrix.Application.ProductFilters.FacadeServices.Services;

public class SecurityTypeProductSelectorServiceCurdService : ISecurityTypeProductSelectorServiceCurdService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly IGeneralLookUpService _generalLookUpService;
    private readonly IEntityService _entityService;

    #endregion

    #region Ctor

    public SecurityTypeProductSelectorServiceCurdService(IApplicationDbContext context,
        IGeneralLookUpService generalLookUpService,
        IEntityService entityService)
    {
        _context = context;
        _generalLookUpService = generalLookUpService;
        _entityService = entityService;
    }

    #endregion

    #region Methods

    public async Task<bool> Create(CreateRuleCommand request)
    {
        var securityTypeDto = JsonConvert.DeserializeObject<Common.Models.ProductFilters.SecurityTypeDto>(request.Model.ToString() ?? "") ?? throw new InvalidCastException();

        var generalLookUpId = await _generalLookUpService.GetGeneralLookUpID(GeneralLookUps.SecurityType, securityTypeDto.SecurityType);

        var existingEntry = await _context.SecurityTypeProductSelectors.Where(stps => stps.SecurityTypeProductSelector_GeneralLookUpID == generalLookUpId &&
                                                                                      stps.SecurityTypeProductSelector_CouncilZoningTypeID == request.CouncilZoningTypeID &&
                                                                                       stps.SecurityTypeProductSelector_ProductID == securityTypeDto.Product.Key)
                                                                        .FirstOrDefaultAsync();

        if (existingEntry != null) { throw new AlreadyExistsException($"{securityTypeDto.Product.Value}"); }

        var securityTypeProductSelector = new SecurityTypeProductSelector()
        {
            SecurityTypeProductSelector_CouncilZoningTypeID = request.CouncilZoningTypeID,
            SecurityTypeProductSelector_ProductID = securityTypeDto.Product.Key,
            SecurityTypeProductSelector_GeneralLookUpID = generalLookUpId
        };

        await _context.SecurityTypeProductSelectors.AddAsync(securityTypeProductSelector);

        await _context.SaveChangesAsync(CancellationToken.None);

        return true;
    }

    public async Task<ICollectionResult> GetAll(GetAllRulesWithFilterIDQuery request)
    {
        var collection = await _context.SecurityTypeProductSelectors.Where(stps => stps.SecurityTypeProductSelector_CouncilZoningTypeID == request.CouncilZoiningID
                                                                                   && !stps.ISDeleted)
                    .Select(x => new Common.Models.ProductFilters.SecurityTypeDto()
                    {
                        ID = x.ID,
                        SecurityType = x.SecurityTypeProductSelector_GeneralLookUp != null ? x.SecurityTypeProductSelector_GeneralLookUp.Value : "",
                        Product = new TextValuePair()
                        {
                            Key = x.SecurityTypeProductSelector_ProductID != null ? (int)x.SecurityTypeProductSelector_ProductID : 0,
                            Value = x.SecurityTypeProductSelector_Product != null ? x.SecurityTypeProductSelector_Product.Name : string.Empty,
                        }
                    }).ToListAsync();

        var resultWrapper = new CollectionResult<Common.Models.ProductFilters.SecurityTypeDto>()
        {
            FilterName = "Security Type",
            Collection = collection
        };

        return resultWrapper;
    }

    public async Task<bool> Delete(DeleteRuleCommand request)
    {
        var existingRule = await _entityService.Get<SecurityTypeProductSelector>(request.RuleID);

        return existingRule.SecurityTypeProductSelector_CouncilZoningTypeID != request.CouncilZoningTypeID
            ? throw new NotFoundException(request.CouncilZoningTypeID.ToString(), nameof(SecurityTypeProductSelector))
            : await _entityService.Delete<SecurityTypeProductSelector>(request.RuleID);
    }

    public async Task<bool> Update(UpdateRuleCommand request)
    {
        var toBeUpdatedRule = JsonConvert.DeserializeObject<Common.Models.ProductFilters.SecurityTypeDto>(request.Model.ToString() ?? "") ?? throw new InvalidCastException();

        var existingRule = await _context.SecurityTypeProductSelectors.Where(stps => stps.ID == toBeUpdatedRule.ID &&
                                                                                stps.SecurityTypeProductSelector_CouncilZoningTypeID == request.CouncilZoningTypeID)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(toBeUpdatedRule.ID.ToString(), nameof(SecurityTypeProductSelector));

        if (existingRule.SecurityTypeProductSelector_ProductID != toBeUpdatedRule.Product.Key)
        {
            existingRule.SecurityTypeProductSelector_ProductID = toBeUpdatedRule.Product.Key;
        }

        await _context.SaveChangesAsync(CancellationToken.None);

        return await Task.FromResult(true);
    }

    #endregion
}
