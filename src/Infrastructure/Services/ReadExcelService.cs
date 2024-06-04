namespace ProductMatrix.Infrastructure.Services;

public class ReadExcelService : IReadExcelService
{
    #region Fields

    #endregion

    #region Ctor

    #endregion

    #region Methods

    #region Products

    public async Task<List<Product>> GetProducts()
    {
        try
        {
            string filePath = FilesUtility.GetFilePath(ExcelFile.Products.FileName);

            var memoryStream = await GetExcelWorkSheet(filePath);

            using ExcelPackage package = new(memoryStream);

            ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

            List<Product> products = [];

            products.Clear();

            products.AddRange(GetProductsFromExcel(worksheet));

            return products;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while importing products from excel", ex);

        }
    }

    #endregion

    #region Postcode

    public async Task<List<Postcode>> GetPostcodes()
    {
        List<Postcode> postcodes = [];
        List<string> isLandpostcodes = [];

        try
        {
            int postcodeRange = 10000; // get this from appsettings

            for (int i = 0; i <= postcodeRange; i++)
            {
                string postcode = i.ToString("D4");

                #region based on meeting @(06-05-2024) client asked to have additional 0's if postcodes are not smaller then 3 digits

                //if (i < 10) { postcode = string.Format("000" + i.ToString()); }
                //if (i >= 10 && i < 100) { postcode = string.Format("00" + i.ToString()); }
                //if (i >= 100 && i < 1000) { postcode = string.Format("0" + i.ToString()); }
                //if (i >= 1000) { postcode = i.ToString(); }

                #endregion

                postcodes.Add(new() { Code = postcode, Postcode_StateID = null, ISIsLand = false });
            }

            isLandpostcodes = await GetIsLandPostcodes(isLandpostcodes);

            postcodes.ForEach(postcode => postcode.ISIsLand = isLandpostcodes
                         .Any(isLandPostcode => postcode.Code.Replace(" ", "").ToLower() == isLandPostcode.Replace(" ", "").ToLower()));
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while importing postcode from excel", ex);
        }

        return await Task.FromResult(postcodes);
    }

    public async Task<List<PostcodeClassificationMapper>> GetPostcodeClassificationMapper()
    {
        try
        {
            string filePath = FilesUtility.GetFilePath(ExcelFile.Postcode.FileName);

            var memoryStream = await GetExcelWorkSheet(filePath);

            using ExcelPackage package = new(memoryStream);

            ExcelWorksheet worksheet = package.Workbook.Worksheets[2];

            List<PostcodeClassificationMapper> postcodeClassificationMapper = [];

            postcodeClassificationMapper.Clear();

            postcodeClassificationMapper.AddRange(GetPostcodeClassificationMapperFromWorkbook(worksheet));

            return postcodeClassificationMapper;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while importing postcode product selectors from excel", ex);
        }
    }

    public async Task<List<PostcodeClassification>> GetPostcodeClassifications()
    {
        try
        {
            string filePath = FilesUtility.GetFilePath(ExcelFile.Postcode.FileName);

            var memoryStream = await GetExcelWorkSheet(filePath);

            using ExcelPackage package = new(memoryStream);

            ExcelWorksheet worksheet = package.Workbook.Worksheets[1];

            List<PostcodeClassification> postcodeClassifications = [];

            postcodeClassifications.Clear();

            postcodeClassifications.AddRange(GetPostcodeClassificationsFromWorkbook(worksheet));

            return postcodeClassifications;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while importing postcode postcode classification from excel", ex);
        }
    }

    public async Task<List<PostcodeProductSelector>> GetPostcodeProducts()
    {
        try
        {
            string filePath = FilesUtility.GetFilePath(ExcelFile.ProductSelector.FileName);

            var memoryStream = await GetExcelWorkSheet(filePath);

            using ExcelPackage package = new(memoryStream);

            ExcelWorksheet worksheet = package.Workbook.Worksheets[18];

            List<PostcodeProductSelector> postcodeProductSelector = [];

            postcodeProductSelector.Clear();

            postcodeProductSelector.AddRange(GetPostcodeProductSelectorsFromExcel(worksheet));

            return postcodeProductSelector;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while importing postcode product selector from excel", ex);
        }
    }

    public async Task<List<DocTypeProductSelector>> GetDocTypeProducts()
    {
        try
        {
            string filePath = FilesUtility.GetFilePath(ExcelFile.ProductSelector.FileName);

            var memoryStream = await GetExcelWorkSheet(filePath);

            using ExcelPackage package = new(memoryStream);

            ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

            List<DocTypeProductSelector> docTypeProductSelector = [];

            docTypeProductSelector.Clear();

            docTypeProductSelector.AddRange(GetDocTypeProductSelectorsFromExcel(worksheet));

            return docTypeProductSelector;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while importing doc type product selector from excel", ex);
        }
    }

    public async Task<List<PostcodeDetailDto>> GetPostcodeDetails()
    {
        try
        {
            string filePath = FilesUtility.GetFilePath(ExcelFile.Postcode.FileName);

            var memoryStream = await GetExcelWorkSheet(filePath);

            using ExcelPackage package = new(memoryStream);

            ExcelWorksheet worksheet = package.Workbook.Worksheets[7];

            List<PostcodeDetailDto> postcodeDetailDto = [];

            postcodeDetailDto.Clear();

            postcodeDetailDto.AddRange(GetPostcodeDetailDtoFromExcel(worksheet));

            return postcodeDetailDto;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while importing postcodeDetailDto from excel", ex);
        }
    }

    #endregion

    #region Others 

    public async Task<List<DwellingsProductSelector>> GetDwellingsProductSelectors()
    {
        try
        {
            string filePath = FilesUtility.GetFilePath(ExcelFile.Postcode.FileName);

            var memoryStream = await GetExcelWorkSheet(filePath);

            using ExcelPackage package = new(memoryStream);

            ExcelWorksheet worksheet = package.Workbook.Worksheets[4];

            List<DwellingsProductSelector> dwellingsProductSelectors = [];

            dwellingsProductSelectors.Clear();

            dwellingsProductSelectors.AddRange(GetDwellingProductsFromExcel(worksheet));

            return dwellingsProductSelectors;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while importing dwelling product selector from excel", ex);
        }

    }

    public async Task<List<ProductFeeLVRRate>> GetBaseIncrementPercent()
    {
        try
        {
            string filePath = FilesUtility.GetFilePath(ExcelFile.BaseFeesWithScenario.FileName);

            var memoryStream = await GetExcelWorkSheet(filePath);

            using ExcelPackage package = new(memoryStream);

            ExcelWorksheet worksheet = package.Workbook.Worksheets[3];

            List<ProductFeeLVRRate> baseIncrements = [];

            baseIncrements.Clear();

            baseIncrements.AddRange(BaseIncrementPercent(worksheet));

            return baseIncrements;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while importing base increment fees from excel", ex);
        }
    }

    public async Task<List<AdditionalFee>> GetAdditionalFee()
    {
        try
        {
            string filePath = FilesUtility.GetFilePath(ExcelFile.BaseFeesWithScenario.FileName);

            var memoryStream = await GetExcelWorkSheet(filePath);

            using ExcelPackage package = new(memoryStream);

            ExcelWorksheet worksheet = package.Workbook.Worksheets[4];

            List<AdditionalFee> additionalFees = [];

            additionalFees.Clear();

            additionalFees.AddRange(AdditionalFee(worksheet));

            return additionalFees;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while importing base increment fees from excel", ex);
        }
    }

    public async Task<List<ScenarioBuilder>> GetScenarioBuilder()
    {
        try
        {
            string filePath = FilesUtility.GetFilePath(ExcelFile.BaseFeesWithScenario.FileName);

            var memoryStream = await GetExcelWorkSheet(filePath);

            using ExcelPackage package = new(memoryStream);

            ExcelWorksheet worksheet = package.Workbook.Worksheets[6];

            List<ScenarioBuilder> scenarioBuilders = [];

            scenarioBuilders.Clear();

            scenarioBuilders.AddRange(ScenarioBuilder(worksheet));

            return scenarioBuilders;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while importing base increment fees from excel", ex);
        }
    }

    public async Task<List<DefaultFee>> GetDefaultFee()
    {
        try
        {
            string filePath = FilesUtility.GetFilePath(ExcelFile.BaseFeesWithScenario.FileName);

            var memoryStream = await GetExcelWorkSheet(filePath);

            using ExcelPackage package = new(memoryStream);

            ExcelWorksheet worksheet = package.Workbook.Worksheets[7];

            List<DefaultFee> baseFee = [];

            baseFee.Clear();

            baseFee.AddRange(BaseFee(worksheet));

            return baseFee;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while importing base increment fees from excel", ex);
        }
    }

    public async Task<List<LandSize>> GetLandSize()
    {
        try
        {
            string filePath = FilesUtility.GetFilePath(ExcelFile.BaseFeesWithScenario.FileName);

            var memoryStream = await GetExcelWorkSheet(filePath);

            using ExcelPackage package = new(memoryStream);

            ExcelWorksheet worksheet = package.Workbook.Worksheets[8];

            List<LandSize> landSize = [];

            landSize.Clear();

            landSize.AddRange(LandSize(worksheet));

            return landSize;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while importing base increment fees from excel", ex);
        }
    }

