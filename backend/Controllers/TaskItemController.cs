using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Progredi.DTOs.TaskItem;
using Progredi.Extensions;
using Progredi.Interfaces;

namespace Progredi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class TaskItemController(ITaskItemService taskItemService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTaskItemDto dto)
    {
        Guid userId = User.GetUserId(); 
        
        var taskItem = await taskItemService.CreateAsync(userId, dto);
        
        return Ok(taskItem);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTaskItemDto dto)
    {
        Guid userId = User.GetUserId();

        var taskItem = await taskItemService.UpdateAsync(userId, id, dto);
        
        return Ok(taskItem);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        Guid userId = User.GetUserId();

        var taskItem = await taskItemService.DeleteAsync(userId, id);
        
        return Ok(taskItem); 
    }
}