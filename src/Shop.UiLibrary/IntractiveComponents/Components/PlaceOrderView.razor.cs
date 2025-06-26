using Microsoft.AspNetCore.Components;

namespace Shop.UiLibrary.IntractiveComponents.Components
{
    public partial class PlaceOrderView
    {
        [Parameter] public EventCallback<string> OnSubmitOrder { get; set; }
        [Parameter] public EventCallback<string> OnPayOrder { get; set; }

        [Parameter] public PlaceOrderResult? OrderResult { get; set; }

        [Parameter] public string? ErrorMessage { get; set; }
        [Parameter] public string? PaymentResultMessage { get; set; }

        private string DiscountCode { get; set; } = "";
        private string? SelectedPaymentMethod;
        private string[] PaymentMethods = new[] { "Visa", "PayPal", "MasterCard", "Crypto" };

        private bool isSubmitting = false;

        private async Task SubmitOrder()
        {
            if (isSubmitting || OrderResult is not null) return;

            isSubmitting = true;
            try
            {
                await OnSubmitOrder.InvokeAsync(DiscountCode);
            }
            finally
            {
                isSubmitting = false;
            }
        }

        private void OnPaymentMethodChanged(string method)
        {
            SelectedPaymentMethod = method;
        }

        private async Task PayOrder()
        {
            if (string.IsNullOrWhiteSpace(SelectedPaymentMethod)) return;

            await OnPayOrder.InvokeAsync(SelectedPaymentMethod);
        }
    }
}