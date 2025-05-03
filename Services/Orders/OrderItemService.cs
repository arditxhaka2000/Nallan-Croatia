using Data;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Orders
{
    public class OrderItemService : IOrderItemService
    {
        private IRepository<OrderItem> _repo;
        public OrderItemService(IRepository<OrderItem> repo)
        {
            _repo = repo;
        }

        public void Delete(OrderItem Item)
        {
            _repo.Delete(Item);
        }

        public List<OrderItem> GetAll()
        {
            return _repo.GetAll();
        }

        public OrderItem GetById(int OrderId)
        {
            return _repo.Get(OrderId);
        }

        public void Insert(OrderItem Item)
        {
            _repo.Insert(Item);
        }

        public bool SaveChanges()
        {
            _repo.SaveChanges();
            return true;
        }

        public void Update(OrderItem Item)
        {
            _repo.Update(Item);

        }
    }
}
