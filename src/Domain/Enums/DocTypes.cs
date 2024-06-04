using System.ComponentModel.DataAnnotations;

namespace ProductMatrix.Domain.Enums;

public enum DocTypes
{
    [Display(Name = nameof(AltDoc))]
    AltDoc = 1,

    [Display(Name = nameof(FullDoc))]
    FullDoc = 2,

    [Display(Name = nameof(LowDoc))]
    LowDoc = 3,

    [Display(Name = nameof(NoDoc))]
    NoDoc = 4,
}
