namespace Web.Models
{
    public class PaymentResponseViewModel
    {
        public string Response { get; set; }
        public string AuthCode { get; set; }
        public string HostRefNum { get; set; }
        public string ProcReturnCode { get; set; }
        public string TransId { get; set; }
        public string MdStatus { get; set; }
        public bool IsSuccess { get; set; }
    }
}
