namespace Ultra.Api.DTOs;
using System.ComponentModel.DataAnnotations;
public class GetProductDto
{
    public int Id {get; set;}
    public string Name {get; set;} = string.Empty;
    public decimal Price {get; set;}
    public required string CategoryName {get; set;}
}