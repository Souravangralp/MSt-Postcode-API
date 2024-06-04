namespace ProductMatrix.Infrastructure.Services;

public class FilterCrudService : IFilterCrudService
{
    #region Fields

    private readonly ILoanAmountProductSelectorCrudService _loanAmountProductSelectorCrudService;
    private readonly IDocTypeProductSelectorCrudService _docTypeProductSelectorCrudService;
    private readonly IAgeOfNaturalPersonProductSelectorCrudService _ageOfNaturalPersonProductSelectorCrudService;
    private readonly IConstructionProductSelectorCrudService _constructionProductSelectorCrudService;
    private readonly IZoningProductSelectorCrudService _zoningProductSelectorCrudService;
    private readonly IBorrowingEntityProductSelectorCrudService _borrowingEntityProductSelectorCrudService;
    private readonly IRenovationProductSelectorCrudService _renovationProductSelectorCrudService;
    private readonly IFacilityTypeProductSelectorCurdService _facilityTypeProductSelectorCurdService;
    private readonly IEmploymentClassificationProductSelectorCurdService _employmentClassificationProductSelectorCurdService;
    private readonly IRepaymentTypeProductSelectorCurdService _repaymentTypeProductSelectorCurdService;
    private readonly IGuidedByTypeProductSelectorCurdService _guidedByTypeProductSelectorCurdServices;
    private readonly IHeedFullPointTypeProductSelectorCurdService _heedFullPointTypeProductSelectorCurdService;
    private readonly IUsageTypeProductSelectorServiceCurdService _usageTypeProductSelectorCurdService;
    private readonly IServiceTypeProductSelectorCurdService _serviceTypeProductSelectorCurdService;
    private readonly ISecurityTypeProductSelectorServiceCurdService _securityTypeProductSelectorServiceCurdService;
    private readonly IButtonTypeProductSelectorServiceCurdService _buttonTypeProductSelectorServiceCurdService;
    private readonly ILandSizeProductSelectorServiceCurdService _landSizeProductSelectorServiceCurdService;
    private readonly IApplicationObjectiveProductSelectorCurdService _applicationObjectiveProductSelectorCurdService;
    private readonly IDwellingProductSelectorCurdService _dwellingProductSelectorCurdService;

    #endregion

    #region Ctor

    public FilterCrudService(
        ILoanAmountProductSelectorCrudService loanAmountProductSelectorCrudService,
        IDocTypeProductSelectorCrudService docTypeProductSelectorCrudService,
        IAgeOfNaturalPersonProductSelectorCrudService ageOfNaturalPersonProductSelectorCrudService,
        IConstructionProductSelectorCrudService constructionProductSelectorCrudService,
        IZoningProductSelectorCrudService zoningProductSelectorCrudService,
        IBorrowingEntityProductSelectorCrudService borrowingEntityProductSelectorCrudService,
        IRenovationProductSelectorCrudService renovationProductSelectorCrudService,
        IFacilityTypeProductSelectorCurdService facilityTypeProductSelectorCurdService,
        IEmploymentClassificationProductSelectorCurdService employmentClassificationProductSelectorCurdService,
        IRepaymentTypeProductSelectorCurdService repaymentTypeProductSelectorCurdService,
        IGuidedByTypeProductSelectorCurdService guidedByTypeProductSelectorCurdServices,
        IHeedFullPointTypeProductSelectorCurdService heedFullPointTypeProductSelectorCurdService,
        IUsageTypeProductSelectorServiceCurdService usageTypeProductSelectorCurdService,
        IServiceTypeProductSelectorCurdService serviceTypeProductSelectorCurdService,
        ISecurityTypeProductSelectorServiceCurdService securityTypeProductSelectorServiceCurdService,
        IButtonTypeProductSelectorServiceCurdService buttonTypeProductSelectorServiceCurdService,
        ILandSizeProductSelectorServiceCurdService landSizeProductSelectorServiceCurdService,
        IApplicationObjectiveProductSelectorCurdService applicationObjectiveProductSelectorCurdService,
        IDwellingProductSelectorCurdService dwellingProductSelectorCurdService)
    {
        _loanAmountProductSelectorCrudService = loanAmountProductSelectorCrudService;
        _docTypeProductSelectorCrudService = docTypeProductSelectorCrudService;
        _ageOfNaturalPersonProductSelectorCrudService = ageOfNaturalPersonProductSelectorCrudService;
        _constructionProductSelectorCrudService = constructionProductSelectorCrudService;
        _zoningProductSelectorCrudService = zoningProductSelectorCrudService;
        _borrowingEntityProductSelectorCrudService = borrowingEntityProductSelectorCrudService;
        _renovationProductSelectorCrudService = renovationProductSelectorCrudService;
        _facilityTypeProductSelectorCurdService = facilityTypeProductSelectorCurdService;
        _employmentClassificationProductSelectorCurdService = employmentClassificationProductSelectorCurdService;
        _repaymentTypeProductSelectorCurdService = repaymentTypeProductSelectorCurdService;
        _guidedByTypeProductSelectorCurdServices = guidedByTypeProductSelectorCurdServices;
        _heedFullPointTypeProductSelectorCurdService = heedFullPointTypeProductSelectorCurdService;
        _usageTypeProductSelectorCurdService = usageTypeProductSelectorCurdService;
        _serviceTypeProductSelectorCurdService = serviceTypeProductSelectorCurdService;
        _securityTypeProductSelectorServiceCurdService = securityTypeProductSelectorServiceCurdService;
        _buttonTypeProductSelectorServiceCurdService = buttonTypeProductSelectorServiceCurdService;
        _landSizeProductSelectorServiceCurdService = landSizeProductSelectorServiceCurdService;
        _applicationObjectiveProductSelectorCurdService = applicationObjectiveProductSelectorCurdService;
        _dwellingProductSelectorCurdService = dwellingProductSelectorCurdService;
    }

