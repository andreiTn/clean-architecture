using ErrorOr;
using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Subscriptions;
using GymManagement.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Infrastructure.Subscriptions.Persistence;

public class SubscriptionRepository : ISubscriptionsRepository
{
    private readonly GymManagementDbContext _context;

    public SubscriptionRepository(GymManagementDbContext context)
    {
        _context = context;
    }
    public async Task AddSubscriptionAsync(Subscription subscription)
    {
        await _context.Subscriptions.AddAsync(subscription);
    }

    public async Task<Subscription> GetByIdAsync(Guid subscriptionId)
    {
        var subscription = await _context.Subscriptions.Where(x => x.Id == subscriptionId).FirstOrDefaultAsync();

        return subscription;
    }
}
