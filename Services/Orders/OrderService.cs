using Data;
using DocumentFormat.OpenXml.Spreadsheet;
using Irony.Parsing;
using Microsoft.AspNetCore.Http;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.Orders
{
    public class OrderService : IOrderService
    {
        private IRepository<Order> _repo;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public OrderService(IRepository<Order> repo, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _repo = repo;
        }

        public void Delete(Order Item)
        {
            _repo.Delete(Item);
        }

        public List<Order> GetAll()
        {
            var includes = new string[] { "OrderItems"};
            return _repo.GetAsNoTracking(includeProperties: includes, filter:x=>x.IsDeleted == false).ToList();
        }

        public List<Order> GetAllByUserId()
        {
            var includes = new string[] { "OrderItems" };
            var user = _httpContextAccessor.HttpContext?.User;
                // If the user is a client, return only their own orders
                var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return _repo.GetAsNoTracking(includeProperties: includes, filter: x=> x.CreatedById == userId).ToList();
        }

        public Order GetById(int OrderId)
        {
            var includes = new string[] { "OrderItems" };
            return _repo.Get(p => p.OrderId == OrderId, includeProperties: includes).FirstOrDefault();
        }

        public void Insert(Order Item)
        {
            _repo.Insert(Item);
        }

        public bool SaveChanges()
        {
            _repo.SaveChanges();
            return true;
        }

        public void Update(Order Item)
        {
            _repo.Update(Item);

        }
    }
}
