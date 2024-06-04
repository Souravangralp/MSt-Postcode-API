using ProductMatrix.Application.Products.Queries.CalculateProductFee;

namespace ProductMatrix.Application.Common.Mappings.Calculator;

public class CalculateProductFeeMappingProfile : Profile
{
    public CalculateProductFeeMappingProfile()
    {
        CreateMap<CalculateProductFee, ProductFeeDto>().ReverseMap();
    }
}
