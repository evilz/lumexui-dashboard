namespace Culturae.API.Repositories;

public interface IUnitOfWork
{
    IProjectRepository Projects { get; }
    Task<int> SaveChangesAsync();
}
