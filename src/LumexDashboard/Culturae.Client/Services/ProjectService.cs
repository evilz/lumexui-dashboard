using System.Net.Http.Json;

namespace Culturae.Client.Services;

public class ProjectService(HttpClient http)
{
    public async Task<PagedResult<ProjectDto>?> GetOpenProjectsAsync(int page = 1, int pageSize = 6)
    {
        return await http.GetFromJsonAsync<PagedResult<ProjectDto>>(
            $"api/projects?page={page}&pageSize={pageSize}");
    }
}
