using ProductMatrix.Domain;

namespace ProductMatrix.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    #region Postcodes

    DbSet<Postcode> Postcodes { get; }

    DbSet<Suburb> Suburbs { get; }

    DbSet<PostcodeSuburbMapper> PostcodeSuburbMapper { get; }

    DbSet<PostcodeClassificationMapper> PostcodeClassificationMapper { get; }

    DbSet<PostcodeClassification> PostcodeClassifications { get; }

    #endregion

    #region ProductSelectors

    DbSet<PostcodeProductSelector> PostcodeProductSelectors { get; }

    DbSet<DwellingsProductSelector> DwellingsProductSelectors { get; }

    DbSet<BorrowingEntityProductSelector> BorrowingEntityProductSelectors { get; }

    DbSet<DocTypeProductSelector> DocTypeProductSelectors { get; }

    DbSet<LoanAmountProductSelector> LoanAmountProductSelectors { get; }

    DbSet<LvrProductSelector> LvrProductSelectors { get; }

    DbSet<SecurityTypeProductSelector> SecurityTypeProductSelectors { get; }

    DbSet<RepaymentTypeProductSelector> RepaymentTypeProductSelectors { get; }

    DbSet<NaturalPersonAgeProductSelector> NaturalPersonAgeProductSelectors { get; }

    DbSet<PurchaseTypeProductSelector> PurchaseTypeProductSelectors { get; }

    DbSet<EmploymentClassificationProductSelector> EmploymentClassificationProductSelectors { get; }

    DbSet<SelfEmployedClassificationProductSelector> SelfEmployedClassificationProductSelectors { get; }

    DbSet<EmployerClassificationProductSelector> EmployerClassificationProductSelectors { get; }

    DbSet<ZoningTypeProductSelector> ZoningTypeProductSelectors { get; }

    DbSet<OtherIncomeTypeProductSelector> OtherIncomeTypeProductSelectors { get; }
    
    DbSet<PotentialImpactfulConsiderationProductSelector> PotentialImpactfulConsiderationProductSelectors { get; }

    DbSet<AgeCreditReportProductSelector> AgeCreditReportProductSelectors { get; }

    DbSet<ConstructionProductSelector> ConstructionProductSelectors { get; }

    DbSet<CashOutProductSelector> CashOutProductSelectors { get; }

    DbSet<UnitsApartmentProductSelector> UnitsApartmentProductSelectors { get; }

    DbSet<FacilityTypeProductSelector> FacilityTypeProductSelectors { get; }

    DbSet<GuidedByTypeProductSelector> GuidedByTypeProductSelectors { get; }

    DbSet<HeedFullPointTypeProductSelector> HeedFullPointTypeProductSelectors { get; }

    DbSet<TitleTypeProductSelector> TitleTypeProductSelectors { get; }

    DbSet<ServiceTypeProductSelector> ServiceTypeProductSelectors { get; }

    DbSet<UsageTypeProductSelector> UsageTypeProductSelectors { get; }

    DbSet<LandSizeProductSelector> LandSizeProductSelectors { get; }

    DbSet<ButtonTypeProductSelector> ButtonTypeProductSelectors { get; }

    DbSet<ApplicationObjectiveProductSelector> ApplicationObjectiveProductSelectors { get; }

    DbSet<MaritalStatusProductSelector> MaritalStatusProductSelectors { get; }

    #endregion

    DbSet<Domain.Entities.RulesFilter> RulesFilters { get; }

    DbSet<DefaultSetting> DefaultSettings { get; }

    DbSet<RenovationType> RenovationTypes { get; }

    DbSet<ConstructionType> ConstructionTypes { get; }

    DbSet<BuilderType> BuilderTypes { get; }

    DbSet<OtherIncomeType> OtherIncomeTypes { get; }

    DbSet<AdditionalFeeDocTypeVariation> AdditionalFeeDocTypeVariations { get; }

    DbSet<VacantLandCategory> VacantLandCategories { get; }

    DbSet<CouncilZoningCategory> CouncilZoningCategories { get; }

    DbSet<RelocationServicing> RelocationServicings { get; }

    DbSet<Product> Products { get; }

    DbSet<CategoryType> CategoryTypes { get; }

    DbSet<DocType> DocTypes { get; }

    DbSet<LoanToValueRatio> LoanToValueRatios { get; }

    DbSet<AdditionalFee> AdditionalFees { get; }

    DbSet<LandSize> LandSizes { get; }

    DbSet<DefaultFee> DefaultFees { get; }

    DbSet<ProductFeeLVRRate> ProductFeeLVRRates { get; }

    DbSet<ScenarioBuilder> ScenarioBuilders { get; }

    DbSet<ProductCategory> ProductCategories { get; }

    DbSet<State> States { get; }

    DbSet<BorrowingEntityType> BorrowingEntityTypes { get; }

    DbSet<ProductCatalogue> ProductCatalogues { get; }

    DbSet<GeneralLookUp> GeneralLookUps { get; }

    DbSet<NumeralClassification> NumeralClassifications { get; }

    DbSet<EmploymentClassification> EmploymentClassifications { get; }

    DbSet<SelfEmployedClassification> SelfEmployedClassifications { get; }

    DbSet<CashOutType> CashOutTypes { get; }

    DbSet<BusinessFinanceType> BusinessFinanceTypes { get; }

    DbSet<PostcodeSpecificationMapper> PostcodeSpecificationMapper { get; }    

    DbSet<LandSizeClassification> LandSizeClassifications { get; }   
    
    DbSet<ApplicationObjectiveClassification> ApplicationObjectiveClassifications { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