    #endregion

    #region Methods

    public async Task<dynamic> PerformCrud(object request, string operationName)
    {
        var req = request as dynamic ?? throw new ArgumentException("Request is not of the expected type.");

        switch ((int)req.FilterID)
        {
            case (int)FilterType.ResidentialLoanAmount:
            case (int)FilterType.CommercialLoanAmount:
            case (int)FilterType.SMSFResidentialLoanAmount:
                switch (operationName)
                {
                    case "Create":
                        return await _loanAmountProductSelectorCrudService.Create(req);
                    case "GetAll":
                        return await _loanAmountProductSelectorCrudService.GetAll(req);
                    case "Update":
                        return await _loanAmountProductSelectorCrudService.Update(req);
                    case "Delete":
                        return await _loanAmountProductSelectorCrudService.Delete(req);
                    default:
                        throw new InvalidOperationException($"Unsupported operation: {operationName}");
                }
            case (int)FilterType.ResidentialDocType:
            case (int)FilterType.CommercialDocType:
            case (int)FilterType.SMSFResidentialDocType:
                switch (operationName)
                {
                    case "Create":
                        return await _docTypeProductSelectorCrudService.Create(req);
                    case "GetAll":
                        return await _docTypeProductSelectorCrudService.GetAll(req);
                    case "Update":
                        return await _docTypeProductSelectorCrudService.Update(req);
                    case "Delete":
                        return await _docTypeProductSelectorCrudService.Delete(req);
                    default:
                        throw new InvalidOperationException($"Unsupported operation: {operationName}");
                }
            case (int)FilterType.ResidentialAgeOfNaturalPerson:
            case (int)FilterType.CommercialAgeOfNaturalPerson:
                switch (operationName)
                {
                    case "Create":
                        return await _ageOfNaturalPersonProductSelectorCrudService.Create(req);
                    case "GetAll":
                        return await _ageOfNaturalPersonProductSelectorCrudService.GetAll(req);
                    case "Update":
                        return await _ageOfNaturalPersonProductSelectorCrudService.Update(req);
                    case "Delete":
                        return await _ageOfNaturalPersonProductSelectorCrudService.Delete(req);
                    default:
                        throw new InvalidOperationException($"Unsupported operation: {operationName}");
                }
            case (int)FilterType.ResidentialConstruction:
            case (int)FilterType.CommercialConstruction:
            case (int)FilterType.SMSFResidentialConstruction:
                switch (operationName)
                {
                    case "Create":
                        return await _constructionProductSelectorCrudService.Create(req);
                    case "GetAll":
                        return await _constructionProductSelectorCrudService.GetAll(req);
                    case "Update":
                        return await _constructionProductSelectorCrudService.Update(req);
                    case "Delete":
                        return await _constructionProductSelectorCrudService.Delete(req);
                    default:
                        throw new InvalidOperationException($"Unsupported operation: {operationName}");
                }
            case (int)FilterType.ResidentialConstructionGreen:
            case (int)FilterType.CommercialConstructionGreen:
            case (int)FilterType.SMSFResidentialConstructionGreen:
                switch (operationName)
                {
                    case "Create":
                        return await _constructionProductSelectorCrudService.CreateGreen(req);
                    case "GetAll":
                        return await _constructionProductSelectorCrudService.GetAllGreen(req);
                    case "Update":
                        return await _constructionProductSelectorCrudService.UpdateGreen(req);
                    case "Delete":
                        return await _constructionProductSelectorCrudService.DeleteGreen(req);
                    default:
                        throw new InvalidOperationException($"Unsupported operation: {operationName}");
                }
            case (int)FilterType.ResidentialRenovationWithNoStructuralChanges:
                switch (operationName)
                {
                    case "Create":
                        return await _renovationProductSelectorCrudService.Create(req);
                    case "GetAll":
                        return await _renovationProductSelectorCrudService.GetAll(req);
                    case "Update":
                        return await _renovationProductSelectorCrudService.Update(req);
                    case "Delete":
                        return await _renovationProductSelectorCrudService.Delete(req);
                    default:
                        throw new InvalidOperationException($"Unsupported operation: {operationName}");
                }
            case (int)FilterType.ResidentialRenovationWithStructuralChanges:
                switch (operationName)
                {
                    case "Create":
                        return await _renovationProductSelectorCrudService.CreateStructuralChanges(req);
                    case "GetAll":
                        return await _renovationProductSelectorCrudService.GetAllStructuralChanges(req);
                    case "Update":
                        return await _renovationProductSelectorCrudService.UpdateStructuralChanges(req);
                    case "Delete":
                        return await _renovationProductSelectorCrudService.DeleteStructuralChanges(req);
                    default:
                        throw new InvalidOperationException($"Unsupported operation: {operationName}");
                }
            case (int)FilterType.ResidentialBorrowingEntity:
            case (int)FilterType.CommercialBorrowingEntity:
            case (int)FilterType.SMSFResidentialBorrowingEntity:
                switch (operationName)
                {
                    case "Create":
                        return await _borrowingEntityProductSelectorCrudService.Create(req);
                    case "GetAll":
                        return await _borrowingEntityProductSelectorCrudService.GetAll(req);
                    case "Update":
                        return await _borrowingEntityProductSelectorCrudService.Update(req);
                    case "Delete":
                        return await _borrowingEntityProductSelectorCrudService.Delete(req);
                    default:
                        throw new InvalidOperationException($"Unsupported operation: {operationName}");
                }
            case (int)FilterType.ResidentialZoningType:
            case (int)FilterType.CommercialZoningType:
            case (int)FilterType.SMSFResidentialZoningType:
                switch (operationName)
                {
                    case "Create":
                        return await _zoningProductSelectorCrudService.Create(req);
                    case "GetAll":
                        return await _zoningProductSelectorCrudService.GetAll(req);
                    case "Update":
                        return await _zoningProductSelectorCrudService.Update(req);
                    case "Delete":
                        return await _zoningProductSelectorCrudService.Delete(req);
                    default:
                        throw new InvalidOperationException($"Unsupported operation: {operationName}");
                }
            case (int)FilterType.ResidentialFacilityType:
                switch (operationName)
                {
                    case "Create":
                        return await _facilityTypeProductSelectorCurdService.Create(req);
                    case "Update":
                        return await _facilityTypeProductSelectorCurdService.Update(req);
                    case "GetAll":
                        return await _facilityTypeProductSelectorCurdService.GetAll(req);
                    case "Delete":
                        return await _facilityTypeProductSelectorCurdService.Delete(req);
                    default:
                        throw new InvalidOperationException($"Unsupported operation: {operationName}");
                }
            case (int)FilterType.ResidentialEmploymentClassification:
                switch (operationName)
                {
                    case "Create":
                        return await _employmentClassificationProductSelectorCurdService.Create(req);
                    case "Update":
                        return await _employmentClassificationProductSelectorCurdService.Update(req);
                    case "GetAll":
                        return await _employmentClassificationProductSelectorCurdService.GetAll(req);
                    case "Delete":
                        return await _employmentClassificationProductSelectorCurdService.Delete(req);
                    default:
                        throw new InvalidOperationException($"Unsupported operation: {operationName}");
                }
            case (int)FilterType.ResidentialRepaymentType:
                switch (operationName)
                {
                    case "Create":
                        return await _repaymentTypeProductSelectorCurdService.Create(req);
                    case "Update":
                        return await _repaymentTypeProductSelectorCurdService.Update(req);
                    case "GetAll":
                        return await _repaymentTypeProductSelectorCurdService.GetAll(req);
                    case "Delete":
                        return await _repaymentTypeProductSelectorCurdService.Delete(req);
                    default:
                        throw new InvalidOperationException($"Unsupported operation: {operationName}");
                }
            case (int)FilterType.ResidentialGuidedByType:
                switch (operationName)
                {
                    case "Create":
                        return await _guidedByTypeProductSelectorCurdServices.Create(req);
                    case "Update":
                        return await _guidedByTypeProductSelectorCurdServices.Update(req);
                    case "GetAll":
                        return await _guidedByTypeProductSelectorCurdServices.GetAll(req);
                    case "Delete":
                        return await _guidedByTypeProductSelectorCurdServices.Delete(req);
                    default:
                        throw new InvalidOperationException($"Unsupported operation: {operationName}");
                }
            case (int)FilterType.ResidentialHeedFullPointType:
                switch (operationName)
                {
                    case "Create":
                        return await _heedFullPointTypeProductSelectorCurdService.Create(req);
                    case "Update":
                        return await _heedFullPointTypeProductSelectorCurdService.Update(req);
                    case "GetAll":
                        return await _heedFullPointTypeProductSelectorCurdService.GetAll(req);
                    case "Delete":
                        return await _heedFullPointTypeProductSelectorCurdService.Delete(req);
                    default:
                        throw new InvalidOperationException($"Unsupported operation: {operationName}");
                }
            case (int)FilterType.ResidentialUsageType:
                switch (operationName)
                {
                    case "Create":
                        return await _usageTypeProductSelectorCurdService.Create(req);
                    case "Update":
                        return await _usageTypeProductSelectorCurdService.Update(req);
                    case "GetAll":
                        return await _usageTypeProductSelectorCurdService.GetAll(req);
                    case "Delete":
                        return await _usageTypeProductSelectorCurdService.Delete(req);
                    default:
                        throw new InvalidOperationException($"Unsupported operation: {operationName}");
                }
            case (int)FilterType.ResidentialServiceType:
                switch (operationName)
                {
                    case "Create":
                        return await _serviceTypeProductSelectorCurdService.Create(req);
                    case "Update":
                        return await _serviceTypeProductSelectorCurdService.Update(req);
                    case "GetAll":
                        return await _serviceTypeProductSelectorCurdService.GetAll(req);
                    case "Delete":
                        return await _serviceTypeProductSelectorCurdService.Delete(req);
                    default:
                        throw new InvalidOperationException($"Unsupported operation: {operationName}");
                }
            case (int)FilterType.ResidentialSecurityType:
                switch (operationName)
                {
                    case "Create":
                        return await _securityTypeProductSelectorServiceCurdService.Create(req);
                    case "Update":
                        return await _securityTypeProductSelectorServiceCurdService.Update(req);
                    case "GetAll":
                        return await _securityTypeProductSelectorServiceCurdService.GetAll(req);
                    case "Delete":
                        return await _securityTypeProductSelectorServiceCurdService.Delete(req);
                    default:
                        throw new InvalidOperationException($"Unsupported operation: {operationName}");
                }
            case (int)FilterType.ResidentialButtonType:
                switch (operationName)
                {
                    case "Create":
                        return await _buttonTypeProductSelectorServiceCurdService.Create(req);
                    case "Update":
                        return await _buttonTypeProductSelectorServiceCurdService.Update(req);
                    case "GetAll":
                        return await _buttonTypeProductSelectorServiceCurdService.GetAll(req);
                    case "Delete":
                        return await _buttonTypeProductSelectorServiceCurdService.Delete(req);
                    default:
                        throw new InvalidOperationException($"Unsupported operation: {operationName}");
                }
            case (int)FilterType.ResidentialLandSize:
                switch (operationName)
                {
                    case "Create":
                        return await _landSizeProductSelectorServiceCurdService.Create(req);
                    case "Update":
                        return await _landSizeProductSelectorServiceCurdService.Update(req);
                    case "GetAll":
                        return await _landSizeProductSelectorServiceCurdService.GetAll(req);
                    case "Delete":
                        return await _landSizeProductSelectorServiceCurdService.Delete(req);
                    default:
                        throw new InvalidOperationException($"Unsupported operation: {operationName}");
                }
            case (int)FilterType.ResidentialApplicationObjective:
                switch (operationName)
                {
                    case "Create":
                        return await _applicationObjectiveProductSelectorCurdService.Create(req);
                    case "Update":
                        return await _applicationObjectiveProductSelectorCurdService.Update(req);
                    case "GetAll":
                        return await _applicationObjectiveProductSelectorCurdService.GetAll(req);
                    case "Delete":
                        return await _applicationObjectiveProductSelectorCurdService.Delete(req);
                    default:
                        throw new InvalidOperationException($"Unsupported operation: {operationName}");
                }
            case (int)FilterType.ResidentialDwelling:
                switch (operationName)
                {
                    case "Create":
                        return await _dwellingProductSelectorCurdService.Create(req);
                    case "Update":
                        return await _dwellingProductSelectorCurdService.Update(req);
                    case "GetAll":
                        return await _dwellingProductSelectorCurdService.GetAll(req);
                    case "Delete":
                        return await _dwellingProductSelectorCurdService.Delete(req);
                    default:
                        throw new InvalidOperationException($"Unsupported operation: {operationName}");
                }
            default:
                throw new ArgumentException("Invalid case number");
        }
    }

    #endregion
}
