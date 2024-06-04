namespace ProductMatrix.Domain.Enums;

public enum FilterType
{
    ResidentialLoanAmount = 2,
    CommercialLoanAmount = 9,
    SMSFResidentialLoanAmount = 21,

    ResidentialDocType = 4,
    CommercialDocType = 10,
    SMSFResidentialDocType = 22,

    ResidentialAgeOfNaturalPerson = 5,
    CommercialAgeOfNaturalPerson = 11,

    ResidentialConstruction = 6,
    CommercialConstruction = 12,
    SMSFResidentialConstruction = 25,

    ResidentialConstructionGreen = 7,
    CommercialConstructionGreen = 13,
    SMSFResidentialConstructionGreen = 26,
    
    ResidentialBorrowingEntity = 16,
    CommercialBorrowingEntity = 17,
    SMSFResidentialBorrowingEntity = 23,

    ResidentialZoningType = 18,
    CommercialZoningType = 19,
    SMSFResidentialZoningType = 24,

    ResidentialRenovationWithNoStructuralChanges = 14,
    ResidentialRenovationWithStructuralChanges = 15,

    ResidentialFacilityType = 27,

    ResidentialEmploymentClassification = 28,

    ResidentialRepaymentType = 29,

    ResidentialGuidedByType = 30,

    ResidentialHeedFullPointType = 31,

    ResidentialUsageType = 32,

    ResidentialServiceType = 33,

    ResidentialSecurityType = 34,

    ResidentialButtonType = 35,

    ResidentialLandSize = 36,

    ResidentialApplicationObjective = 37,

    ResidentialDwelling = 38,
}
