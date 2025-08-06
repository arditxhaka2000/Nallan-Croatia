namespace Web.Models.CorvusPay
{
    public class CorvusPayRequestVM
    {
        public string Version { get; set; } = "";
        public string StoreId { get; set; } = "";
        public string OrderNumber { get; set; } = "";
        public string Amount { get; set; } = "";
        public string Currency { get; set; } = "";
        public string Cart { get; set; } = "";
        public string RequireComplete { get; set; } = "";
        public string Language { get; set; } = "";
        public string SuccessUrl { get; set; } = "";
        public string CancelUrl { get; set; } = "";
        public string CallbackUrl { get; set; } = "";
        public string Signature { get; set; } = "";
        public string PaymentUrl { get; set; } = "";
    }
}
