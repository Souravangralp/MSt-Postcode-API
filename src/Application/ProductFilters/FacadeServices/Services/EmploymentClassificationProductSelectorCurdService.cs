namespace ProductMatrix.Application.ProductFilters.FacadeServices.Services;

public class EmploymentClassificationProductSelectorCurdService : IEmploymentClassificationProductSelectorCurdService
{
    #region Fields

    private readonly IApplicationDbContext _context;
    private readonly IGeneralLookUpService _generalLookUpService;
    private readonly IEntityService _entityService;

    #endregion

    #region Ctor

    public EmploymentClassificationProductSelectorCurdService(IApplicationDbContext context,
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
        var employmentClassificationDto = JsonConvert.DeserializeObject<EmploymentClassificationDto>(request.Model.ToString() ?? "") ?? throw new InvalidCastException();

        var employmentClassification = await _context.EmploymentClassifications
                                                .Where(ec => ec.EmploymentStatusType.Replace(" ","").ToLower() == employmentClassificationDto.EmploymentStatusType.Replace(" ","").ToLower() &&
                                                             ec.MinimumExperienceOfWorkInMonths == employmentClassificationDto.MinimumExperienceOfWorkInMonths &&
                                                             ec.MaximumExperienceOfWorkInMonths == employmentClassificationDto.MaximumExperienceOfWorkInMonths &&
                                                             ec.ISSameLineOfWork == employmentClassificationDto.ISSameLineOfWork &&
                                                             ec.EmploymentClassification_CouncilZoningCategoryID == request.CouncilZoningTypeID)
                                                .FirstOrDefaultAsync() ?? throw new NotFoundException(employmentClassificationDto.EmploymentStatusType, nameof(EmploymentClassification));

        var existingEntry = await _context.EmploymentClassificationProductSelectors
                                                    .Where(ecps => ecps.EmploymentClassificationProductSelector_EmploymentClassificationID == employmentClassification.ID &&
                                                                   ecps.EmploymentClassificationProductSelector_ProductID == employmentClassificationDto.Product.Key)
                                                    .FirstOrDefaultAsync();

        if (existingEntry != null) { throw new AlreadyExistsException($"{employmentClassificationDto.Product.Value}"); }

        var employmentClassificationProductSelector = new EmploymentClassificationProductSelector()
        {
            EmploymentClassificationProductSelector_EmploymentClassificationID = employmentClassification.ID,
            EmploymentClassificationProductSelector_ProductID = employmentClassificationDto.Product.Key
        };

        await _context.EmploymentClassificationProductSelectors.AddAsync(employmentClassificationProductSelector);

        await _context.SaveChangesAsync(CancellationToken.None);

        return true;
    }

    public async Task<ICollectionResult> GetAll(GetAllRulesWithFilterIDQuery request)
    {
        var collection = from ec in _context.EmploymentClassifications
                         join ecpm in _context.EmploymentClassificationProductSelectors on ec.ID equals ecpm.EmploymentClassificationProductSelector_EmploymentClassificationID into ecpmJoin
                         from ecpm in ecpmJoin.DefaultIfEmpty()
                         join p in _context.Products on ecpm.EmploymentClassificationProductSelector_ProductID equals p.ID into pJoin
                         from p in pJoin.DefaultIfEmpty()
                         where !ecpm.ISDeleted
                         select new EmploymentClassificationDto
                         {
                             ID = ecpm.ID,
                             EmploymentStatusType = ec.EmploymentStatusType,
                             MinimumExperienceOfWorkInMonths = ec.MinimumExperienceOfWorkInMonths,
                             MaximumExperienceOfWorkInMonths = ec.MaximumExperienceOfWorkInMonths,
                             ISSameLineOfWork = ec.ISSameLineOfWork,
                             Product = new TextValuePair { Key = p.ID, Value = p.Name }
                         };

        var resultWrapper = new CollectionResult<EmploymentClassificationDto>()
        {
            FilterName = "Employment classifications",
            Collection = await collection.ToListAsync()  
        };

        return resultWrapper;
    }

    public async Task<bool> Delete(DeleteRuleCommand request)
    {
        return await _entityService.Delete<EmploymentClassificationProductSelector>(request.RuleID);
    }

    public async Task<bool> Update(UpdateRuleCommand request)
    {
        var toBeUpdatedRule = JsonConvert.DeserializeObject<EmploymentClassificationDto>(request.Model.ToString() ?? "") ?? throw new InvalidCastException();

        var existingRule = await _context.EmploymentClassificationProductSelectors.Where(ecps => ecps.ID == toBeUpdatedRule.ID)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(toBeUpdatedRule.ID.ToString() ?? "", nameof(FacilityTypeProductSelector));

        if (existingRule.EmploymentClassificationProductSelector_ProductID != toBeUpdatedRule.Product.Key)
        {
            existingRule.EmploymentClassificationProductSelector_ProductID = toBeUpdatedRule.Product.Key;
        }

        await _context.SaveChangesAsync(CancellationToken.None);

        return await Task.FromResult(true);
    }

    #endregion
}