    public async Task<List<AdditionalFeeDocTypeVariation>> GetAdditionalFeeDocTypeVariations()
    {
        try
        {
            string filePath = FilesUtility.GetFilePath(ExcelFile.BaseFeesWithScenario.FileName);

            var memoryStream = await GetExcelWorkSheet(filePath);

            using ExcelPackage package = new(memoryStream);

            ExcelWorksheet worksheet = package.Workbook.Worksheets[9];

            List<AdditionalFeeDocTypeVariation> additionalFeeDocTypeVariation = [];

            additionalFeeDocTypeVariation.Clear();

            additionalFeeDocTypeVariation.AddRange(AdditionalFeeDocTypeVariation(worksheet));

            return additionalFeeDocTypeVariation;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while importing base increment fees from excel", ex);
        }
    }

    public async Task<List<ProductCatalogue>> GetProductCatalogue()
    {
        try
        {
            string filePath = FilesUtility.GetFilePath(ExcelFile.ProductSelectionMetrics.FileName);

            var memoryStream = await GetExcelWorkSheet(filePath);

            using ExcelPackage package = new(memoryStream);

            ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

            List<ProductCatalogue> productCatalogues = [];

            productCatalogues.Clear();

            productCatalogues.AddRange(GetProductCatalogueFromWorkbook(worksheet));

            return productCatalogues;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while importing product catalogue from excel", ex);
        }
    }

    public async Task<List<Dwelling>> GetDwellings()
    {
        try
        {
            string filePath = FilesUtility.GetFilePath(ExcelFile.ProductSelectionMetrics.FileName);

            var memoryStream = await GetExcelWorkSheet(filePath);

            using ExcelPackage package = new(memoryStream);

            ExcelWorksheet worksheet = package.Workbook.Worksheets[1];

            List<Dwelling> dwellings = [];

            dwellings.Clear();

            dwellings.AddRange(GetDwellingFromWorkbook(worksheet));

            return dwellings;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while importing postcode product selectors from excel", ex);
        }
    }

    public async Task<List<BorrowingEntityProductSelector>> GetBorrowingEntityProductSelectors()
    {
        try
        {
            string filePath = FilesUtility.GetFilePath(ExcelFile.ProductSelector.FileName);

            var memoryStream = await GetExcelWorkSheet(filePath);

            using ExcelPackage package = new(memoryStream);

            ExcelWorksheet worksheet = package.Workbook.Worksheets[1];

            List<BorrowingEntityProductSelector> borrowingEntityProductSelectors = [];

            borrowingEntityProductSelectors.Clear();

            borrowingEntityProductSelectors.AddRange(GetBorrowingEntityProductSelectorsFromExcel(worksheet));

            return borrowingEntityProductSelectors;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while importing borrowing entity product selector from excel", ex);
        }
    }

    public async Task<List<LoanAmountProductSelector>> GetLoanAmountProductSelectors()
    {
        try
        {
            string filePath = FilesUtility.GetFilePath(ExcelFile.ProductSelector.FileName);

            var memoryStream = await GetExcelWorkSheet(filePath);

            using ExcelPackage package = new(memoryStream);

            ExcelWorksheet worksheet = package.Workbook.Worksheets[2];

            List<LoanAmountProductSelector> loanAmountProductSelectors = [];

            loanAmountProductSelectors.Clear();

            loanAmountProductSelectors.AddRange(GetLoanAmountProductSelectorsFromExcel(worksheet));

            return loanAmountProductSelectors;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while importing loanAmount Product Selectors from excel", ex);
        }
    }

    public async Task<List<LvrProductSelector>> GetLvrProductSelectors()
    {
        try
        {
            string filePath = FilesUtility.GetFilePath(ExcelFile.ProductSelector.FileName);

            var memoryStream = await GetExcelWorkSheet(filePath);

            using ExcelPackage package = new(memoryStream);

            ExcelWorksheet worksheet = package.Workbook.Worksheets[3];

            List<LvrProductSelector> lvrProductSelectors = [];

            lvrProductSelectors.Clear();

            lvrProductSelectors.AddRange(GetLvrProductSelectorFromExcel(worksheet));

            return lvrProductSelectors;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while importing lvr ProductSelectors from excel", ex);
        }
    }

    public async Task<List<SecurityTypeProductSelector>> GetSecurityTypeProductSelectors()
    {
        try
        {
            string filePath = FilesUtility.GetFilePath(ExcelFile.ProductSelector.FileName);

            var memoryStream = await GetExcelWorkSheet(filePath);

            using ExcelPackage package = new(memoryStream);

            ExcelWorksheet worksheet = package.Workbook.Worksheets[4];

            List<SecurityTypeProductSelector> securityTypeProductSelector = [];

            securityTypeProductSelector.Clear();

            securityTypeProductSelector.AddRange(GetSecurityTypeProductSelectorsFromExcel(worksheet));

            return securityTypeProductSelector;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while importing securityTypeProductSelector from excel", ex);
        }
    }

    public async Task<List<RepaymentTypeProductSelector>> GetRepaymentTypeProductSelectors()
    {
        try
        {
            string filePath = FilesUtility.GetFilePath(ExcelFile.ProductSelector.FileName);

            var memoryStream = await GetExcelWorkSheet(filePath);

            using ExcelPackage package = new(memoryStream);

            ExcelWorksheet worksheet = package.Workbook.Worksheets[5];

            List<RepaymentTypeProductSelector> repaymentTypeProductSelector = [];

            repaymentTypeProductSelector.Clear();

            repaymentTypeProductSelector.AddRange(GetRepaymentTypeProductSelectorsFromExcel(worksheet));

            return repaymentTypeProductSelector;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while importing RepaymentTypeProductSelector from excel", ex);
        }
    }

    public async Task<List<FacilityTypeProductSelector>> GetFacilityTypeProductSelectors()
    {
        try
        {
            string filePath = FilesUtility.GetFilePath(ExcelFile.ProductSelector.FileName);

            var memoryStream = await GetExcelWorkSheet(filePath);

            using ExcelPackage package = new(memoryStream);

            ExcelWorksheet worksheet = package.Workbook.Worksheets[19];

            List<FacilityTypeProductSelector> facilityTypeProductSelector = [];

            facilityTypeProductSelector.Clear();

            facilityTypeProductSelector.AddRange(GetFacilityTypeProductSelectorFromExcel(worksheet));

            return facilityTypeProductSelector;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while importing RepaymentTypeProductSelector from excel", ex);
        }
    }

    public async Task<List<GuidedByTypeProductSelector>> GetGuidedByTypeProductSelectors()
    {
        try
        {
            string filePath = FilesUtility.GetFilePath(ExcelFile.ProductSelector.FileName);

            var memoryStream = await GetExcelWorkSheet(filePath);

            using ExcelPackage package = new(memoryStream);

            ExcelWorksheet worksheet = package.Workbook.Worksheets[20];

            List<GuidedByTypeProductSelector> guidedByTypeProductSelector = [];

            guidedByTypeProductSelector.Clear();

            guidedByTypeProductSelector.AddRange(GetGuidedByTypeProductSelectorFromExcel(worksheet));

            return guidedByTypeProductSelector;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while importing guided by type from excel", ex);
        }
    }

    public async Task<List<HeedFullPointTypeProductSelector>> GetHeedFullPointsTypeProductSelectors()
    {
        try
        {
            string filePath = FilesUtility.GetFilePath(ExcelFile.ProductSelector.FileName);

            var memoryStream = await GetExcelWorkSheet(filePath);

            using ExcelPackage package = new(memoryStream);

            ExcelWorksheet worksheet = package.Workbook.Worksheets[21];

            List<HeedFullPointTypeProductSelector> heedFullPointTypeProductSelector = [];

            heedFullPointTypeProductSelector.Clear();

            heedFullPointTypeProductSelector.AddRange(GetHeedFullPointsTypeProductSelectorFromExcel(worksheet));

            return heedFullPointTypeProductSelector;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while importing guided by type from excel", ex);
        }
    }

    public async Task<List<NaturalPersonAgeProductSelector>> GetNaturalPersonAgeProductSelectors()
    {
        try
        {
            string filePath = FilesUtility.GetFilePath(ExcelFile.ProductSelector.FileName);

            var memoryStream = await GetExcelWorkSheet(filePath);

            using ExcelPackage package = new(memoryStream);

            ExcelWorksheet worksheet = package.Workbook.Worksheets[6];

            List<NaturalPersonAgeProductSelector> naturalPersonAgeProductSelector = [];

            naturalPersonAgeProductSelector.Clear();

            naturalPersonAgeProductSelector.AddRange(GetNaturalPersonAgeProductSelectorsFromExcel(worksheet));

            return naturalPersonAgeProductSelector;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while importing employerClassificationProductSelector from excel", ex);
        }
    }

    public async Task<List<PurchaseTypeProductSelector>> GetPurchaseTypeProductSelector()
    {
        try
        {
            string filePath = FilesUtility.GetFilePath(ExcelFile.ProductSelector.FileName);

            var memoryStream = await GetExcelWorkSheet(filePath);

            using ExcelPackage package = new(memoryStream);

            ExcelWorksheet worksheet = package.Workbook.Worksheets[7];

            List<PurchaseTypeProductSelector> purchaseTypeProductSelector = [];

            purchaseTypeProductSelector.Clear();

            purchaseTypeProductSelector.AddRange(GetPurchaseTypeProductSelectorsFromExcel(worksheet));

            return purchaseTypeProductSelector;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while importing Purchase Type Product Selector from excel", ex);
        }
    }

