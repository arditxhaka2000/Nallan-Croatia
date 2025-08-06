namespace Web.Models.CorvusPay
{
    public class CorvusPaySettings
    {
        public string StoreId { get; set; } = "";
        public string SecretKey { get; set; } = "";
        public string PaymentUrl { get; set; } = "https://corvuspay.hr/gateway/form/";
        public int SessionTimeoutMinutes { get; set; } = 30;
    }

}
