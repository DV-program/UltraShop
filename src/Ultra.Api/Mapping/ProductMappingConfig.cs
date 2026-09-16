using Mapster;
using Ultra.Api.DTOs;
using Ultra.Api.Models;

namespace Ultra.Api.Mappings;
public class ProductMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Product, GetProductDto>().Map(
            dest => dest.CategoryName,
            src => src.Category.Name);
    }
}