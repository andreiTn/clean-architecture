using MediatR;
using ErrorOr;
using GymManagement.Domain.Subscriptions;
using GymManagement.Application.Common.Interfaces;

namespace GymManagement.Application.Commands.GetSubscription;

public class GetSubscriptionCommandHandler : IRequestHandler<GetSubscriptionCommand, ErrorOr<Subscription>>
{
    private readonly ISubscriptionsRepository _subscriptionsRepository;

    public GetSubscriptionCommandHandler(ISubscriptionsRepository subscriptionsRepository)
    {
        _subscriptionsRepository = subscriptionsRepository;
    }

    public async Task<ErrorOr<Subscription>> Handle(GetSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var subscription = await _subscriptionsRepository.GetByIdAsync(request.SubscriptionId);

        return subscription is null
          ? Error.NotFound(description: $"Subscription with id {request.SubscriptionId} not found")
          : subscription;
    }
}