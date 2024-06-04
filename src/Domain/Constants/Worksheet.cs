namespace ProductMatrix.Domain.Constants;

public record Worksheet
{
    public record ProductSelector
    {
        public const string TitleTypeProductSelector = "TitleTypeProductSelector";

        public const string DocTypeProductSelector = "DocTypeProductSelector";

        public const string BorrowingEntityProductSelector = "BorrowingEntityProductSelector";

        public const string LoanAmountProductSelectors = "LoanAmountProductSelectors";

        public const string SecurityTypeProductSelector = "SecurityTypeProductSelector";

        public const string ServiceTypeProductSelector = "ServiceTypeProductSelector";

        public const string UsageTypeProductSelector = "UsageTypeProductSelector";

        public const string LandSizeProductSelector = "LandSizeProductSelector";

        public const string ButtonTypeProductSelector = "ButtonTypeProductSelector";

        public const string ApplicationObjectiveProductSelector = "ApplicationObjectiveProduct";

        public const string SelfEmployedProductSelector = "SelfEmployedProductSelector";

        public const string EmployerClassificationProductSelector = "EmployerProductSelector";

        public const string ZoiningTypeProductSelector = "ZoiningTypeProductSelector";

        public const string OtherIncomeTypeProductSelector = "OtherIncomeProductSelector";

        public const string PotentialImpactfulProductSelector = "PotentialImpactful";

        public const string AgeCreditProductSelector = "AgeCreditProductSelector";

        public const string ConstructionTypeProductSelector = "ConstructionTypeProductSelector";

        public const string CashOutProductSelector = "CashoutProductSelector";

        public const string PostcodeProductSelector = "PostcodeProductSelector";

        public const string EmploymentProductSelector = "EmploymentProductSelector";

        public const string LvrProductSelectors = "LvrProductSelectors";

        public const string DwellingsProductSelectors = "DwellingsProductSelectors";

        public const string FacilityTypeProductSelectors = "FacilityTypeProductSelector";

        public const string UnitsApartmentProductSelector = "UnitsApartmentProductSelector";

        public const string GuidedByTypeProductSelector = "GuidedByTypeProductSelector";

        public const string HeedFullPointProductSelector = "HeedFullPointProductSelector";

        public const string RepaymentTypeProductSelectors = "RepaymentTypeProductSelector";

        public const string MaritalStatusProductSelectors = "MaritalStatusProductSelector";

        public const string NaturalPersonAgeProductSelector = "NaturalPersonAgeProductSelector";

        public const string PurchaseTypeProductSelector = "PurchaseTypeProductSelector";
    }

    public record ProductClassification
    {
        public const string EmploymentClassification = "EmploymentClassification";

        public const string PostCodeScenarioBuilder = "PostCodeScenarioBuilder";

        public const string LandSizeClassification = "LandSizeClassification";

        public const string ApplicationObjective = "ApplicationObjective";
    }

    public record Postcode
    {
        public const string PostcodeClassification = "PostcodeClassifications";
    }

    public record GeneralLookUps
    {
        public const string GeneralLookUp = "GeneralLookUps";
    }

    public record Products
    {
        public const string Product = "Products";
    }

    public record ProductMatric 
    {
        public const string ProductFeeLVRRate = "ProductFeeLVRRate";

        public const string LandSizes = "LandSizes";
    }

    public record NumeralClassifications
    {
        public const string NumeralSelector = "NumeralSelector";
    }
}
