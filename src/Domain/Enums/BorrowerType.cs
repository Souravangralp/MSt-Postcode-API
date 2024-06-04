using System.ComponentModel.DataAnnotations;

namespace ProductMatrix.Domain.Enums;

public enum BorrowerType
{
    [Display(Name = nameof(GoodBorrower))]
    GoodBorrower = 1 ,

    [Display(Name = nameof(Specialist))]
    Specialist = 2
}
