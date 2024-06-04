using ProductMatrix.Domain.Constants;

namespace ProductMatrix.Application.ProductFilters.FacadeServices.Services;

public class FacilityTypeProductSelectorCurdService : IFacilityTypeProductSelectorCurdService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly IGeneralLookUpService _generalLookUpService;
    private readonly IEntityService _entityService;

    #endregion

    #region Ctor

    public FacilityTypeProductSelectorCurdService(IApplicationDbContext context,
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
        var facilityTypeDto = JsonConvert.DeserializeObject<FacilityTypeDto>(request.Model.ToString() ?? "") ?? throw new InvalidCastException();

        var generalLookUpId = await _generalLookUpService.GetGeneralLookUpID(GeneralLookUps.FacilityType, facilityTypeDto.FacilityType);

        var existingEntry = await _context.FacilityTypeProductSelectors.Where(ftps => ftps.FacilityTypeProductSelector_GeneralLookUpID == generalLookUpId &&
                                                                                      ftps.FacilityTypeProductSelector_CouncilZoningTypeID == request.CouncilZoningTypeID &&
                                                                                       ftps.FacilityTypeProductSelector_ProductID == facilityTypeDto.Product.Key)
                                                                        .FirstOrDefaultAsync();

        if (existingEntry != null) { throw new AlreadyExistsException($"{facilityTypeDto.Product.Value}"); }

        var facilityTypeProductSelector = new FacilityTypeProductSelector()
        {
            FacilityTypeProductSelector_CouncilZoningTypeID = request.CouncilZoningTypeID,
            FacilityTypeProductSelector_ProductID = facilityTypeDto.Product.Key,
            FacilityTypeProductSelector_GeneralLookUpID = generalLookUpId
        };

        await _context.FacilityTypeProductSelectors.AddAsync(facilityTypeProductSelector);

        await _context.SaveChangesAsync(CancellationToken.None);

        return true;
    }

    public async Task<ICollectionResult> GetAll(GetAllRulesWithFilterIDQuery request)
    {
        var collection = await _context.FacilityTypeProductSelectors.Where(ftps => ftps.FacilityTypeProductSelector_CouncilZoningTypeID == request.CouncilZoiningID 
                                                                                   && !ftps.ISDeleted)
                    .Select(x => new FacilityTypeDto()
                    {
                        ID = x.ID,
                        FacilityType = x.FacilityTypeProductSelector_GeneralLookUp != null ? x.FacilityTypeProductSelector_GeneralLookUp.Value : "",                       
                        Product = new TextValuePair()
                        {
                            Key = x.FacilityTypeProductSelector_ProductID != null ? (int)x.FacilityTypeProductSelector_ProductID : 0,
                            Value = x.FacilityTypeProductSelector_Product != null ? x.FacilityTypeProductSelector_Product.Name : string.Empty,
                        }
                    }).ToListAsync();

        var resultWrapper = new CollectionResult<FacilityTypeDto>()
        {
            FilterName = "Facility Type",
            Collection = collection
        };

        return resultWrapper;
    }

    public async Task<bool> Delete(DeleteRuleCommand request)
    {
        var existingRule = await _entityService.Get<FacilityTypeProductSelector>(request.RuleID);

        return existingRule.FacilityTypeProductSelector_CouncilZoningTypeID != request.CouncilZoningTypeID
            ? throw new NotFoundException(request.CouncilZoningTypeID.ToString(), nameof(FacilityTypeProductSelector))
            : await _entityService.Delete<FacilityTypeProductSelector>(request.RuleID);
    }

    public async Task<bool> Update(UpdateRuleCommand request)
    {
        var toBeUpdatedRule = JsonConvert.DeserializeObject<FacilityTypeDto>(request.Model.ToString() ?? "") ?? throw new InvalidCastException();

        var existingRule = await _context.FacilityTypeProductSelectors.Where(npps => npps.ID == toBeUpdatedRule.ID &&
                                                                                npps.FacilityTypeProductSelector_CouncilZoningTypeID == request.CouncilZoningTypeID)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(toBeUpdatedRule.ID.ToString(), nameof(FacilityTypeProductSelector));

        if (existingRule.FacilityTypeProductSelector_ProductID != toBeUpdatedRule.Product.Key)
        {
            existingRule.FacilityTypeProductSelector_ProductID = toBeUpdatedRule.Product.Key;
        }

        await _context.SaveChangesAsync(CancellationToken.None);

        return await Task.FromResult(true);
    }

    #endregion
}
