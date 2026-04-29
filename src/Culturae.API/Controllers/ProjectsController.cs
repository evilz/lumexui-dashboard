using Culturae.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Culturae.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController(IProjectService projectService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetOpenProjects([FromQuery] int page = 1, [FromQuery] int pageSize = 6)
    {
        if (page < 1) page = 1;
        if (pageSize < 1 || pageSize > 50) pageSize = 6;

        var result = await projectService.GetOpenProjectsAsync(page, pageSize);
        return Ok(result);
    }
}
