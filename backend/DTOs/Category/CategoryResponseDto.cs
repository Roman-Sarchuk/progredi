namespace Progredi.DTOs.Category;

public class CategoryResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string BackgroundColorHex { get; set; } = string.Empty;    
}