using X.PagedList;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Web.Models
{
    public class ErpTempViewModel
    {
        public int Id { get; set; }
        public int DokumentID { get; set; } // OrderId
        public string ProductCode { get; set; } //productCode
        public int SasiaPaketim { get; set; } //Quantity
        public int ErpStatus { get; set; } //def 0
        public string PaymentMethod { get; set; } // Bank ose Cash
    }
    public class ListErpTempViewModel
    {
        public IPagedList<ErpTempViewModel> Items { get; set; }
    }
}
