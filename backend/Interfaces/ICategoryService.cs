using Progredi.DTOs.Category;
using Progredi.DataAccess.Entities;

namespace Progredi.Interfaces;

public interface ICategoryService
{
    Task<Category> CreateAsync(Guid userId, CreateCategoryDto dto);
    Task<IEnumerable<Category>> GetAllByUserIdAsync(Guid userId);
    Task<Category> DeleteAsync(Guid userId, Guid categoryId);
    Task<Category> UpdateAsync(Guid userId, Guid categoryId, UpdateCategoryDto dto);
}