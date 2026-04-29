using Culturae.API.Entities;

namespace Culturae.API.Repositories;

public interface IProjectRepository
{
    Task<List<Project>> GetPagedAsync(int page, int pageSize);
    Task<int> GetTotalCountAsync();
}
