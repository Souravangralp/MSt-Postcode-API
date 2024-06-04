using System.ComponentModel.DataAnnotations;

namespace ProductMatrix.Domain.Enums;

public enum PostcodeTypes
{
    [Display(Name = nameof(Excluded))]
    Excluded = 1999,
}
