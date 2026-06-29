using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Progredi.DTOs.Category;
using Progredi.Extensions; // Підключаємо наш метод розширення
using Progredi.Interfaces;

namespace Progredi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class CategoryController(ICategoryService categoryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoryDto dto)
    {
        Guid userId = User.GetUserId(); 
        
        var category = await categoryService.CreateAsync(userId, dto);
        
        return Ok(category);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        Guid userId = User.GetUserId();
        var categories = await categoryService.GetAllByUserIdAsync(userId);
        return Ok(categories);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCategoryDto dto)
    {
        Guid userId = User.GetUserId();
        var category = await categoryService.UpdateAsync(userId, id, dto);
        return Ok(category);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        Guid userId = User.GetUserId();
        var category = await categoryService.DeleteAsync(userId, id);
        
        return Ok(category); 
    }
}