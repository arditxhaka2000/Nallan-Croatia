namespace Web.Models.CorvusPay
{
    public class CorvusPayResponseVM
    {
        public string Version { get; set; } = "";
        public string StoreId { get; set; } = "";
        public string OrderNumber { get; set; } = "";
        public string Amount { get; set; } = "";
        public string Currency { get; set; } = "";
        public string ApprovalCode { get; set; } = "";
        public string TransactionId { get; set; } = "";
        public string ErrorNumber { get; set; } = "";
        public string ErrorMessage { get; set; } = "";
        public string Signature { get; set; } = "";
    }
}
