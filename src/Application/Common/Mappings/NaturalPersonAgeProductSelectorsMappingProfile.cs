namespace ProductMatrix.Application.Common.Mappings;

public class NaturalPersonAgeProductSelectorsMappingProfile : Profile
{
    public NaturalPersonAgeProductSelectorsMappingProfile()
    {
        CreateMap<NaturalPersonAgeProductSelector, AgeOfNaturalPersonProductSelectorDto>().ReverseMap();
    }
}
