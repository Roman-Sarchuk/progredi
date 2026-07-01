using System.ComponentModel.DataAnnotations;

namespace Progredi.DTOs.TaskItem;

public class UpdateTaskItemDto
{
    [Required(ErrorMessage = "Task title is required")]
    [MaxLength(100)]
    public string Title { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Task completion status is required")]
    public bool IsCompleted { get; set; }   

    public DateTime? DueDate { get; set; }

    [Required(ErrorMessage = "Task category IDs are required")]
    public List<Guid> CategoryIds { get; set; }
}