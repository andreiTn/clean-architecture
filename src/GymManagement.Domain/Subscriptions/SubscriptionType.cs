using System.Diagnostics.Contracts;
using Ardalis.SmartEnum;

namespace GymManagement.Domain.Subscriptions;

public class SubscriptionType: SmartEnum<SubscriptionType>
{
    public readonly SubscriptionType Free = new(nameof(Free), 0);
    public readonly SubscriptionType Starter = new(nameof(Starter), 1);
    public readonly SubscriptionType Pro = new(nameof(Pro), 2);

    public SubscriptionType(string name, int value) : base(name, value)
    {
    }
}