    public async Task<List<EmploymentClassificationProductSelector>> GetEmploymentClassificationProductSelector()
    {
        try
        {
            string filePath = FilesUtility.GetFilePath(ExcelFile.ProductSelector.FileName);

            var memoryStream = await GetExcelWorkSheet(filePath);

            using ExcelPackage package = new(memoryStream);

            ExcelWorksheet worksheet = package.Workbook.Worksheets[8];

            List<EmploymentClassificationProductSelector> employmentClassificationProductSelector = [];

            employmentClassificationProductSelector.Clear();

            employmentClassificationProductSelector.AddRange(GetEmploymentClassificationProductSelectorsFromExcel(worksheet));

            return employmentClassificationProductSelector;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while importing Employment Classification Product Selector from excel", ex);
        }
    }

    public async Task<List<SelfEmployedClassificationProductSelector>> GetSelfEmployedClassificationProductSelector()
    {
        try
        {
            string filePath = FilesUtility.GetFilePath(ExcelFile.ProductSelector.FileName);

            var memoryStream = await GetExcelWorkSheet(filePath);

            using ExcelPackage package = new(memoryStream);

            ExcelWorksheet worksheet = package.Workbook.Worksheets[9];

            List<SelfEmployedClassificationProductSelector> selfEmployedClassificationProductSelector = [];

            selfEmployedClassificationProductSelector.Clear();

            selfEmployedClassificationProductSelector.AddRange(GetSelfEmployedClassificationProductSelectorsFromExcel(worksheet));

            return selfEmployedClassificationProductSelector;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while importing self Employed Classification Product Selector from excel", ex);
        }
    }

    public async Task<List<EmployerClassificationProductSelector>> GetEmployerClassificationProductSelector()
    {
        try
        {
            string filePath = FilesUtility.GetFilePath(ExcelFile.ProductSelector.FileName);

            var memoryStream = await GetExcelWorkSheet(filePath);

            using ExcelPackage package = new(memoryStream);

            ExcelWorksheet worksheet = package.Workbook.Worksheets[10];

            List<EmployerClassificationProductSelector> employerClassificationProductSelector = [];

            employerClassificationProductSelector.Clear();

            employerClassificationProductSelector.AddRange(GetEmployerClassificationProductSelectorsFromExcel(worksheet));

            return employerClassificationProductSelector;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while importing employer Classification Product Selector from excel", ex);
        }
    }

    public async Task<List<NumeralClassification>> GetNumeralClassification()
    {
        try
        {
            string filePath = FilesUtility.GetFilePath(ExcelFile.NumeralClassification.FileName);

            var memoryStream = await GetExcelWorkSheet(filePath);

            using ExcelPackage package = new(memoryStream);

            ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

            List<NumeralClassification> numeralClassification = [];

            numeralClassification.Clear();

            numeralClassification.AddRange(GetNumeralClassificationFromWorkbook(worksheet));

            return numeralClassification;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while importing numeral classification from excel", ex);
        }
    }

    public async Task<List<ZoningTypeProductSelector>> GetZoiningTypeProductSelector()
    {
        try
        {
            string filePath = FilesUtility.GetFilePath(ExcelFile.ProductSelector.FileName);

            var memoryStream = await GetExcelWorkSheet(filePath);

            using ExcelPackage package = new(memoryStream);

            ExcelWorksheet worksheet = package.Workbook.Worksheets[11];

            List<ZoningTypeProductSelector> zoiningTypeProductSelectors = [];

            zoiningTypeProductSelectors.Clear();

            zoiningTypeProductSelectors.AddRange(GetZoiningTypeProductSelectorFromWorkbook(worksheet));

            return zoiningTypeProductSelectors;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while importing numeral classification from excel", ex);
        }
    }

    public async Task<List<OtherIncomeTypeProductSelector>> GetOtherIncomeTypeProductSelector()
    {
        try
        {
            string filePath = FilesUtility.GetFilePath(ExcelFile.ProductSelector.FileName);

            var memoryStream = await GetExcelWorkSheet(filePath);

            using ExcelPackage package = new(memoryStream);

            ExcelWorksheet worksheet = package.Workbook.Worksheets[12];

            List<OtherIncomeTypeProductSelector> otherIncomeTypeProductSelectors = [];

            otherIncomeTypeProductSelectors.Clear();

            otherIncomeTypeProductSelectors.AddRange(GetOtherIncomeTypeProductSelectorFromWorkbook(worksheet));

            return otherIncomeTypeProductSelectors;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while importing Other IncomeType ProductSelector from excel", ex);
        }
    }

    public async Task<List<PotentialImpactfulConsiderationProductSelector>> GetPotentialImpactfulConsiderationProductSelector()
    {
        try
        {
            string filePath = FilesUtility.GetFilePath(ExcelFile.ProductSelector.FileName);

            var memoryStream = await GetExcelWorkSheet(filePath);

            using ExcelPackage package = new(memoryStream);

            ExcelWorksheet worksheet = package.Workbook.Worksheets[13];

            List<PotentialImpactfulConsiderationProductSelector> potentialImpactfulConsiderationProductSelector = [];

            potentialImpactfulConsiderationProductSelector.Clear();

            potentialImpactfulConsiderationProductSelector.AddRange(GetPotentialImpactfulConsiderationProductSelectorFromWorkbook(worksheet));

            return potentialImpactfulConsiderationProductSelector;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while importing potential impactful consideration from excel", ex);
        }
    }

    public async Task<List<AgeCreditReportProductSelector>> GetAgeCreditReportProductSelector()
    {
        try
        {
            string filePath = FilesUtility.GetFilePath(ExcelFile.ProductSelector.FileName);

            var memoryStream = await GetExcelWorkSheet(filePath);

            using ExcelPackage package = new(memoryStream);

            ExcelWorksheet worksheet = package.Workbook.Worksheets[14];

            List<AgeCreditReportProductSelector> ageCreditReportProductSelectors = [];

            ageCreditReportProductSelectors.Clear();

            ageCreditReportProductSelectors.AddRange(GetAgeCreditReportProductSelectorFromWorkbook(worksheet));

            return ageCreditReportProductSelectors;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while importing Age Credit Report from excel", ex);
        }
    }

    public async Task<List<ConstructionProductSelector>> GetConstructionProductSelector()
    {
        try
        {
            string filePath = FilesUtility.GetFilePath(ExcelFile.ProductSelector.FileName);

            var memoryStream = await GetExcelWorkSheet(filePath);

            using ExcelPackage package = new(memoryStream);

            ExcelWorksheet worksheet = package.Workbook.Worksheets[15];

            List<ConstructionProductSelector> constructionProductSelectors = [];

            constructionProductSelectors.Clear();

            constructionProductSelectors.AddRange(GetConstructionProductSelectorFromWorkbook(worksheet));

            return constructionProductSelectors;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while importing Construction Product Selector  from excel", ex);
        }
    }

    public async Task<List<CashOutProductSelector>> GetCashOutProductSelector()
    {
        try
        {
            string filePath = FilesUtility.GetFilePath(ExcelFile.ProductSelector.FileName);

            var memoryStream = await GetExcelWorkSheet(filePath);

            using ExcelPackage package = new(memoryStream);

            ExcelWorksheet worksheet = package.Workbook.Worksheets[16];

            List<CashOutProductSelector> cashOutProductSelectors = [];

            cashOutProductSelectors.Clear();

            cashOutProductSelectors.AddRange(GetCashOutProductSelectorFromWorkbook(worksheet));

            return cashOutProductSelectors;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while importing cash out product from excel", ex);
        }
    }

    public async Task<List<UnitsApartmentProductSelector>> GetUnitsApartmentProductSelector()
    {
        try
        {
            string filePath = FilesUtility.GetFilePath(ExcelFile.ProductSelector.FileName);

            var memoryStream = await GetExcelWorkSheet(filePath);

            using ExcelPackage package = new(memoryStream);

            ExcelWorksheet worksheet = package.Workbook.Worksheets[17];

            List<UnitsApartmentProductSelector> unitsApartmentProductSelectors = [];

            unitsApartmentProductSelectors.Clear();

            unitsApartmentProductSelectors.AddRange(GetUnitsApartmentSelectorFromWorkbook(worksheet));

            return unitsApartmentProductSelectors;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while importing units apartment product from excel", ex);
        }
    }

    #endregion

    #region Product classifications

    public async Task<List<EmploymentClassification>> GetEmploymentClassifications()
    {
        try
        {
            string filePath = FilesUtility.GetFilePath(ExcelFile.ProductClassification.FileName);

            var memoryStream = await GetExcelWorkSheet(filePath);

            using ExcelPackage package = new(memoryStream);

            ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

            List<EmploymentClassification> employmentClassifications = [];

            employmentClassifications.Clear();

            employmentClassifications.AddRange(GetEmploymentClassificationsFromExcel(worksheet));

            return employmentClassifications;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while importing employment classification from excel", ex);
        }

    }

