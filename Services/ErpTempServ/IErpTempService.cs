using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Orders
{
    public interface IErpTempService
    {
        List<ErpTemp> GetAll();
        void Insert(ErpTemp Item);
        bool SaveChanges();
    }
}
