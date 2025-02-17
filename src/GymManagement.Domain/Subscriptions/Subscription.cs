namespace GymManagement.Domain.Subscriptions;

public class Subscription
{
    private readonly Guid _adminId;
    public Guid Id { get; private set; }
    public SubscriptionType SubscriptionType { get; private set; }

    public Subscription(SubscriptionType subscriptionType, Guid adminId, Guid? id = null)
    {
        _adminId = adminId;
        Id = id ?? Guid.NewGuid();
        SubscriptionType = subscriptionType;
    }

    private Subscription() { }
}