    public async Task<List<PostcodeSpecificationMapper>> GetPostcodeSpecificationMapper()
    {
        try
        {
            string filePath = FilesUtility.GetFilePath(ExcelFile.ProductClassification.FileName);

            var memoryStream = await GetExcelWorkSheet(filePath);

            using ExcelPackage package = new(memoryStream);

            ExcelWorksheet worksheet = package.Workbook.Worksheets[1];

            List<PostcodeSpecificationMapper> postcodeSpecificationMapper = [];

            postcodeSpecificationMapper.Clear();

            postcodeSpecificationMapper.AddRange(GetPostcodeSpecificationMapperFromExcel(worksheet));

            return postcodeSpecificationMapper;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while importing Postcode scenario from excel", ex);
        }

    }

    #endregion

    #region general look ups

    public async Task<List<GeneralLookUp>> GetGeneralLookUps()
    {
        try
        {
            string filePath = FilesUtility.GetFilePath(ExcelFile.GeneralLookUp.FileName);

            var memoryStream = await GetExcelWorkSheet(filePath);

            using ExcelPackage package = new(memoryStream);

            ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

            List<GeneralLookUp> generalLookUps = [];

            generalLookUps.Clear();

            generalLookUps.AddRange(GetGeneralLookUpFromExcel(worksheet));

            return generalLookUps;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while importing general lookups from excel", ex);
        }

    }

    #endregion

    #endregion

    #region Helper

    private static List<EmploymentClassification> GetEmploymentClassificationsFromExcel(ExcelWorksheet worksheet)
    {
        List<EmploymentClassification> employmentClassifications = [];

        var rowStartCount = 5;
        int excelRowCount = worksheet.Dimension.End.Row; // GetDimensionRows(worksheet);

        if (excelRowCount > 0)
        {
            for (int row = rowStartCount; row <= excelRowCount; row++)
            {
                if (row == excelRowCount + 1)
                    break;
                else
                    employmentClassifications.Add(
                       new()
                       {
                           EmploymentClassification_CouncilZoningCategoryID = worksheet.Cells[row, 3].Value.GetValue<int>(),
                           EmploymentStatusType = worksheet.Cells[row, 4].Value.GetValue<string>() ?? "",
                           MinimumExperienceOfWorkInMonths = worksheet.Cells[row, 5].Value.GetValue<int>(),
                           MaximumExperienceOfWorkInMonths = worksheet.Cells[row, 6].Value.GetValue<int>(),
                           ISSameLineOfWork = worksheet.Cells[row, 7].Value.GetValue<bool>()
                       });
            }
        }

        return employmentClassifications;
    }

    private static List<GeneralLookUp> GetGeneralLookUpFromExcel(ExcelWorksheet worksheet)
    {
        List<GeneralLookUp> generalLookUps = [];

        var rowStartCount = 5;
        int excelRowCount = worksheet.Dimension.End.Row; 

        if (excelRowCount > 0)
        {
            for (int row = rowStartCount; row <= excelRowCount; row++)
            {
                if (row == excelRowCount + 1)
                    break;
                else
                    generalLookUps.Add(
                       new()
                       {
                           Type = worksheet.Cells[row, 3].Value.GetValue<string>() ?? "",
                           Value = worksheet.Cells[row, 4].Value.GetValue<string>() ?? ""
                       });
            }
        }

        return generalLookUps;
    }

    private static List<PostcodeSpecificationMapper> GetPostcodeSpecificationMapperFromExcel(ExcelWorksheet worksheet)
    {
        List<PostcodeSpecificationMapper> postcodeScenarios = [];

        var rowStartCount = 5;
        int excelRowCount = worksheet.Dimension.End.Row; // GetDimensionRows(worksheet);

        if (excelRowCount > 0)
        {
            for (int row = rowStartCount; row <= excelRowCount; row++)
            {
                if (row == excelRowCount + 1)
                    break;
                else
                    postcodeScenarios.Add(
                       new()
                       {
                           PostcodeClassification_SAndPID = worksheet.Cells[row, 3].Value.GetValue<int>(),
                           PostcodeClassification_PCCategoryID = worksheet.Cells[row, 4].Value.GetValue<int>(),
                           PostcodeClassification_HighSecurityID = worksheet.Cells[row, 5].Value.GetValue<int>()                         
                       });
            }
        }

        return postcodeScenarios;
    }

    private static List<ConstructionProductSelector> GetConstructionProductSelectorFromWorkbook(ExcelWorksheet worksheet)
    {
        List<ConstructionProductSelector> constructionProductSelectors = [];

        var rowStartCount = 5;
        int excelRowCount = worksheet.Dimension.End.Row;
        if (excelRowCount > 0)
        {
            for (int row = rowStartCount; row <= excelRowCount; row++)
            {
                if (row == excelRowCount + 1)
                    break;
                else
                    constructionProductSelectors.Add(
                       new()
                       {
                           ConstructionProductSelector_CouncilZoningTypeID = worksheet.Cells[row, 3].Value.GetValue<int>(),
                           ConstructionProductSelector_ConstructionTypeID = worksheet.Cells[row, 4].Value.GetValue<int>(),
                           ConstructionProductSelector_BuilderTypeID = worksheet.Cells[row, 5].Value.GetValue<int>(),
                           ConstructionProductSelector_ProductID = worksheet.Cells[row, 6].GetValue<int>(),
                           ISGreenRated = worksheet.Cells[row, 7].Value.GetValue<bool>(),
                           ConstructionProductSelector_RenovationTypeID = worksheet.Cells[row, 9].Value.GetValue<int>(),
                       });
            }
        }

        return constructionProductSelectors;
    }

    private static List<PotentialImpactfulConsiderationProductSelector> GetPotentialImpactfulConsiderationProductSelectorFromWorkbook(ExcelWorksheet worksheet)
    {
        List<PotentialImpactfulConsiderationProductSelector> potentialImpactfulConsiderationProductSelector = [];

        var rowStartCount = 5;
        int excelRowCount = worksheet.Dimension.End.Row;
        if (excelRowCount > 0)
        {
            for (int row = rowStartCount; row <= excelRowCount; row++)
            {
                if (row == excelRowCount + 1)
                    break;
                else
                    potentialImpactfulConsiderationProductSelector.Add(
                       new()
                       {
                           Type = worksheet.Cells[row, 3].Value.GetValue<string>() ?? string.Empty,
                           PotentialImpactfulConsiderationProductSelector_ProductID = worksheet.Cells[row, 4].Value.GetValue<int>()
                       });
            }
        }

        return potentialImpactfulConsiderationProductSelector;
    }

    private static List<AgeCreditReportProductSelector> GetAgeCreditReportProductSelectorFromWorkbook(ExcelWorksheet worksheet)
    {
        List<AgeCreditReportProductSelector> ageCreditReportProductSelector = [];

        var rowStartCount = 5;
        int excelRowCount = worksheet.Dimension.End.Row;
        if (excelRowCount > 0)
        {
            for (int row = rowStartCount; row <= excelRowCount; row++)
            {
                if (row == excelRowCount + 1)
                    break;
                else
                    ageCreditReportProductSelector.Add(
                       new()
                       {
                           FromDays = worksheet.Cells[row, 3].Value.GetValue<int>(),
                           ToDays = worksheet.Cells[row, 4].Value.GetValue<int>(),
                           AgeCreditReportProductSelector_ProductID = worksheet.Cells[row, 5].Value.GetValue<int>()
                       });
            }
        }

        return ageCreditReportProductSelector;
    }

    private static List<CashOutProductSelector> GetCashOutProductSelectorFromWorkbook(ExcelWorksheet worksheet)
    {
        List<CashOutProductSelector> cashOutProductSelectors = [];

        var rowStartCount = 5;
        int excelRowCount = worksheet.Dimension.End.Row;
        if (excelRowCount > 0)
        {
            for (int row = rowStartCount; row <= excelRowCount; row++)
            {
                if (row == excelRowCount + 1)
                    break;
                else
                    cashOutProductSelectors.Add(
                       new()
                       {
                           CashOutProductSelector_CashOutTypeID = worksheet.Cells[row, 3].Value.GetValue<int>(),
                           CashOutProductSelector_BusinessFinanceTypeID = worksheet.Cells[row, 4].Value.GetValue<int>(),
                           CashOutProductSelector_ProductID = worksheet.Cells[row, 5].Value.GetValue<int>()
                       });
            }
        }

        return cashOutProductSelectors;
    }

    private static List<UnitsApartmentProductSelector> GetUnitsApartmentSelectorFromWorkbook(ExcelWorksheet worksheet)
    {
        List<UnitsApartmentProductSelector> unitsApartmentProductSelectors = [];

        var rowStartCount = 5;
        int excelRowCount = worksheet.Dimension.End.Row;
        if (excelRowCount > 0)
        {
            for (int row = rowStartCount; row <= excelRowCount; row++)
            {
                if (row == excelRowCount + 1)
                    break;
                else
                    unitsApartmentProductSelectors.Add(
                       new()
                       {
                           LivingAreaFrom = worksheet.Cells[row, 3].Value.GetValue<int>(),
                           LivingAreaTo = worksheet.Cells[row, 4].Value.GetValue<int>(),
                           UnitsApartmentProductSelector_ProductID = worksheet.Cells[row, 5].Value.GetValue<int>()
                       });
            }
        }

        return unitsApartmentProductSelectors;
    }

