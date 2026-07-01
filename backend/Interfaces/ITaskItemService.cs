using Progredi.DTOs.TaskItem;
using Progredi.DataAccess.Entities;

namespace Progredi.Interfaces;

public interface ITaskItemService
{
    public async Task<TaskItemResponseDto> CreateAsync(Guid userId, CreateTaskItemDto dto);
    public async Task<TaskItemResponseDto> UpdateAsync(Guid userId, Guid taskItemId, UpdateTaskItemDto dto);
    public async Task<TaskItemResponseDto> DeleteAsync(Guid userId, Guid taskItemId);
}
