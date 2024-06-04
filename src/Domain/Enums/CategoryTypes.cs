using System.ComponentModel.DataAnnotations;

namespace ProductMatrix.Domain.Enums;

public enum CategoryTypes
{
    [Display(Name = nameof(Category1))]
    Category1 = 1,

    [Display(Name = nameof(Category1))]
    Category2 = 2,

    [Display(Name = nameof(Category3))]
    Category3 = 3,

    [Display(Name = nameof(Category4))]
    Category4 = 4,
}
