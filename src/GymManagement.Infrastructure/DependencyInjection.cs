using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GymManagement.Application.Common.Interfaces;
using GymManagement.Infrastructure.Subscriptions.Persistence;
using GymManagement.Infrastructure.Common.Persistence;

namespace GymManagement.Infrastructure;

public static class DependencyInjection
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection services)
  {
    services.AddDbContext<GymManagementDbContext>(options => {
      options.UseSqlite("Data Source=gym_management.db");
    });

    // Create a scope to resolve the DbContext and apply migrations
    using (var serviceProvider = services.BuildServiceProvider())
    {
      using var scope = serviceProvider.CreateScope();
      var dbContext = scope.ServiceProvider.GetRequiredService<GymManagementDbContext>();
      dbContext.Database.Migrate();
    }

    services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<GymManagementDbContext>());
    services.AddScoped<ISubscriptionsRepository, SubscriptionRepository>();
    return services;
  }
}
