using MediatR;

namespace Shop.Application.Command.Carts.Commands;

public record AddProductToCartCommand(Guid CustomerId, Guid ProductId, int Quantity)
    : IRequest<AddProductToCartResult>;
