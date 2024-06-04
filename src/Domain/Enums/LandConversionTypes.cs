using System.ComponentModel.DataAnnotations;

namespace ProductMatrix.Domain.Enums;

public enum LandConversionTypes
{
    [Display(Name = nameof(MeterSquare))]
    MeterSquare = 1,

    [Display(Name = nameof(Acres))]
    Acres = 2
}