    private static List<OtherIncomeTypeProductSelector> GetOtherIncomeTypeProductSelectorFromWorkbook(ExcelWorksheet worksheet)
    {
        List<OtherIncomeTypeProductSelector> otherIncomeTypeProductSelector = [];

        var rowStartCount = 5;
        int excelRowCount = worksheet.Dimension.End.Row;
        if (excelRowCount > 0)
        {
            for (int row = rowStartCount; row <= excelRowCount; row++)
            {
                if (row == excelRowCount + 1)
                    break;
                else
                    otherIncomeTypeProductSelector.Add(
                       new()
                       {
                           OtherIncomeTypeProductSelector_OtherIncomeTypeID = worksheet.Cells[row, 3].Value.GetValue<int>(),
                           OtherIncomeTypeProductSelector_ProductID = worksheet.Cells[row, 4].Value.GetValue<int>()
                       });
            }
        }

        return otherIncomeTypeProductSelector;
    }

    private static List<ZoningTypeProductSelector> GetZoiningTypeProductSelectorFromWorkbook(ExcelWorksheet worksheet)
    {
        List<ZoningTypeProductSelector> zoiningTypeProductSelectors = [];

        var rowStartCount = 5;
        int excelRowCount = worksheet.Dimension.End.Row;
        if (excelRowCount > 0)
        {
            for (int row = rowStartCount; row <= excelRowCount; row++)
            {
                if (row == excelRowCount + 1)
                    break;
                else
                    zoiningTypeProductSelectors.Add(
                       new()
                       {
                           ZoningTypeProductSelector_StateID = worksheet.Cells[row, 3].Value.GetValue<int>(),
                           ZoningTypeProductSelector_CouncilZoningTypeID = worksheet.Cells[row, 4].Value.GetValue<int>(),
                           ZoningTypeProductSelector_CouncilZoningCategoryID = worksheet.Cells[row, 5].Value.GetValue<int>(),
                           Zone = worksheet.Cells[row, 6].Value.GetValue<string>() ?? "",
                           ZoningTypeProductSelector_ProductID = worksheet.Cells[row, 7].Value.GetValue<int>()
                       });
            }
        }

        return zoiningTypeProductSelectors;
    }

    private static List<PostcodeDetailDto> GetPostcodeDetailDtoFromExcel(ExcelWorksheet worksheet)
    {
        List<PostcodeDetailDto> postcodeSourceData = [];

        var rowStartCount = 5;
        int excelRowCount = worksheet.Dimension.End.Row;
        if (excelRowCount > 0)
        {
            for (int row = rowStartCount; row <= excelRowCount; row++)
            {
                if (row == excelRowCount + 1)
                    break;
                else
                    postcodeSourceData.Add(
                       new()
                       {
                           Postcode = worksheet.Cells[row, 2].Value.GetValue<int>(),
                           Suburb = worksheet.Cells[row, 3].Value.GetValue<string>() ?? string.Empty,
                           StateCode = worksheet.Cells[row, 4].Value.GetValue<string>() ?? string.Empty,
                           ISIsLand = worksheet.Cells[row, 5].Value.GetValue<bool>()
                       });
            }
        }

        return postcodeSourceData;
    }

    private static List<LvrProductSelector> GetLvrProductSelectorFromExcel(ExcelWorksheet worksheet)
    {
        List<LvrProductSelector> lvrProductSelectors = [];

        var rowStartCount = 5;
        int excelRowCount = worksheet.Dimension.End.Row;
        if (excelRowCount > 0)
        {
            for (int row = rowStartCount; row <= excelRowCount; row++)
            {
                if (row == excelRowCount + 1)
                    break;
                else
                    lvrProductSelectors.Add(
                       new()
                       {
                           LvrProductSelector_ProductID = worksheet.Cells[row, 3].Value.GetValue<int>(),
                           MaximumLVR = worksheet.Cells[row, 4].Value.GetValue<double>(),
                           ResidencyType = worksheet.Cells[row, 5].Value.GetValue<string>() ?? ""
                       });
            }
        }

        return lvrProductSelectors;
    }

    private static List<LoanAmountProductSelector> GetLoanAmountProductSelectorsFromExcel(ExcelWorksheet worksheet)
    {
        List<LoanAmountProductSelector> loanAmountProductSelectors = [];

        var rowStartCount = 5;
        int excelRowCount = worksheet.Dimension.End.Row;
        if (excelRowCount > 0)
        {
            for (int row = rowStartCount; row <= excelRowCount; row++)
            {
                if (row == excelRowCount + 1)
                    break;
                else
                    loanAmountProductSelectors.Add(
                       new()
                       {
                           LoanAmountProductSelector_DocTypeID = worksheet.Cells[row, 3].Value.GetValue<int>(),
                           LoanAmountProductSelector_CouncilZoningTypeID = worksheet.Cells[row, 4].Value.GetValue<int>(),
                           LoanType = worksheet.Cells[row, 5].Value.GetValue<string>() ?? string.Empty,
                           LoanAmountProductSelector_ProductID = worksheet.Cells[row, 6].Value.GetValue<int>()
                       });
            }
        }

        return loanAmountProductSelectors;
    }

    private static List<Product> GetProductsFromExcel(ExcelWorksheet worksheet)
    {
        List<Product> products = [];

        var rowStartCount = 5;
        int excelRowCount = worksheet.Dimension.End.Row;
        if (excelRowCount > 0)
        {
            for (int row = rowStartCount; row <= excelRowCount; row++)
            {
                if (row == excelRowCount + 1)
                    break;
                else
                    products.Add(
                       new()
                       {
                           Name = worksheet.Cells[row, 3].Value.GetValue<string>() ?? "",
                           Product_ProductCategoryID = worksheet.Cells[row, 4].Value.GetValue<int>(),
                           RangeFrom = worksheet.Cells[row, 5].Value.GetValue<double>(),
                           RangeTo = worksheet.Cells[row, 6].Value.GetValue<double>(),
                       });
            }
        }

        return products;
    }

    private static List<SecurityTypeProductSelector> GetSecurityTypeProductSelectorsFromExcel(ExcelWorksheet worksheet)
    {
        List<SecurityTypeProductSelector> securityTypeProductSelector = [];

        var rowStartCount = 5;
        int excelRowCount = worksheet.Dimension.End.Row;
        if (excelRowCount > 0)
        {
            for (int row = rowStartCount; row <= excelRowCount; row++)
            {
                if (row == excelRowCount + 1)
                    break;
                else
                    securityTypeProductSelector.Add(
                       new()
                       {
                           SecurityTypeProductSelector_GeneralLookUpID = worksheet.Cells[row, 3].Value.GetValue<int>(),
                           SecurityTypeProductSelector_ProductID = worksheet.Cells[row, 4].Value.GetValue<int>(),
                           SecurityTypeProductSelector_CouncilZoningTypeID = worksheet.Cells[row, 5].Value.GetValue<int>()
                       });
            }
        }

        return securityTypeProductSelector;
    }

    private static List<RepaymentTypeProductSelector> GetRepaymentTypeProductSelectorsFromExcel(ExcelWorksheet worksheet)
    {
        List<RepaymentTypeProductSelector> repaymentTypeProductSelector = [];

        var rowStartCount = 5;
        int excelRowCount = worksheet.Dimension.End.Row;
        if (excelRowCount > 0)
        {
            for (int row = rowStartCount; row <= excelRowCount; row++)
            {
                if (row == excelRowCount + 1)
                    break;
                else
                    repaymentTypeProductSelector.Add(
                       new()
                       {
                           RepaymentType = worksheet.Cells[row, 3].Value.GetValue<string>() ?? string.Empty,
                           RepaymentTypeProductSelector_CouncilZoningTypeID = worksheet.Cells[row, 4].Value.GetValue<int>(),
                           RateType = worksheet.Cells[row, 5].Value.GetValue<string>() ?? string.Empty,
                           TimeInYears = worksheet.Cells[row, 6].Value.GetValue<int>(),
                           RepaymentTypeProductSelector_ProductID = worksheet.Cells[row, 7].Value.GetValue<int>(),
                           HeedfulPoints = worksheet.Cells[row, 8].Value.GetValue<int>()
                       });
            }
        }

        return repaymentTypeProductSelector;
    }

    private static List<FacilityTypeProductSelector> GetFacilityTypeProductSelectorFromExcel(ExcelWorksheet worksheet)
    {
        List<FacilityTypeProductSelector> facilityTypeProductSelectors = [];

        var rowStartCount = 5;
        int excelRowCount = worksheet.Dimension.End.Row;
        if (excelRowCount > 0)
        {
            for (int row = rowStartCount; row <= excelRowCount; row++)
            {
                if (row == excelRowCount + 1)
                    break;
                else
                    facilityTypeProductSelectors.Add(
                       new()
                       {
                           FacilityTypeProductSelector_GeneralLookUpID = worksheet.Cells[row, 3].Value.GetValue<int>(),
                           FacilityTypeProductSelector_ProductID = worksheet.Cells[row, 4].Value.GetValue<int>(),
                           FacilityTypeProductSelector_CouncilZoningTypeID = worksheet.Cells[row, 5].Value.GetValue<int>()
                       });
            }
        }

        return facilityTypeProductSelectors;
    }

