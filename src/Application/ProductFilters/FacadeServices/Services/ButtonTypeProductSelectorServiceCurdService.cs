using ProductMatrix.Domain.Constants;

namespace ProductMatrix.Application.ProductFilters.FacadeServices.Services;

public class ButtonTypeProductSelectorServiceCurdService : IButtonTypeProductSelectorServiceCurdService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly IGeneralLookUpService _generalLookUpService;
    private readonly IEntityService _entityService;

    #endregion

    #region Ctor

    public ButtonTypeProductSelectorServiceCurdService(IApplicationDbContext context,
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
        var securityButtonTypeDto = JsonConvert.DeserializeObject<SecurityButtonTypeDto>(request.Model.ToString() ?? "") ?? throw new InvalidCastException();

        var generalLookUpId = await _generalLookUpService.GetGeneralLookUpID(GeneralLookUps.ButtonType, securityButtonTypeDto.ButtonType);

        var existingEntry = await _context.ButtonTypeProductSelectors.Where(utps => utps.ButtonTypeProductSelector_GeneralLookUpID == generalLookUpId &&
                                                                                      utps.ButtonTypeProductSelector_CouncilZoningTypeID == request.CouncilZoningTypeID &&
                                                                                       utps.ButtonTypeProductSelector_ProductID == securityButtonTypeDto.Product.Key)
                                                                        .FirstOrDefaultAsync();

        if (existingEntry != null) { throw new AlreadyExistsException($"{securityButtonTypeDto.Product.Value}"); }

        var buttonTypeProductSelector = new ButtonTypeProductSelector()
        {
            ButtonTypeProductSelector_CouncilZoningTypeID = request.CouncilZoningTypeID,
            ButtonTypeProductSelector_ProductID = securityButtonTypeDto.Product.Key,
            ButtonTypeProductSelector_GeneralLookUpID = generalLookUpId
        };

        await _context.ButtonTypeProductSelectors.AddAsync(buttonTypeProductSelector);

        await _context.SaveChangesAsync(CancellationToken.None);

        return true;
    }

    public async Task<ICollectionResult> GetAll(GetAllRulesWithFilterIDQuery request)
    {
        var collection = await _context.ButtonTypeProductSelectors.Where(utps => utps.ButtonTypeProductSelector_CouncilZoningTypeID == request.CouncilZoiningID
                                                                                   && !utps.ISDeleted)
                    .Select(x => new SecurityButtonTypeDto()
                    {
                        ID = x.ID,
                        ButtonType = x.ButtonTypeProductSelector_GeneralLookUp != null ? x.ButtonTypeProductSelector_GeneralLookUp.Value : "",
                        Product = new TextValuePair()
                        {
                            Key = x.ButtonTypeProductSelector_ProductID != null ? (int)x.ButtonTypeProductSelector_ProductID : 0,
                            Value = x.ButtonTypeProductSelector_Product != null ? x.ButtonTypeProductSelector_Product.Name : string.Empty,
                        }
                    }).ToListAsync();

        var resultWrapper = new CollectionResult<SecurityButtonTypeDto>()
        {
            FilterName = "Button Type",
            Collection = collection
        };

        return resultWrapper;
    }

    public async Task<bool> Delete(DeleteRuleCommand request)
    {
        var existingRule = await _entityService.Get<ButtonTypeProductSelector>(request.RuleID);

        return existingRule.ButtonTypeProductSelector_CouncilZoningTypeID != request.CouncilZoningTypeID
            ? throw new NotFoundException(request.CouncilZoningTypeID.ToString(), nameof(ButtonTypeProductSelector))
            : await _entityService.Delete<ButtonTypeProductSelector>(request.RuleID);
    }

    public async Task<bool> Update(UpdateRuleCommand request)
    {
        var toBeUpdatedRule = JsonConvert.DeserializeObject<SecurityButtonTypeDto>(request.Model.ToString() ?? "") ?? throw new InvalidCastException();

        var existingRule = await _context.ButtonTypeProductSelectors.Where(utps => utps.ID == toBeUpdatedRule.ID &&
                                                                                utps.ButtonTypeProductSelector_CouncilZoningTypeID == request.CouncilZoningTypeID)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(toBeUpdatedRule.ID.ToString(), nameof(ButtonTypeProductSelector));

        if (existingRule.ButtonTypeProductSelector_ProductID != toBeUpdatedRule.Product.Key)
        {
            existingRule.ButtonTypeProductSelector_ProductID = toBeUpdatedRule.Product.Key;
        }

        await _context.SaveChangesAsync(CancellationToken.None);

        return await Task.FromResult(true);
    }

    #endregion
}
