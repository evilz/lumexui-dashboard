using Culturae.API.DTOs;
using Culturae.API.Repositories;

namespace Culturae.API.Services;

public class ProjectService(IUnitOfWork unitOfWork) : IProjectService
{
    public async Task<PagedResult<ProjectDto>> GetOpenProjectsAsync(int page, int pageSize)
    {
        var projects = await unitOfWork.Projects.GetPagedAsync(page, pageSize);
        var totalCount = await unitOfWork.Projects.GetTotalCountAsync();

        var items = projects.Select(p => new ProjectDto(
            p.Id,
            p.Name,
            p.Description,
            p.AmountNeeded,
            p.PublicationDate
        )).ToList();

        return new PagedResult<ProjectDto>(items, totalCount, page, pageSize);
    }
}