    private static List<GuidedByTypeProductSelector> GetGuidedByTypeProductSelectorFromExcel(ExcelWorksheet worksheet)
    {
        List<GuidedByTypeProductSelector> guidedByTypeProductSelectors = [];

        var rowStartCount = 5;
        int excelRowCount = worksheet.Dimension.End.Row;
        if (excelRowCount > 0)
        {
            for (int row = rowStartCount; row <= excelRowCount; row++)
            {
                if (row == excelRowCount + 1)
                    break;
                else
                    guidedByTypeProductSelectors.Add(
                       new()
                       {
                           GuidedByTypeProductSelector_GeneralLookUpID = worksheet.Cells[row, 3].Value.GetValue<int>(),
                           GuidedByTypeProductSelector_ProductID = worksheet.Cells[row, 4].Value.GetValue<int>(),
                           GuidedByTypeProductSelector_CouncilZoningTypeID = worksheet.Cells[row, 5].Value.GetValue<int>()
                       });
            }
        }

        return guidedByTypeProductSelectors;
    }

    private static List<HeedFullPointTypeProductSelector> GetHeedFullPointsTypeProductSelectorFromExcel(ExcelWorksheet worksheet)
    {
        List<HeedFullPointTypeProductSelector> heedFullPointTypeProductSelector = [];

        var rowStartCount = 5;
        int excelRowCount = worksheet.Dimension.End.Row;
        if (excelRowCount > 0)
        {
            for (int row = rowStartCount; row <= excelRowCount; row++)
            {
                if (row == excelRowCount + 1)
                    break;
                else
                    heedFullPointTypeProductSelector.Add(
                       new()
                       {
                           HeedFullPointTypeProductSelector_GeneralLookUpID = worksheet.Cells[row, 3].Value.GetValue<int>(),
                           HeedFullPointTypeProductSelector_ProductID = worksheet.Cells[row, 4].Value.GetValue<int>(),
                           HeedFullPointTypeProductSelector_CouncilZoningTypeID = worksheet.Cells[row, 5].Value.GetValue<int>(),
                       });
            }
        }

        return heedFullPointTypeProductSelector;
    }

    private static List<NaturalPersonAgeProductSelector> GetNaturalPersonAgeProductSelectorsFromExcel(ExcelWorksheet worksheet)
    {
        List<NaturalPersonAgeProductSelector> naturalPersonAgeProductSelector = [];

        var rowStartCount = 5;
        int excelRowCount = worksheet.Dimension.End.Row;
        if (excelRowCount > 0)
        {
            for (int row = rowStartCount; row <= excelRowCount; row++)
            {
                if (row == excelRowCount + 1)
                    break;
                else
                    naturalPersonAgeProductSelector.Add(
                       new()
                       {
                           NaturalPersonAgeProductSelector_CouncilZoningTypeID = worksheet.Cells[row, 3].Value.GetValue<int>(),
                           MinimumAge = worksheet.Cells[row, 4].Value.GetValue<int>(),
                           MaximumAge = worksheet.Cells[row, 5].Value.GetValue<int>(),
                           NaturalPersonAgeProductSelector_ProductID = worksheet.Cells[row, 6].Value.GetValue<int>(),
                           HeedfulPoints = worksheet.Cells[row, 7].Value.GetValue<int>()
                       });
            }
        }

        return naturalPersonAgeProductSelector;
    }

    private static List<PurchaseTypeProductSelector> GetPurchaseTypeProductSelectorsFromExcel(ExcelWorksheet worksheet)
    {
        List<PurchaseTypeProductSelector> purchaseTypeProductSelector = [];

        var rowStartCount = 5;
        int excelRowCount = worksheet.Dimension.End.Row;
        if (excelRowCount > 0)
        {
            for (int row = rowStartCount; row <= excelRowCount; row++)
            {
                if (row == excelRowCount + 1)
                    break;
                else
                    purchaseTypeProductSelector.Add(
                       new()
                       {
                           PurchaseTypeProductSelector_DocTypeID = worksheet.Cells[row, 3].Value.GetValue<int>(),
                           PurchaseTypeProductSelector_CouncilZoningTypeID = worksheet.Cells[row, 4].Value.GetValue<int>(),
                           OccupancyType = worksheet.Cells[row, 5].Value.GetValue<string>() ?? string.Empty,
                           MinimumLVR = worksheet.Cells[row, 6].Value.GetValue<double>(),
                           MaximumLVR = worksheet.Cells[row, 7].Value.GetValue<double>(),
                           PurchaseTypeProductSelector_ProductID = worksheet.Cells[row, 8].Value.GetValue<int>()
                       });
            }
        }

        return purchaseTypeProductSelector;
    }

    private static List<EmploymentClassificationProductSelector> GetEmploymentClassificationProductSelectorsFromExcel(ExcelWorksheet worksheet)
    {
        List<EmploymentClassificationProductSelector> employmentClassificationProductSelector = [];

        var rowStartCount = 5;
        int excelRowCount = worksheet.Dimension.End.Row;
        if (excelRowCount > 0)
        {
            for (int row = rowStartCount; row <= excelRowCount; row++)
            {
                if (row == excelRowCount + 1)
                    break;
                else
                    employmentClassificationProductSelector.Add(
                       new()
                       {
                           EmploymentClassificationProductSelector_EmploymentClassificationID = worksheet.Cells[row, 3].Value.GetValue<int>(),
                           EmploymentClassificationProductSelector_ProductID = worksheet.Cells[row, 4].Value.GetValue<int>()
                       });
            }
        }

        return employmentClassificationProductSelector;
    }

    private static List<SelfEmployedClassificationProductSelector> GetSelfEmployedClassificationProductSelectorsFromExcel(ExcelWorksheet worksheet)
    {
        List<SelfEmployedClassificationProductSelector> selfEmployedClassificationProductSelector = [];

        var rowStartCount = 5;
        int excelRowCount = worksheet.Dimension.End.Row;
        if (excelRowCount > 0)
        {
            for (int row = rowStartCount; row <= excelRowCount; row++)
            {
                if (row == excelRowCount + 1)
                    break;
                else
                    selfEmployedClassificationProductSelector.Add(
                       new()
                       {
                           SelfEmployedClassificationProductSelector_SelfEmployedClassificationID = worksheet.Cells[row, 3].Value.GetValue<int>(),
                           SelfEmployedClassificationProductSelector_ProductID = worksheet.Cells[row, 4].Value.GetValue<int>()
                       });
            }
        }

        return selfEmployedClassificationProductSelector;
    }

    private static List<EmployerClassificationProductSelector> GetEmployerClassificationProductSelectorsFromExcel(ExcelWorksheet worksheet)
    {
        List<EmployerClassificationProductSelector> employerClassificationProductSelector = [];

        var rowStartCount = 5;
        int excelRowCount = worksheet.Dimension.End.Row;
        if (excelRowCount > 0)
        {
            for (int row = rowStartCount; row <= excelRowCount; row++)
            {
                if (row == excelRowCount + 1)
                    break;
                else
                    employerClassificationProductSelector.Add(
                       new()
                       {
                           EmployerClassificationType = worksheet.Cells[row, 3].Value.GetValue<string>() ?? string.Empty,
                           EmployerClassificationProductSelector_ProductID = worksheet.Cells[row, 4].Value.GetValue<int>()
                       });
            }
        }

        return employerClassificationProductSelector;
    }

    private static List<DwellingsProductSelector> GetDwellingProductsFromExcel(ExcelWorksheet worksheet)
    {
        List<DwellingsProductSelector> dwellingsProductSelector = [];

        var rowStartCount = 5;
        int excelRowCount = worksheet.Dimension.End.Row; // GetDimensionRows(worksheet);

        if (excelRowCount > 0)
        {
            for (int row = rowStartCount; row <= excelRowCount; row++)
            {
                if (row == excelRowCount + 1)
                    break;
                else
                    dwellingsProductSelector.Add(
                       new()
                       {
                           PCCategory = worksheet.Cells[row, 3].Value.GetValue<string>() ?? "",
                           DwellingsProductSelector_ProductID = worksheet.Cells[row, 4].Value.GetValue<int>(),
                           DwellingCount = worksheet.Cells[row, 5].Value.GetValue<int>(),
                       });
            }
        }

        return dwellingsProductSelector;
    }

    private static List<PostcodeProductSelector> GetPostcodeProductSelectorsFromExcel(ExcelWorksheet worksheet)
    {
        List<PostcodeProductSelector> postcodeProductSelector = [];

        var rowStartCount = 5;
        int excelRowCount = worksheet.Dimension.End.Row; 

        if (excelRowCount > 0)
        {
            for (int row = rowStartCount; row <= excelRowCount; row++)
            {
                if (row == excelRowCount + 1)
                    break;
                else
                    postcodeProductSelector.Add(
                       new()
                       {
                           PostcodeProductSelector_PostcodeSpecificationMapperID = worksheet.Cells[row, 3].Value.GetValue<int>(),
                           PostcodeProductSelector_ProductID = worksheet.Cells[row, 4].Value.GetValue<int>(),
                       });
            }
        }

        return postcodeProductSelector;
    }

