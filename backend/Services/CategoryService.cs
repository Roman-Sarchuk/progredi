using Microsoft.EntityFrameworkCore;
using Progredi.DataAccess;
using Progredi.DataAccess.Entities;
using Progredi.DTOs.Category;
using Progredi.Interfaces;
using Progredi.Exceptions;

namespace Progredi.Services;

public class CategoryService(AppDbContext context) : ICategoryService
{
    public async Task<CategoryResponseDto> CreateAsync(Guid userId, CreateCategoryDto dto)
    {
        var category = new Category
        {
            Name = dto.Name,
            BackgroundColorHex = dto.BackgroundColorHex,
            UserId = userId 
        };

        context.Categories.Add(category);
        await context.SaveChangesAsync();
        
        return new CategoryResponseDto
        {
            Id = category.Id,
            Name = category.Name,
            BackgroundColorHex = category.BackgroundColorHex
        };
    }

    public async Task<IEnumerable<CategoryResponseDto>> GetAllByUserIdAsync(Guid userId)
    {
        return await context.Categories
            .Where(c => c.UserId == userId)
            .Select(c => new CategoryResponseDto
            {
                Id = c.Id,
                Name = c.Name,
                BackgroundColorHex = c.BackgroundColorHex
            })
            .ToListAsync();
    }

    public async Task<CategoryResponseDto> DeleteAsync(Guid userId, Guid categoryId)
    {
        var category = await context.Categories
            .FirstOrDefaultAsync(c => c.Id == categoryId && c.UserId == userId);

        if (category == null)
        {
            throw new NotFoundException("Category not found or access denied.");
        }

        context.Categories.Remove(category);
        await context.SaveChangesAsync();

        return new CategoryResponseDto
        {
            Id = category.Id,
            Name = category.Name,
            BackgroundColorHex = category.BackgroundColorHex
        };
    }

    public async Task<CategoryResponseDto> UpdateAsync(Guid userId, Guid categoryId, UpdateCategoryDto dto)
    {
        var category = await context.Categories
            .FirstOrDefaultAsync(c => c.Id == categoryId && c.UserId == userId);

        if (category == null)
        {
            throw new NotFoundException("Category not found or access denied.");
        }

        category.Name = dto.Name;
        category.BackgroundColorHex = dto.BackgroundColorHex;

        await context.SaveChangesAsync();

        return new CategoryResponseDto
        {
            Id = category.Id,
            Name = category.Name,
            BackgroundColorHex = category.BackgroundColorHex
        };
    }
}