using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Orders
{
    public interface IOrderItemService
    {
        List<OrderItem> GetAll();
        OrderItem GetById(int SizeId);
        void Update(OrderItem Item);
        void Insert(OrderItem Item);
        void Delete(OrderItem Item);
        bool SaveChanges();
    }
}
