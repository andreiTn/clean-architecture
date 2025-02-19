using GymManagement.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GymManagement.Application;

public static class DependencyInjection
{
  public static IServiceCollection AddApplication(this IServiceCollection services)
  {
    services.AddTransient<ISubscriptionsWriteService, SubscriptionsWriteService>();

    services.AddMediatR((options) => {
      options.RegisterServicesFromAssemblyContaining(typeof(DependencyInjection));
    });

    return services;
  }
}
