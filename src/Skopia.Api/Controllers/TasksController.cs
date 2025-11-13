using Microsoft.AspNetCore.Mvc;
using Skopia.Core.Enums;
using Skopia.Core.Services;

namespace Skopia.Api.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _svc;
        public TasksController(ITaskService svc) => _svc = svc;

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _svc.ListAsync());

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var t = await _svc.GetAsync(id);
            return t == null ? NotFound() : Ok(t);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTaskRequest req)
        {
            var created = await _svc.CreateAsync(req.Title, req.ProjectId);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPatch("{id:guid}/status")]
        public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] UpdateStatusRequest req)
        {
            var updated = await _svc.UpdateStatusAsync(id, (TaskState)req.Status);
            return updated == null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _svc.DeleteAsync(id);
            return NoContent();
        }
    }

    public record CreateTaskRequest(string Title, Guid ProjectId);
    public record UpdateStatusRequest(int Status); // client sends enum int; can change to string mapping if preferred

}
