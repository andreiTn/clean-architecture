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

    services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<GymManagementDbContext>());
    services.AddScoped<ISubscriptionsRepository, SubscriptionRepository>();
    return services;
  }
}
