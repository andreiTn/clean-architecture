using Microsoft.EntityFrameworkCore;
using GymManagement.Domain.Subscriptions;
using GymManagement.Application.Common.Interfaces;
using System.Reflection;

namespace GymManagement.Infrastructure.Common.Persistence;

public class GymManagementDbContext : DbContext, IUnitOfWork
{
  public DbSet<Subscription> Subscriptions { get; set; } = null!;

  public GymManagementDbContext(DbContextOptions<GymManagementDbContext> options) : base(options)
  {
  }

  public async Task CommitChangesAsync()
  {
    await base.SaveChangesAsync();
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }
}
