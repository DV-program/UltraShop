namespace Ultra.Api.DTOs;
using System.ComponentModel.DataAnnotations;

public class UpdateProductDto
{
    [StringLength(100)]
    public string? Name {get; set;}
    
    [Range(0, double.MaxValue)]
    public decimal? Price {get; set;}
    
    [Range(1, int.MaxValue)]
    public int? CategoryId {get; set;}
}
