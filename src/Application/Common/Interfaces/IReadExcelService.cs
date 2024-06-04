namespace ProductMatrix.Application.Common.Interfaces;

public interface IReadExcelService
{
    Task<List<Product>> GetProducts();

    Task<List<Postcode>> GetPostcodes();
        
    Task<List<PostcodeClassificationMapper>> GetPostcodeClassificationMapper();

    Task<List<PostcodeClassification>> GetPostcodeClassifications();

    Task<List<ProductFeeLVRRate>> GetBaseIncrementPercent();

    Task<List<AdditionalFee>> GetAdditionalFee();

    Task<List<ScenarioBuilder>> GetScenarioBuilder();

    Task<List<DefaultFee>> GetDefaultFee();

    Task<List<LandSize>> GetLandSize();

    Task<List<ProductCatalogue>> GetProductCatalogue();

    Task<List<Dwelling>> GetDwellings();

    Task<List<PostcodeDetailDto>> GetPostcodeDetails();

    #region ProductSelectors

    Task<List<PostcodeProductSelector>> GetPostcodeProducts();

    Task<List<DocTypeProductSelector>> GetDocTypeProducts();

    Task<List<DwellingsProductSelector>> GetDwellingsProductSelectors();

    Task<List<BorrowingEntityProductSelector>> GetBorrowingEntityProductSelectors();

    Task<List<AdditionalFeeDocTypeVariation>> GetAdditionalFeeDocTypeVariations();

    Task<List<LoanAmountProductSelector>> GetLoanAmountProductSelectors();

    Task<List<LvrProductSelector>> GetLvrProductSelectors();

    Task<List<SecurityTypeProductSelector>> GetSecurityTypeProductSelectors();

    Task<List<RepaymentTypeProductSelector>> GetRepaymentTypeProductSelectors();

    Task<List<NaturalPersonAgeProductSelector>> GetNaturalPersonAgeProductSelectors();

    Task<List<PurchaseTypeProductSelector>> GetPurchaseTypeProductSelector();

    Task<List<EmploymentClassificationProductSelector>> GetEmploymentClassificationProductSelector();

    Task<List<SelfEmployedClassificationProductSelector>> GetSelfEmployedClassificationProductSelector();

    Task<List<EmployerClassificationProductSelector>> GetEmployerClassificationProductSelector();

    Task<List<ZoningTypeProductSelector>> GetZoiningTypeProductSelector();

    Task<List<OtherIncomeTypeProductSelector>> GetOtherIncomeTypeProductSelector();

    Task<List<PotentialImpactfulConsiderationProductSelector>> GetPotentialImpactfulConsiderationProductSelector();

    Task<List<AgeCreditReportProductSelector>> GetAgeCreditReportProductSelector();

    Task<List<ConstructionProductSelector>> GetConstructionProductSelector();

    Task<List<CashOutProductSelector>> GetCashOutProductSelector();

    Task<List<UnitsApartmentProductSelector>> GetUnitsApartmentProductSelector();

    Task<List<FacilityTypeProductSelector>> GetFacilityTypeProductSelectors();

    Task<List<GuidedByTypeProductSelector>> GetGuidedByTypeProductSelectors();

    Task<List<HeedFullPointTypeProductSelector>> GetHeedFullPointsTypeProductSelectors();

    #endregion

    #region Product classifications

    Task<List<EmploymentClassification>> GetEmploymentClassifications();

    Task<List<PostcodeSpecificationMapper>> GetPostcodeSpecificationMapper();

    #endregion

    Task<List<GeneralLookUp>> GetGeneralLookUps();

    Task<List<NumeralClassification>> GetNumeralClassification();
}
