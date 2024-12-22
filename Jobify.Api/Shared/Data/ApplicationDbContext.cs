using Jobify.Api.Shared.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Jobify.Api.Shared.Data;

public class ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
 : DbContext(options)
{
    public DbSet<Job> Jobs => Set<Job>();
    public DbSet<Company> Companies => Set<Company>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}