    private static List<DocTypeProductSelector> GetDocTypeProductSelectorsFromExcel(ExcelWorksheet worksheet)
    {
        List<DocTypeProductSelector> docTypeProductSelector = [];

        var rowStartCount = 5;
        int excelRowCount = worksheet.Dimension.End.Row;

        if (excelRowCount > 0)
        {
            for (int row = rowStartCount; row <= excelRowCount; row++)
            {
                if (row == excelRowCount + 1)
                    break;
                else
                    docTypeProductSelector.Add(
                       new()
                       {
                           DocTypeProductSelector_DocTypeID = worksheet.Cells[row, 2].Value.GetValue<int>(),
                           DocTypeProductSelector_ProductID = worksheet.Cells[row, 3].Value.GetValue<int>(),
                           DocTypeProductSelector_CouncilZoningTypeID = worksheet.Cells[row, 4].Value.GetValue<int>(),
                           MinimumLoanTermInYears = worksheet.Cells[row, 5].Value.GetValue<int>(),
                           MaximumLoanTermInYears = worksheet.Cells[row, 6].Value.GetValue<int>(),
                           HeedfulPoints = worksheet.Cells[row, 7].Value.GetValue<int>()
                       });
            }
        }

        return docTypeProductSelector;
    }


    private static List<BorrowingEntityProductSelector> GetBorrowingEntityProductSelectorsFromExcel(ExcelWorksheet worksheet)
    {
        List<BorrowingEntityProductSelector> borrowingEntityProductSelector = [];

        var rowStartCount = 5;
        int excelRowCount = worksheet.Dimension.End.Row;

        if (excelRowCount > 0)
        {
            for (int row = rowStartCount; row <= excelRowCount; row++)
            {
                if (row == excelRowCount + 1)
                    break;
                else
                    borrowingEntityProductSelector.Add(
                       new()
                       {
                           BorrowingEntityProductSelector_BorrowingEntityTypeID = worksheet.Cells[row, 2].Value.GetValue<int>(),
                           BorrowingEntityProductSelector_CouncilZoningTypeID = worksheet.Cells[row, 3].Value.GetValue<int>(),
                           BorrowingEntityProductSelector_ProductID = worksheet.Cells[row, 4].Value.GetValue<int>(),
                           HeedfulPoints = worksheet.Cells[row, 5].Value.GetValue<int>()
                       });
            }
        }

        return borrowingEntityProductSelector;
    }

    private static List<PostcodeClassification> GetPostcodeClassificationsFromWorkbook(ExcelWorksheet worksheet)
    {
        List<PostcodeClassification> postcodeClassification = [];

        var rowStartCount = 5;
        int excelRowCount = worksheet.Dimension.End.Row; // GetDimensionRows(worksheet);

        if (excelRowCount > 0)
        {
            for (int row = rowStartCount; row <= excelRowCount; row++)
            {
                if (row == excelRowCount + 1)
                    break;
                else
                    postcodeClassification.Add(
                       new()
                       {
                           Name = worksheet.Cells[row, 3].Value.GetValue<string>() ?? "",
                           Value = worksheet.Cells[row, 4].Value.GetValue<string>() ?? ""
                       });
            }
        }

        return postcodeClassification;
    }

    private static List<PostcodeClassificationMapper> GetPostcodeClassificationMapperFromWorkbook(ExcelWorksheet worksheet)
    {
        List<PostcodeClassificationMapper> postcodeClassificationMapper = [];

        var rowStartCount = 5;
        int excelRowCount = worksheet.Dimension.End.Row - 1; // GetDimensionRows(worksheet);

        if (excelRowCount > 0)
        {
            for (int row = rowStartCount; row <= excelRowCount; row++)
            {
                if (row == excelRowCount + 1)
                    break;
                else
                    postcodeClassificationMapper.Add(
                       new()
                       {
                           PostcodeClassificationMapper_PostcodeID = worksheet.Cells[row, 5].Value.GetValue<int>(),
                           PostcodeClassificationMapper_PostcodeClassificationID = worksheet.Cells[row, 6].Value.GetValue<int>()
                       });
            }
        }

        return postcodeClassificationMapper;
    }

    private static List<Dwelling> GetDwellingFromWorkbook(ExcelWorksheet worksheet)
    {
        List<Dwelling> dwellings = [];

        var rowStartCount = 4;
        int excelRowCount = GetDimensionRows(worksheet);

        if (excelRowCount > 0)
        {
            for (int row = rowStartCount; row <= excelRowCount; row++)
            {
                if (row == excelRowCount + 1)
                    break;
                else
                    dwellings.Add(
                       new()
                       {
                           Count = worksheet.Cells[row, 2].Value.GetValue<int>(),
                       });
            }
        }

        return dwellings;
    }

    private static List<NumeralClassification> GetNumeralClassificationFromWorkbook(ExcelWorksheet worksheet)
    {
        List<NumeralClassification> numeralClassifications = [];

        var rowStartCount = 5;
        int excelRowCount = worksheet.Dimension.End.Row;

        if (excelRowCount > 0)
        {
            for (int row = rowStartCount; row <= excelRowCount; row++)
            {
                if (row == excelRowCount + 1)
                    break;
                else
                    numeralClassifications.Add(
                       new()
                       {
                           LoanAmountFrom = worksheet.Cells[row, 3].Value.GetValue<double>(),
                           LoanAmountTo = worksheet.Cells[row, 4].Value.GetValue<double>(),
                           NumeralType = worksheet.Cells[row, 5].Value.GetValue<string>() ?? string.Empty
                       });
            }
        }

        return numeralClassifications;
    }

    private static async Task<List<string>> GetIsLandPostcodes(List<string> isLandPostcodes)
    {
        try
        {
            string filePath = FilesUtility.GetFilePath(ExcelFile.Postcode.FileName);

            var memoryStream = await GetExcelWorkSheet(filePath);

            using ExcelPackage package = new(memoryStream);

            ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

            isLandPostcodes = await GetIsLandPostCodeFromWorkbook(worksheet);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while importing is land postcode from excel", ex);
        }

        return isLandPostcodes;
    }

    private static async Task<List<string>> GetIsLandPostCodeFromWorkbook(ExcelWorksheet worksheet)
    {
        List<string> isLandPostcodes = [];

        var rowStartCount = 5;
        var excelRowCount = worksheet.Rows.Count();

        if (excelRowCount > 0)
        {
            for (int row = rowStartCount; row <= excelRowCount; row++)
            {
                if (row == excelRowCount + 1)
                    break;
                else
                    isLandPostcodes.Add(worksheet.Cells[row, 3].Value.GetValue<string>() ?? "");
            }
        }

        return await Task.FromResult(isLandPostcodes);
    }

    private static List<ProductCatalogue> GetProductCatalogueFromWorkbook(ExcelWorksheet worksheet)
    {
        List<ProductCatalogue> productCatalogues = [];

        var rowStartCount = 3;
        var excelRowCount = worksheet.Rows.Count();

        if (excelRowCount > 0)
        {
            for (int row = rowStartCount; row <= excelRowCount; row++)
            {
                if (row == excelRowCount + 1)
                    break;
                else
                    productCatalogues.Add(
                       new()
                       {
                           RuleDescription = worksheet.Cells[row, 2].Value.GetValue<string>() ?? "",
                           ISUltraPrimeI = worksheet.Cells[row, 3].Value.GetValue<bool>(),
                           ISUltraPrimeII = worksheet.Cells[row, 4].Value.GetValue<bool>(),
                           ISUltraPrimeIII = worksheet.Cells[row, 5].Value.GetValue<bool>(),
                           ISUltraPrimeIV = worksheet.Cells[row, 6].Value.GetValue<bool>(),
                           ISUltraPrimeV = worksheet.Cells[row, 7].Value.GetValue<bool>(),
                           ISSuperPrimeI = worksheet.Cells[row, 8].Value.GetValue<bool>(),
                           ISSuperPrimeII = worksheet.Cells[row, 9].Value.GetValue<bool>(),
                           ISSuperPrimeIII = worksheet.Cells[row, 10].Value.GetValue<bool>(),
                           ISSuperPrimeIV = worksheet.Cells[row, 11].Value.GetValue<bool>(),
                           ISSuperPrimeV = worksheet.Cells[row, 12].Value.GetValue<bool>(),
                           ISPremiumI = worksheet.Cells[row, 13].Value.GetValue<bool>(),
                           ISPremiumII = worksheet.Cells[row, 14].Value.GetValue<bool>(),
                           ISPremiumIII = worksheet.Cells[row, 15].Value.GetValue<bool>(),
                           ISPremiumIV = worksheet.Cells[row, 16].Value.GetValue<bool>(),
                           ISPremiumV = worksheet.Cells[row, 17].Value.GetValue<bool>(),
                           ISOptimaxI = worksheet.Cells[row, 18].Value.GetValue<bool>(),
                           ISOptimaxII = worksheet.Cells[row, 19].Value.GetValue<bool>(),
                           ISOptimaxIII = worksheet.Cells[row, 20].Value.GetValue<bool>(),
                           ISOptimaxIV = worksheet.Cells[row, 21].Value.GetValue<bool>(),
                           ISOptimaxV = worksheet.Cells[row, 22].Value.GetValue<bool>(),
                           ISTolerantI = worksheet.Cells[row, 23].Value.GetValue<bool>(),
                           ISTolerantII = worksheet.Cells[row, 24].Value.GetValue<bool>(),
                           ISTolerantIII = worksheet.Cells[row, 25].Value.GetValue<bool>(),
                           ISTolerantIV = worksheet.Cells[row, 26].Value.GetValue<bool>(),
                           ISTolerantV = worksheet.Cells[row, 27].Value.GetValue<bool>(),
                           ISProgressiveI = worksheet.Cells[row, 28].Value.GetValue<bool>(),
                           ISProgressiveII = worksheet.Cells[row, 29].Value.GetValue<bool>(),
                           ISProgressiveIII = worksheet.Cells[row, 30].Value.GetValue<bool>(),
                           ISProgressiveIV = worksheet.Cells[row, 31].Value.GetValue<bool>(),
                           ISProgressiveV = worksheet.Cells[row, 32].Value.GetValue<bool>(),
                           ISReceptiveI = worksheet.Cells[row, 33].Value.GetValue<bool>(),
                           ISReceptiveII = worksheet.Cells[row, 34].Value.GetValue<bool>(),
                           ISReceptiveIII = worksheet.Cells[row, 35].Value.GetValue<bool>(),
                           ISReceptiveIV = worksheet.Cells[row, 36].Value.GetValue<bool>(),
                           ISReceptiveV = worksheet.Cells[row, 37].Value.GetValue<bool>(),
                           ISLiberalI = worksheet.Cells[row, 38].Value.GetValue<bool>(),
                           ISLiberalII = worksheet.Cells[row, 39].Value.GetValue<bool>(),
                           ISLiberalIII = worksheet.Cells[row, 40].Value.GetValue<bool>(),
                           ISLiberalIV = worksheet.Cells[row, 41].Value.GetValue<bool>(),
                           ISLiberalV = worksheet.Cells[row, 42].Value.GetValue<bool>()
                       });
            }
        }

        return productCatalogues;
    }

