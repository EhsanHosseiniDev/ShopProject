using Shop.Domain.Common;
using System;

namespace Shop.DomainService.Discounts.DiscountPolicy;

public interface IDiscountPolicy
{
    Money Apply(Money original, Guid customerId);
}
