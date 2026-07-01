using System.ComponentModel.DataAnnotations;
using Progredi.DTOs.Category;

namespace Progredi.DTOs.TaskItem;

public class TaskItemResponseDto
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public bool IsCompleted { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? DueDate { get; set; }

    public Guid TaskListId { get; set; }

    public IEnumerable<CategoryResponseDto> Categories { get; set; } = [];
}