using ProductMatrix.Domain.Constants;

namespace ProductMatrix.Application.ProductFilters.FacadeServices.Services;

public class ApplicationObjectiveProductSelectorCurdService : IApplicationObjectiveProductSelectorCurdService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly IGeneralLookUpService _generalLookUpService;
    private readonly IEntityService _entityService;

    #endregion

    #region Ctor

    public ApplicationObjectiveProductSelectorCurdService(IApplicationDbContext context,
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
        var applicationObjective = JsonConvert.DeserializeObject<ApplicationObjectiveDto>(request.Model.ToString() ?? "") ?? throw new InvalidCastException();

        int? bankTypeGeneralLookUpId = null;

        var equityTypeGeneralLookUpId = await _generalLookUpService.GetGeneralLookUpID(GeneralLookUps.EquityType, applicationObjective.EquityType);
        var usageTypeGeneralLookUpId = await _generalLookUpService.GetGeneralLookUpID(GeneralLookUps.UsageType, applicationObjective.UsageType);
        if(!string.IsNullOrWhiteSpace(applicationObjective.BankType))
        {
            bankTypeGeneralLookUpId = await _generalLookUpService.GetGeneralLookUpID(GeneralLookUps.AwayBankType, applicationObjective.BankType);
        }

        var applicationObjectiveClassifications = await _context.ApplicationObjectiveClassifications
                                                .Where(aoc => aoc.EquityType_GeneralLookUpID == equityTypeGeneralLookUpId &&
                                                              aoc.UsageType_GeneralLookUpID == usageTypeGeneralLookUpId &&
                                                              aoc.AwayBankType_GeneralLookUpID == bankTypeGeneralLookUpId &&
                                                              aoc.ConsolidateForm == applicationObjective.ConsolidateForm &&
                                                              aoc.ConsolidateTo == applicationObjective.ConsolidateTo &&
                                                              aoc.ApplicationObjectiveClassification_CouncilZoningTypeID == request.CouncilZoningTypeID)
                                                .FirstOrDefaultAsync() 
                                                ?? throw new NotFoundException(applicationObjective.ConsolidateForm.ToString() ?? "", nameof(EmploymentClassification));

        var existingEntry = await _context.ApplicationObjectiveProductSelectors
                                            .Where(aops => aops.ApplicationObjectiveProductSelector_ApplicationObjectiveClassificationID == applicationObjectiveClassifications.ID &&
                                                           aops.ApplicationObjectiveProductSelector_ProductID == applicationObjective.Product.Key)
                                            .FirstOrDefaultAsync();

        if (existingEntry != null) { throw new AlreadyExistsException($"{applicationObjective.Product.Value}"); }

        var applicationObjectiveProductSelector = new ApplicationObjectiveProductSelector()
        {
            ApplicationObjectiveProductSelector_ApplicationObjectiveClassificationID = applicationObjectiveClassifications.ID,
            ApplicationObjectiveProductSelector_ProductID = applicationObjective.Product.Key
        };

        await _context.ApplicationObjectiveProductSelectors.AddAsync(applicationObjectiveProductSelector);

        await _context.SaveChangesAsync(CancellationToken.None);

        return true;
    }

    public async Task<ICollectionResult> GetAll(GetAllRulesWithFilterIDQuery request)
    {
        var collection = from aoc in _context.ApplicationObjectiveClassifications
                         join etgl in _context.GeneralLookUps on aoc.EquityType_GeneralLookUpID equals etgl.ID
                         join utgl in _context.GeneralLookUps on aoc.UsageType_GeneralLookUpID equals utgl.ID 
                         join btgl in _context.GeneralLookUps on aoc.AwayBankType_GeneralLookUpID equals btgl.ID into btglJoin
                         from btgl in btglJoin.DefaultIfEmpty()
                         join aops in _context.ApplicationObjectiveProductSelectors on aoc.ID equals aops.ApplicationObjectiveProductSelector_ApplicationObjectiveClassificationID into ecpmJoin
                         from ecpm in ecpmJoin.DefaultIfEmpty()
                         join p in _context.Products on ecpm.ApplicationObjectiveProductSelector_ProductID equals p.ID into pJoin
                         from p in pJoin.DefaultIfEmpty()
                         where !ecpm.ISDeleted
                         select new ApplicationObjectiveDto
                         {
                             ID = ecpm.ID,
                             EquityType = etgl.Value,
                             UsageType = utgl.Value,
                             BankType = btgl.Value,
                             ConsolidateForm = aoc.ConsolidateForm,
                             ConsolidateTo = aoc.ConsolidateTo,
                             Product = new TextValuePair { Key = p.ID, Value = p.Name }
                         };

        var resultWrapper = new CollectionResult<ApplicationObjectiveDto>()
        {
            FilterName = "Application Objective",
            Collection = await collection.ToListAsync()
        };

        return resultWrapper;
    }

    public async Task<bool> Delete(DeleteRuleCommand request)
    {
        return await _entityService.Delete<ApplicationObjectiveProductSelector>(request.RuleID);
    }

    public async Task<bool> Update(UpdateRuleCommand request)
    {
        var toBeUpdatedRule = JsonConvert.DeserializeObject<ApplicationObjectiveDto>(request.Model.ToString() ?? "") ?? throw new InvalidCastException();

        var existingRule = await _context.ApplicationObjectiveProductSelectors.Where(ecps => ecps.ID == toBeUpdatedRule.ID)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(toBeUpdatedRule.ID.ToString() ?? "", nameof(ApplicationObjectiveClassification));

        if (existingRule.ApplicationObjectiveProductSelector_ProductID != toBeUpdatedRule.Product.Key)
        {
            existingRule.ApplicationObjectiveProductSelector_ProductID = toBeUpdatedRule.Product.Key;
        }

        await _context.SaveChangesAsync(CancellationToken.None);

        return await Task.FromResult(true);
    }

    #endregion
}
