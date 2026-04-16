using Culturae.API.Data;
using Culturae.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Culturae.API.Repositories;

public class ProjectRepository(AppDbContext context) : IProjectRepository
{
    public async Task<List<Project>> GetPagedAsync(int page, int pageSize)
    {
        return await context.Projects
            .OrderByDescending(p => p.PublicationDate)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<int> GetTotalCountAsync()
    {
        return await context.Projects.CountAsync();
    }
}
