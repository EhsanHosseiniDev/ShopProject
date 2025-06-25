using Shop.Domain.Common;

namespace Shop.DomainService.CartCalulators;

public record CalculateTotalCartResult(
    string DiscountName,
    Money DiscountAmount,
    Money EffectedDiscountAmount
    );
