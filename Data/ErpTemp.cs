using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ErpTemp : BaseEntity
    {
        public int Id { get; set; }
        public int DokumentID {  get; set; } // OrderId
        public string CountryCode {  get; set; } // OrderId
        public string ProductCode { get; set; } //productCode
        public string ArtikullBarcode { get; set; } // GTN
        public string ArtikullEmri { get; set; } // Product Title
        public string ArtikullNjesia { get; set; } // Njesia PALË
        public int SasiaPaketim { get; set; } //Quantity
        public double Cmimi_me_TVSH { get; set; } //Price
        public DateTime KohaRegjistrimit {  get; set; } //Data e krijimit
        public string Kodi_Shitjes { get; set; } // 2-1A1 default
        public DateTime DataModifikim { get; set; } //Data e krijimit
        public int ErpStatus { get; set; } //def 0
        public string PaymentMethod { get; set; } // Bank ose Cash
        public string ClientName { get; set; } // Bank ose Cash
        public string ClientAddress { get; set; } // Bank ose Cash
        public string ClientPhoneNr { get; set; } // Bank ose Cash


    }
}
