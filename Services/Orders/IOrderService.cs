using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Orders
{
    public interface IOrderService
    {
        List<Order> GetAll();
        List<Order> GetAllByUserId();
        Order GetById(int SizeId);
        void Update(Order Item);
        void Insert(Order Item);
        void Delete(Order Item);
        bool SaveChanges();
    }
}
