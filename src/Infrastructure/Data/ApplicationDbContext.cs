using ProductMatrix.Domain;

namespace ProductMatrix.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    #region Postcodes

    public DbSet<Postcode> Postcodes => Set<Postcode>();

    public DbSet<Suburb> Suburbs => Set<Suburb>();

    public DbSet<PostcodeSuburbMapper> PostcodeSuburbMapper => Set<PostcodeSuburbMapper>();

    public DbSet<PostcodeClassification> PostcodeClassifications => Set<PostcodeClassification>();

    public DbSet<PostcodeClassificationMapper> PostcodeClassificationMapper => Set<PostcodeClassificationMapper>();

    #endregion

    #region ProductSelectors

    public DbSet<DocTypeProductSelector> DocTypeProductSelectors => Set<DocTypeProductSelector>();

    public DbSet<BorrowingEntityProductSelector> BorrowingEntityProductSelectors => Set<BorrowingEntityProductSelector>();

    public DbSet<PostcodeProductSelector> PostcodeProductSelectors => Set<PostcodeProductSelector>();

    public DbSet<DwellingsProductSelector> DwellingsProductSelectors => Set<DwellingsProductSelector>();

    public DbSet<LoanAmountProductSelector> LoanAmountProductSelectors => Set<LoanAmountProductSelector>();

    public DbSet<LvrProductSelector> LvrProductSelectors => Set<LvrProductSelector>();

    public DbSet<SecurityTypeProductSelector> SecurityTypeProductSelectors => Set<SecurityTypeProductSelector>();

    public DbSet<RepaymentTypeProductSelector> RepaymentTypeProductSelectors => Set<RepaymentTypeProductSelector>();

    public DbSet<NaturalPersonAgeProductSelector> NaturalPersonAgeProductSelectors => Set<NaturalPersonAgeProductSelector>();

    public DbSet<PurchaseTypeProductSelector> PurchaseTypeProductSelectors => Set<PurchaseTypeProductSelector>();

    public DbSet<EmploymentClassificationProductSelector> EmploymentClassificationProductSelectors => Set<EmploymentClassificationProductSelector>();

    public DbSet<SelfEmployedClassificationProductSelector> SelfEmployedClassificationProductSelectors => Set<SelfEmployedClassificationProductSelector>();

    public DbSet<EmployerClassificationProductSelector> EmployerClassificationProductSelectors => Set<EmployerClassificationProductSelector>();

    public DbSet<ZoningTypeProductSelector> ZoningTypeProductSelectors => Set<ZoningTypeProductSelector>();

    public DbSet<OtherIncomeTypeProductSelector> OtherIncomeTypeProductSelectors => Set<OtherIncomeTypeProductSelector>();

    public DbSet<PotentialImpactfulConsiderationProductSelector> PotentialImpactfulConsiderationProductSelectors => Set<PotentialImpactfulConsiderationProductSelector>();

    public DbSet<AgeCreditReportProductSelector> AgeCreditReportProductSelectors => Set<AgeCreditReportProductSelector>();

    public DbSet<ConstructionProductSelector> ConstructionProductSelectors => Set<ConstructionProductSelector>();

    public DbSet<CashOutProductSelector> CashOutProductSelectors => Set<CashOutProductSelector>();

    public DbSet<UnitsApartmentProductSelector> UnitsApartmentProductSelectors => Set<UnitsApartmentProductSelector>();

    public DbSet<FacilityTypeProductSelector> FacilityTypeProductSelectors => Set<FacilityTypeProductSelector>();

    public DbSet<GuidedByTypeProductSelector> GuidedByTypeProductSelectors => Set<GuidedByTypeProductSelector>();

    public DbSet<HeedFullPointTypeProductSelector> HeedFullPointTypeProductSelectors => Set<HeedFullPointTypeProductSelector>();

    public DbSet<TitleTypeProductSelector> TitleTypeProductSelectors => Set<TitleTypeProductSelector>();

    public DbSet<ServiceTypeProductSelector> ServiceTypeProductSelectors => Set<ServiceTypeProductSelector>();

    public DbSet<UsageTypeProductSelector> UsageTypeProductSelectors => Set<UsageTypeProductSelector>();

    public DbSet<LandSizeProductSelector> LandSizeProductSelectors => Set<LandSizeProductSelector>();

    public DbSet<ButtonTypeProductSelector> ButtonTypeProductSelectors => Set<ButtonTypeProductSelector>();

    public DbSet<ApplicationObjectiveProductSelector> ApplicationObjectiveProductSelectors => Set<ApplicationObjectiveProductSelector>();

    public DbSet<MaritalStatusProductSelector> MaritalStatusProductSelectors => Set<MaritalStatusProductSelector>();

    #endregion

    public DbSet<RulesFilter> RulesFilters => Set<RulesFilter>();

    public DbSet<DefaultSetting> DefaultSettings => Set<DefaultSetting>();

    public DbSet<RenovationType> RenovationTypes => Set<RenovationType>();

    public DbSet<ConstructionType> ConstructionTypes => Set<ConstructionType>();

    public DbSet<BuilderType> BuilderTypes => Set<BuilderType>();

    public DbSet<OtherIncomeType> OtherIncomeTypes => Set<OtherIncomeType>();

    public DbSet<AdditionalFeeDocTypeVariation> AdditionalFeeDocTypeVariations => Set<AdditionalFeeDocTypeVariation>();

    public DbSet<Product> Products => Set<Product>();

    public DbSet<DocType> DocTypes => Set<DocType>();

    public DbSet<CategoryType> CategoryTypes => Set<CategoryType>();

    public DbSet<LoanToValueRatio> LoanToValueRatios => Set<LoanToValueRatio>();

    public DbSet<AdditionalFee> AdditionalFees => Set<AdditionalFee>();

    public DbSet<LandSize> LandSizes => Set<LandSize>();

    public DbSet<DefaultFee> DefaultFees => Set<DefaultFee>();

    public DbSet<ProductFeeLVRRate> ProductFeeLVRRates => Set<ProductFeeLVRRate>();

    public DbSet<ScenarioBuilder> ScenarioBuilders => Set<ScenarioBuilder>();

    public DbSet<ProductCategory> ProductCategories => Set<ProductCategory>();

    public DbSet<State> States => Set<State>();

    public DbSet<VacantLandCategory> VacantLandCategories => Set<VacantLandCategory>();

    public DbSet<RelocationServicing> RelocationServicings => Set<RelocationServicing>();

    public DbSet<CouncilZoningCategory> CouncilZoningCategories => Set<CouncilZoningCategory>();

    public DbSet<BorrowingEntityType> BorrowingEntityTypes => Set<BorrowingEntityType>();

    public DbSet<ProductCatalogue> ProductCatalogues => Set<ProductCatalogue>();

    public DbSet<GeneralLookUp> GeneralLookUps => Set<GeneralLookUp>();

    public DbSet<NumeralClassification> NumeralClassifications => Set<NumeralClassification>();

    public DbSet<EmploymentClassification> EmploymentClassifications => Set<EmploymentClassification>();

    public DbSet<SelfEmployedClassification> SelfEmployedClassifications => Set<SelfEmployedClassification>();

    public DbSet<CashOutType> CashOutTypes => Set<CashOutType>();

    public DbSet<BusinessFinanceType> BusinessFinanceTypes => Set<BusinessFinanceType>();

    public DbSet<PostcodeSpecificationMapper> PostcodeSpecificationMapper => Set<PostcodeSpecificationMapper>();

    public DbSet<LandSizeClassification> LandSizeClassifications => Set<LandSizeClassification>();

    public DbSet<ApplicationObjectiveClassification> ApplicationObjectiveClassifications => Set<ApplicationObjectiveClassification>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
