namespace ProductMatrix.Domain.Constants;

public record JsonFile(string FileName)
{
    public static readonly JsonFile DocType = new("doctypeData.json");

    public static readonly JsonFile CategoryType = new("postcodecategoryData.json");

    public static readonly JsonFile ProductCategory = new("productCategoryData.json");

    public static readonly JsonFile Product = new("productData.json");

    public static readonly JsonFile LoanToValueRatio = new("lvrData.json");

    public static readonly JsonFile Postcode = new("postcodeData.json");

    public static readonly JsonFile StandardAndPoorPostcode = new("standardandpoorpostcodeData.json");

    public static readonly JsonFile ProductFee = new("productFeeData.json");

    public static readonly JsonFile State = new("state.json");

    public static readonly JsonFile AdditionalFee = new("additionalfeeData.json");

    public static readonly JsonFile RelocationServicing = new("relocationservicingData.json");

    public static readonly JsonFile VacantLandCategory = new("vacantlandcategoryData.json");

    public static readonly JsonFile CouncilZoningCategory = new("councilzoiningcategoryData.json");

    public static readonly JsonFile DefaultSetting = new("defaultsettingData.json");

    public static readonly JsonFile BorrowingEntityType = new("borrowingentityData.json");

    public static readonly JsonFile CommonDropdownClassification = new("commondropdownclassificationData.json");

    public static readonly JsonFile EmploymentClassification = new("employmentclassificationData.json");

    public static readonly JsonFile SelfEmployedClassification = new("selfemployedclassificationData.json");

    public static readonly JsonFile ZoiningType = new("ZoiningType.json");

    public static readonly JsonFile OtherIncomeType = new("OtherIncomeType.json");

    public static readonly JsonFile ConstructionType = new("ConstructionType.json");

    public static readonly JsonFile BuilderType = new("BuilderType.json");

    public static readonly JsonFile CashOutType = new("cashoutType.json");

    public static readonly JsonFile BusinessFinanceType = new("businessfinanceType.json");

    public static readonly JsonFile RenovationType = new("renovationType.json");

    public static readonly JsonFile RulesFilter = new("rulesfilters.json");
}
