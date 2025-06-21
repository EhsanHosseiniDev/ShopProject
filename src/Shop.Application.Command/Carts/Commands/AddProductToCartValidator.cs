using FluentValidation;

namespace Shop.Application.Command.Carts.Commands;

public class AddProductToCartValidator : AbstractValidator<AddProductToCartCommand>
{
    public AddProductToCartValidator()
    {
        RuleFor(x => x.CustomerId).NotEmpty();
        RuleFor(x => x.ProductId).NotEmpty();
        RuleFor(x => x.Quantity).GreaterThan(0);
    }
}