    private static async Task<MemoryStream> GetExcelWorkSheet(string filePath)
    {
        try
        {
            MemoryStream memoryStream = new();

            using (FileStream fileStream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                await fileStream.CopyToAsync(memoryStream);
            }

            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            return memoryStream;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while importing standard and poor postcodes from excel", ex);
        }
    }

    private static List<ProductFeeLVRRate> BaseIncrementPercent(ExcelWorksheet worksheet)
    {
        List<ProductFeeLVRRate> baseIncrementPercent = [];

        var rowStartCount = 2;
        var excelRowCount = worksheet.Rows.Count();

        if (excelRowCount > 0)
        {
            for (int row = rowStartCount; row <= excelRowCount;)
            {
                baseIncrementPercent.Add(
                       new()
                       {
                           ProductFeeLVRRate_ProductID = worksheet.Cells[row, 2].Value.GetValue<int>(),
                           LVRFrom = worksheet.Cells[row, 3].Value.GetValue<double>(),
                           LVRTo = worksheet.Cells[row, 4].Value.GetValue<double>(),
                           ProductFeeLVRRate_DocTypeID = worksheet.Cells[row, 5].Value.GetValue<int>(),
                           FeeType = worksheet.Cells[row, 6].Value.GetValue<string>() ?? string.Empty,
                           RatePercentIncrementDecrement = worksheet.Cells[row, 7].Value.GetValue<double>()
                       });
                row++;
            }
        }

        return baseIncrementPercent;
    }

    private static List<AdditionalFee> AdditionalFee(ExcelWorksheet worksheet)
    {
        List<AdditionalFee> additionalFee = [];

        var rowStartCount = 2;
        var excelRowCount = worksheet.Rows.Count();

        if (excelRowCount > 0)
        {
            for (int row = rowStartCount; row <= excelRowCount;)
            {
                additionalFee.Add(
                       new()
                       {
                           AdditionalFee_LoanToValueRatioID = worksheet.Cells[row, 2].Value.GetValue<int>(),
                           AdditionalFee_DocTypeID = worksheet.Cells[row, 3].Value.GetValue<int>(),
                           AdditionalFee_VacantLandCategoryID = worksheet.Cells[row, 4].Value.GetValue<int>(),
                           AdditionalFee_LandSizeID = worksheet.Cells[row, 5].Value.GetValue<int>(),
                           IncrementFee = worksheet.Cells[row, 6].Value.GetValue<double>(),
                           FeeType = worksheet.Cells[row, 7].Value.GetValue<string>() ?? string.Empty
                       });
                row++;
            }
        }

        return additionalFee;
    }

    private static List<ScenarioBuilder> ScenarioBuilder(ExcelWorksheet worksheet)
    {
        List<ScenarioBuilder> scenarioBuilders = [];

        var rowStartCount = 2;
        var excelRowCount = worksheet.Rows.Count();

        if (excelRowCount > 0)
        {
            for (int row = rowStartCount; row <= excelRowCount;)
            {
                scenarioBuilders.Add(
                       new()
                       {
                           CategoryType = worksheet.Cells[row, 2].Value.GetValue<string>(),
                           ISSelectedMetro = worksheet.Cells[row, 3].Value.GetValue<bool>(),
                           PCCategory = worksheet.Cells[row, 4].Value.GetValue<string>(),
                           ISOwnerOccupied = worksheet.Cells[row, 5].Value.GetValue<bool>(),
                           CouncilZoning = worksheet.Cells[row, 6].Value.GetValue<string>(),
                           ISNaturalPerson = worksheet.Cells[row, 7].Value.GetValue<bool>(),
                           ISHighDensity = worksheet.Cells[row, 8].Value.GetValue<bool>(),
                           FormulaType = worksheet.Cells[row, 9].Value.GetValue<string>(),
                           ScenarioBuilder_VacantLandCategoryID = worksheet.Cells[row, 10].Value.GetValue<int>(),
                           ScenarioBuilder_RelocationServicingID = worksheet.Cells[row, 11].Value.GetValue<int>(),
                       });
                row++;
            }
        }

        return scenarioBuilders;
    }

    private static List<DefaultFee> BaseFee(ExcelWorksheet worksheet)
    {
        List<DefaultFee> baseFee = [];

        var rowStartCount = 2;
        var excelRowCount = worksheet.Rows.Count();

        if (excelRowCount > 0)
        {
            for (int row = rowStartCount; row <= excelRowCount;)
            {
                baseFee.Add(
                       new()
                       {
                           FormulaType = worksheet.Cells[row, 2].Value.GetValue<string>(),
                           DefaultFee_DocTypeID = worksheet.Cells[row, 3].Value.GetValue<int>(),
                           DefaultFee_LoanToValueRatioID = worksheet.Cells[row, 4].Value.GetValue<int>(),
                           DefaultFee_ProductID = worksheet.Cells[row, 5].Value.GetValue<int>(),
                           ApplicationFee = worksheet.Cells[row, 6].Value.GetValue<double>(),
                           AnnualFee = worksheet.Cells[row, 7].Value.GetValue<double>(),
                           RiskFee = worksheet.Cells[row, 8].Value.GetValue<double>(),
                           EstablishmentFee = worksheet.Cells[row, 9].Value.GetValue<double>(),
                           SettlementFee = worksheet.Cells[row, 10].Value.GetValue<double>(),
                           DischargeFee = worksheet.Cells[row, 11].Value.GetValue<double>(),
                           RateLoadingFee = worksheet.Cells[row, 12].Value.GetValue<double>(),
                           DeedOfPriorityFee = worksheet.Cells[row, 13].Value.GetValue<double>(),
                           ExpressFee = worksheet.Cells[row, 14].Value.GetValue<double>(),
                       });
                row++;
            }
        }

        return baseFee;
    }

    private static List<LandSize> LandSize(ExcelWorksheet worksheet)
    {
        List<LandSize> landSize = [];

        var rowStartCount = 2;
        var excelRowCount = worksheet.Rows.Count();

        if (excelRowCount > 0)
        {
            for (int row = rowStartCount; row <= excelRowCount;)
            {
                landSize.Add(
                       new()
                       {
                           From = worksheet.Cells[row, 2].Value.GetValue<double>(),
                           To = worksheet.Cells[row, 3].Value.GetValue<double>(),
                       });
                row++;
            }
        }

        return landSize;
    }

    private static List<AdditionalFeeDocTypeVariation> AdditionalFeeDocTypeVariation(ExcelWorksheet worksheet)
    {
        List<AdditionalFeeDocTypeVariation> additionalFeeDocTypeVariation = [];

        var rowStartCount = 2;
        var excelRowCount = worksheet.Rows.Count();

        if (excelRowCount > 0)
        {
            for (int row = rowStartCount; row <= excelRowCount;)
            {
                additionalFeeDocTypeVariation.Add(
                       new()
                       {
                           AdditionalFeeDocTypeVariation_DocTypeID = worksheet.Cells[row, 2].Value.GetValue<int>(),
                           FormulaType = worksheet.Cells[row, 3].Value.GetValue<string>() ?? string.Empty,
                           FeeType = worksheet.Cells[row, 4].Value.GetValue<string>() ?? string.Empty,
                           Value = worksheet.Cells[row, 5].Value.GetValue<double>()
                       });
                row++;
            }
        }

        return additionalFeeDocTypeVariation;
    }

    private static int GetDimensionRows(ExcelWorksheet sheet)
    {
        var startRow = sheet.Dimension.Start.Row;
        var endRow = sheet.Dimension.End.Row;
        return endRow - startRow;
    }

    private static bool CheckProductName(string? productName)
    {
        return typeof(ProductName).GetFields()
            .Any(field =>
            {
                var value = field.GetValue(null);
                return value != null && value.ToString()?.Replace(" ", "").ToLower() == productName?.Replace(" ", "").ToLower();
            });
    }

    #endregion
}
