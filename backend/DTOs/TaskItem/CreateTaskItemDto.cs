using System.ComponentModel.DataAnnotations;

namespace Progredi.DTOs.TaskItem;

public class CreateTaskItemDto
{
    [Required(ErrorMessage = "Task title is required")]
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Description { get; set; }

    public DateTime? DueDate { get; set; }

    [Required(ErrorMessage = "Task list ID is required")]
    public Guid TaskListId { get; set; }

    [Required(ErrorMessage = "Task category IDs are required")]
    public List<Guid> CategoryIds { get; set; } = [];
}