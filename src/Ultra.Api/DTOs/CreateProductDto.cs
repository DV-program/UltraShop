using System.ComponentModel.DataAnnotations;

namespace Ultra.Api.DTOs;

public class CreateProductDto
{
    [Required]
    [StringLength(100)]
    public string Name {get; set;} = string.Empty;
    [Required]
    [Range(0.00, 200000000.00)]
    public decimal Price {get; set;}
    
    [Required]
    [Range(1, int.MaxValue)]
    public int CategoryId {get; set;}
}
