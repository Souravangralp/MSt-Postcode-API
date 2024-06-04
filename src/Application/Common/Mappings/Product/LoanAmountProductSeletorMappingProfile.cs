namespace ProductMatrix.Application.Common.Mappings.Product;

public class LoanAmountProductSeletorMappingProfile : Profile
{
    public LoanAmountProductSeletorMappingProfile()
    {
        CreateMap<LoanAmountProductSelector, LoanAmountProductSelectorDto>().ReverseMap();
    }
}
