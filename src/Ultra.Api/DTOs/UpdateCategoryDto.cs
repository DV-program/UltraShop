using System.ComponentModel.DataAnnotations;

namespace Ultra.Api.DTOs;

public class UpdateCategoryDto
{
    [StringLength(100)]
    public string? Name {get; set;}
}
