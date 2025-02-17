using MediatR;
using ErrorOr;
using GymManagement.Domain.Subscriptions;

namespace GymManagement.Application.Commands.GetSubscription;

public record GetSubscriptionCommand(Guid SubscriptionId) : IRequest<ErrorOr<Subscription>>;
