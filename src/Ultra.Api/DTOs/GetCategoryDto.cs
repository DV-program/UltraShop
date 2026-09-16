namespace Ultra.Api.DTOs;

public class GetCategoryDto
{
    public int Id {get; set;}
    public string Name {get; set;} = string.Empty;
    public List<GetCategoryProductDto> Products {get; set;} = [];
}
