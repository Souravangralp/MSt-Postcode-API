namespace ProductMatrix.Application.ProductFilters.FacadeServices.Services;

public class DocTypeProductSelectorCrudService : IDocTypeProductSelectorCrudService
{
        #region Fields

        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IEntityService _entityService;

        #endregion

        #region Ctor

        public DocTypeProductSelectorCrudService(IApplicationDbContext context,
            IMapper mapper,
            IEntityService entityService)
        {
            _context = context;
            _mapper = mapper;
            _entityService = entityService;
        }

        #endregion

        #region Methods

        public async Task<bool> Create(CreateRuleCommand request)
        {
            var docTypeProductSelectorDto = JsonConvert.DeserializeObject<DocTypeProductSelectorDto>(request.Model.ToString() ?? "") ?? throw new InvalidCastException();

            var doctype = await _entityService.GetByName<DocType>(docTypeProductSelectorDto.DocType);

            var existingEntry = await _context.DocTypeProductSelectors.Where(dps => dps.DocTypeProductSelector_DocTypeID == doctype.ID &&
                                                dps.DocTypeProductSelector_ProductID == docTypeProductSelectorDto.Product.Key &&
                                                dps.MaximumLoanTermInYears == docTypeProductSelectorDto.MaximumLoanTermInYears &&
                                                dps.MinimumLoanTermInYears == docTypeProductSelectorDto.MinimumLoanTermInYears &&
                                                dps.DocTypeProductSelector_CouncilZoningTypeID == request.CouncilZoningTypeID).FirstOrDefaultAsync();

            if (existingEntry != null) { throw new AlreadyExistsException($"{docTypeProductSelectorDto.Product.Value}"); }

            var docTypeProductSelector = new DocTypeProductSelector()
            {
                DocTypeProductSelector_CouncilZoningTypeID = request.CouncilZoningTypeID,
                DocTypeProductSelector_ProductID = docTypeProductSelectorDto.Product.Key,
                DocTypeProductSelector_DocTypeID = doctype.ID,
                MaximumLoanTermInYears = docTypeProductSelectorDto.MaximumLoanTermInYears,
                MinimumLoanTermInYears = docTypeProductSelectorDto.MinimumLoanTermInYears
            };

            await _context.DocTypeProductSelectors.AddAsync(docTypeProductSelector);

            await _context.SaveChangesAsync(CancellationToken.None);

            return true;
        }

        public async Task<bool> Delete(DeleteRuleCommand request)
        {
            var existingRule = await _entityService.Get<DocTypeProductSelector>(request.RuleID);

            return existingRule.DocTypeProductSelector_CouncilZoningTypeID != request.CouncilZoningTypeID
                ? throw new NotFoundException(request.CouncilZoningTypeID.ToString(), nameof(DocTypeProductSelector))
                : await _entityService.Delete<DocTypeProductSelector>(request.RuleID);
        }

        public async Task<ICollectionResult> GetAll(GetAllRulesWithFilterIDQuery request)
        {
            var collection = await _context.DocTypeProductSelectors.Where(dps => dps.DocTypeProductSelector_CouncilZoningTypeID == request.CouncilZoiningID && !dps.ISDeleted)
                        .Select(x => new DocTypeProductSelectorDto()
                        {
                            ID = x.ID,
                            DocType = x.DocTypeProductSelector_DocType != null ? x.DocTypeProductSelector_DocType.Name : string.Empty,
                            MinimumLoanTermInYears = x.MinimumLoanTermInYears,
                            MaximumLoanTermInYears = x.MaximumLoanTermInYears,
                            Product = new TextValuePair()
                            {
                                Key = x.DocTypeProductSelector_ProductID != null ? (int)x.DocTypeProductSelector_ProductID : 0,
                                Value = x.DocTypeProductSelector_Product != null ? x.DocTypeProductSelector_Product.Name : string.Empty,
                            }
                        }).OrderBy(x => x.Product.Key).ToListAsync();

            var resultWrapper = new CollectionResult<DocTypeProductSelectorDto>()
            {
                FilterName = "DocType",
                Collection = collection
            };

            return resultWrapper;
        }

        public async Task<bool> Update(UpdateRuleCommand request)
        {
            var toBeUpdatedRule = JsonConvert.DeserializeObject<DocTypeProductSelectorDto>(request.Model.ToString() ?? "") ?? throw new InvalidCastException();

            var existingRule = await _context.DocTypeProductSelectors.Where(dtps => dtps.ID == toBeUpdatedRule.ID &&
                                                                                    dtps.DocTypeProductSelector_CouncilZoningTypeID == request.CouncilZoningTypeID)
                .FirstOrDefaultAsync() ?? throw new NotFoundException(toBeUpdatedRule.ID.ToString(), nameof(DocTypeProductSelector));

            if (toBeUpdatedRule.Product is null)
            {
                existingRule.DocTypeProductSelector_ProductID = null;
            }
            else
            {
                if (existingRule.DocTypeProductSelector_ProductID != toBeUpdatedRule.Product.Key)
                {
                    existingRule.DocTypeProductSelector_ProductID = toBeUpdatedRule.Product.Key;
                }
            }

            _mapper.Map(toBeUpdatedRule, existingRule);

            await _context.SaveChangesAsync(CancellationToken.None);

            return await Task.FromResult(true);
        }

        #endregion
}
