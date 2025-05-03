namespace Web.Models.TebBank
{
    public class BankRequestVM
    {

        public string ClientId { get; set; }

        public string StoreType { get; set; }

        public string Hash { get; set; }

        public string TranType { get; set; }


        public decimal Amount { get; set; }


        public string Currency { get; set; }


        public string OrderId { get; set; }


        public string OkUrl { get; set; }


        public string FailUrl { get; set; }
        public string shopurl { get; set; }
        public string billToName { get; set; }
        public string billToCompany { get; set; }


        public string CallBack { get; set; }


        public string Language { get; set; }


        public string RandomValue { get; set; }


        public string Encoding { get; set; }
        public string hashAlgorithm { get; set; }
        public string refreshtime { get; set; }
        public string installmentonHPP { get; set; }
    }
}
