using Culturae.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Culturae.API.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Project> Projects => Set<Project>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Project>().HasData(
            new Project
            {
                Id = Guid.Parse("a1b2c3d4-0001-0000-0000-000000000001"),
                Name = "Teatro Real Season 2026",
                Description = "Funding for the new opera season at Teatro Real in Madrid, featuring world-class performances and innovative stage design.",
                AmountNeeded = 250_000m,
                PublicationDate = new DateTime(2026, 1, 15)
            },
            new Project
            {
                Id = Guid.Parse("a1b2c3d4-0002-0000-0000-000000000002"),
                Name = "Flamenco Festival Sevilla",
                Description = "Annual flamenco festival bringing together top artists from across Spain for a week of performances and workshops.",
                AmountNeeded = 75_000m,
                PublicationDate = new DateTime(2026, 2, 10)
            },
            new Project
            {
                Id = Guid.Parse("a1b2c3d4-0003-0000-0000-000000000003"),
                Name = "Art Exhibition Madrid",
                Description = "Contemporary art exhibition showcasing emerging Spanish artists in a renovated warehouse space.",
                AmountNeeded = 120_000m,
                PublicationDate = new DateTime(2026, 2, 28)
            },
            new Project
            {
                Id = Guid.Parse("a1b2c3d4-0004-0000-0000-000000000004"),
                Name = "Barcelona Jazz Nights",
                Description = "A series of jazz concerts held in iconic Barcelona venues throughout the summer months.",
                AmountNeeded = 45_000m,
                PublicationDate = new DateTime(2026, 3, 5)
            },
            new Project
            {
                Id = Guid.Parse("a1b2c3d4-0005-0000-0000-000000000005"),
                Name = "Valencia Film Documentary",
                Description = "Documentary film exploring the cultural heritage and modern transformation of Valencia's old town.",
                AmountNeeded = 90_000m,
                PublicationDate = new DateTime(2026, 3, 12)
            },
            new Project
            {
                Id = Guid.Parse("a1b2c3d4-0006-0000-0000-000000000006"),
                Name = "Galician Folk Music Revival",
                Description = "Project to record, preserve, and promote traditional Galician folk music with modern production techniques.",
                AmountNeeded = 35_000m,
                PublicationDate = new DateTime(2026, 3, 20)
            },
            new Project
            {
                Id = Guid.Parse("a1b2c3d4-0007-0000-0000-000000000007"),
                Name = "Bilbao Street Art Festival",
                Description = "Transforming Bilbao's urban landscape with large-scale murals by international street artists.",
                AmountNeeded = 60_000m,
                PublicationDate = new DateTime(2026, 3, 25)
            },
            new Project
            {
                Id = Guid.Parse("a1b2c3d4-0008-0000-0000-000000000008"),
                Name = "Córdoba Poetry Slam",
                Description = "Monthly poetry slam events celebrating spoken word art in the heart of Andalusia.",
                AmountNeeded = 15_000m,
                PublicationDate = new DateTime(2026, 4, 1)
            },
            new Project
            {
                Id = Guid.Parse("a1b2c3d4-0009-0000-0000-000000000009"),
                Name = "San Sebastián Culinary Arts",
                Description = "Cultural culinary program connecting Basque gastronomy with artistic expression and local producers.",
                AmountNeeded = 180_000m,
                PublicationDate = new DateTime(2026, 4, 8)
            },
            new Project
            {
                Id = Guid.Parse("a1b2c3d4-0010-0000-0000-000000000010"),
                Name = "Canary Islands Dance Residency",
                Description = "Three-month dance residency program for emerging choreographers on the island of Lanzarote.",
                AmountNeeded = 55_000m,
                PublicationDate = new DateTime(2026, 4, 12)
            },
            new Project
            {
                Id = Guid.Parse("a1b2c3d4-0011-0000-0000-000000000011"),
                Name = "Salamanca Classical Guitar",
                Description = "International classical guitar competition and masterclass series in historic Salamanca.",
                AmountNeeded = 40_000m,
                PublicationDate = new DateTime(2026, 4, 15)
            },
            new Project
            {
                Id = Guid.Parse("a1b2c3d4-0012-0000-0000-000000000012"),
                Name = "Malaga Digital Arts Lab",
                Description = "Interactive digital arts laboratory exploring the intersection of technology and Mediterranean culture.",
                AmountNeeded = 200_000m,
                PublicationDate = new DateTime(2026, 4, 16)
            }
        );
    }
}
