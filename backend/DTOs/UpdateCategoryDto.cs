using System.ComponentModel.DataAnnotations;

namespace Progredi.DTOs.Category;

public class UpdateCategoryDto
{
    [Required(ErrorMessage = "Category name is required")]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Category background color is required")]
    [MaxLength(7)]
    public string BackgroundColorHex { get; set; } = string.Empty;
}