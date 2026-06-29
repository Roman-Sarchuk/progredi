using Progredi.DTOs.Category;
using Progredi.DataAccess.Entities;

namespace Progredi.Interfaces;

public interface ICategoryService
{
    Task<CategoryResponseDto> CreateAsync(Guid userId, CreateCategoryDto dto);
    Task<IEnumerable<CategoryResponseDto>> GetAllByUserIdAsync(Guid userId);
    Task<CategoryResponseDto> DeleteAsync(Guid userId, Guid categoryId);
    Task<CategoryResponseDto> UpdateAsync(Guid userId, Guid categoryId, UpdateCategoryDto dto);
}