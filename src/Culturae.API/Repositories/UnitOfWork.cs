using Culturae.API.Data;

namespace Culturae.API.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    private IProjectRepository? _projects;

    public IProjectRepository Projects => _projects ??= new ProjectRepository(context);

    public async Task<int> SaveChangesAsync() => await context.SaveChangesAsync();
}
