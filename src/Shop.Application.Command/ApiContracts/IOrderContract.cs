namespace Shop.Application.Command.ApiContracts;

public interface IOrderContract
{
    Task<PlaceOrderResult> PlaceOrderCommand(Guid CustomerId);
}
