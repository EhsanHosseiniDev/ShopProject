namespace BlazorApp.Components.Pages
{
    public partial class PlaceOrderPage
    {
        private PlaceOrderResult? OrderResult;
        private string? ErrorMessage;
        private string? PaymentResultMessage;

        private async Task HandleSubmitOrder(string code)
        {
            OrderResult = await Mediator.Send(new PlaceOrderCommand(Guid.NewGuid(), code));
        }

        private async Task HandlePayOrder(string method)
        {
            if (OrderResult is null) return;

            var result = await Mediator.Send(new PayOrderCommand(OrderResult.OrderId, method));
            if (result.Success)
                PaymentResultMessage = $"Payment successful. Code: {result.PaymentTrackingCode}";
            else
                ErrorMessage = $"Payment failed: {result.ErrorMessage}";
        }
    }
}