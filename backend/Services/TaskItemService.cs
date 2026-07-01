using Microsoft.EntityFrameworkCore;
using Progredi.DataAccess;
using Progredi.DataAccess.Entities;
using Progredi.DTOs.TaskItem;
using Progredi.Interfaces;
using Progredi.Exceptions;

namespace Progredi.Services;

public class TaskItemService(AppDbContext context) : ITaskItemService
{
    public async Task<TaskItemResponseDto> CreateAsync(Guid userId, CreateTaskItemDto dto)
    {
        var taskListExists = await context.TaskLists
            .AnyAsync(tl => tl.Id == dto.TaskListId && tl.UserId == userId);
            
        if (!taskListExists)
            throw new NotFoundException("Task list not found.");

        var newTaskItem = new TaskItem
        {
            Title = dto.Title,
            Description = dto.Description,
            DueDate = dto.DueDate,
            TaskListId = dto.TaskListId
        };

        if (dto.CategoryIds.Any())
            newTaskItem.Categories = await FindAndValidateTaskItemCategoriesAsync(dto.CategoryIds, userId);

        context.TaskItems.Add(newTaskItem);
        await context.SaveChangesAsync();

        return MapToResponseDto(newTaskItem);
    }

    public async Task<TaskItemResponseDto> UpdateAsync(Guid userId, Guid taskItemId, UpdateTaskItemDto dto)
    {
        var existingTaskItem = await context.TaskItems
            .Include(t => t.Categories)
            .FirstOrDefaultAsync(t => t.Id == taskItemId && t.TaskList.UserId == userId);
        
        if (existingTaskItem == null)
            throw new NotFoundException("Task item not found.");

        existingTaskItem.Title = dto.Title;
        existingTaskItem.Description = dto.Description;
        existingTaskItem.IsCompleted = dto.IsCompleted;
        existingTaskItem.DueDate = dto.DueDate;

        if (dto.CategoryIds.Any())
            existingTaskItem.Categories = await FindAndValidateTaskItemCategoriesAsync(dto.CategoryIds, userId);
        else
            existingTaskItem.Categories.Clear();

        await context.SaveChangesAsync();

        return MapToResponseDto(existingTaskItem);
    }

    public async Task<TaskItemResponseDto> DeleteAsync(Guid userId, Guid taskItemId) 
    {
        var existingTaskItem = await context.TaskItems
            .Include(t => t.Categories)
            .FirstOrDefaultAsync(t => t.Id == taskItemId && t.TaskList.UserId == userId);
        
        if (existingTaskItem == null)
            throw new NotFoundException("Task item not found.");

        context.TaskItems.Remove(existingTaskItem);
        await context.SaveChangesAsync();

        return MapToResponseDto(existingTaskItem);
    }

    private async Task<List<Category>> FindAndValidateTaskItemCategoriesAsync(List<Guid> categoryIds, Guid userId)
    {
        var foundedCategories = await context.Categories
            .Where(c => categoryIds.Contains(c.Id) && c.UserId == userId)
            .ToListAsync();
        
        if (foundedCategories.Count != categoryIds.Count)
            throw new NotFoundException("One or more categories not found.");
        
        return foundedCategories;
    }

    private static TaskItemResponseDto MapToResponseDto(TaskItem taskItem)
    {
        return new TaskItemResponseDto
        {
            Id = taskItem.Id,
            Title = taskItem.Title,
            Description = taskItem.Description,
            IsCompleted = taskItem.IsCompleted,
            CreatedAt = taskItem.CreatedAt,
            DueDate = taskItem.DueDate,
            TaskListId = taskItem.TaskListId,
            Categories = taskItem.Categories.Select(c => new CategoryResponseDto
            {
                Id = c.Id,
                Name = c.Name,
                BackgroundColorHex = c.BackgroundColorHex
            }).ToList()
        };
    }
}
