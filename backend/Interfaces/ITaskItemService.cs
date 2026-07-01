using Progredi.DTOs.TaskItem;
using Progredi.DataAccess.Entities;

namespace Progredi.Interfaces;

public interface ITaskItemService
{
    public Task<TaskItemResponseDto> CreateAsync(Guid userId, CreateTaskItemDto dto);
    public Task<TaskItemResponseDto> UpdateAsync(Guid userId, Guid taskItemId, UpdateTaskItemDto dto);
    public Task<TaskItemResponseDto> DeleteAsync(Guid userId, Guid taskItemId);
}
