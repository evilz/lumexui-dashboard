using Culturae.API.DTOs;

namespace Culturae.API.Services;

public interface IProjectService
{
    Task<PagedResult<ProjectDto>> GetOpenProjectsAsync(int page, int pageSize);
}
