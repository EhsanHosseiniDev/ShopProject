using Shop.DomainService.Discounts.DiscountPolicy;

namespace Shop.DomainService.Discounts.DiscountProvider;

public class DiscountPolicyProvider : IDiscountPolicyProvider
{
    private readonly Dictionary<string, IDiscountPolicy> _policies;

    public DiscountPolicyProvider()
    {
        //TODO: discount policies can be get from database by other structure
        _policies = new Dictionary<string, IDiscountPolicy>(StringComparer.OrdinalIgnoreCase)
        {
            { "NONE", new NoDiscount() },
            { "10OFF", new PercentageDiscountPolicy(10) },
            { "20OFF", new PercentageDiscountPolicy(20) },
            { "FLAT50", new FixedDiscountPolicy(50) }
        };
    }

    public IDiscountPolicy GetPolicy(string code)
    {
        if (string.IsNullOrWhiteSpace(code))
            return _policies["NONE"];

        return _policies.TryGetValue(code, out var policy)
            ? policy
            : _policies["NONE"];
    }
}

