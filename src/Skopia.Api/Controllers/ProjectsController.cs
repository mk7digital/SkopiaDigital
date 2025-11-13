using Microsoft.AspNetCore.Mvc;
using Skopia.Core.Services;

namespace Skopia.Api.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        // GET api/projects
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var projects = await _projectService.ListAsync(cancellationToken);
            return Ok(projects);
        }

        // GET api/projects/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            var project = await _projectService.GetAsync(id, cancellationToken);
            return project is null ? NotFound() : Ok(project);
        }

        // POST api/projects
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProjectRequest request, CancellationToken cancellationToken)
        {
            if (request is null) return BadRequest("Request body is required.");
            if (string.IsNullOrWhiteSpace(request.Name)) return BadRequest("Name is required.");

            var created = await _projectService.CreateAsync(request.Name, cancellationToken);

            // Retorna 201 Created com o objeto criado no corpo e Location apontando para GET api/projects/{id}
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        // DELETE api/projects/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _projectService.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
    }

    // DTOs específicos da API layer
    public record CreateProjectRequest(string Name);

}
