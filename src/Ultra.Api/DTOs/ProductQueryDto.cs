namespace Ultra.Api.DTOs;
using System.ComponentModel.DataAnnotations;
public class ProductQueryDto
{
    [Range (1, int.MaxValue)]
    public int Page {get; set;} = 1;

    [Range (1, int.MaxValue)]
    public int PageSize {get; set;} = 20;
    
    [Range (0.00, float.MaxValue)]
    public decimal MinPrice {get; set;} = 0;
    
    [Range (0.00, float.MaxValue)]
    public decimal MaxPrice {get; set;} = decimal.MaxValue;
    
    [StringLength(200)]
    public string? Search {get; set;}
}