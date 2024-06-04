namespace ProductMatrix.Application.Common.Mappings;

public class DocTypeProductSelectorMappingProfile : Profile
{
    public DocTypeProductSelectorMappingProfile()
    {
        CreateMap<DocTypeProductSelector, DocTypeProductSelectorDto>().ReverseMap();
    }
}
