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
    public class ErpTempService : IErpTempService
    {
        private IRepository<ErpTemp> _repo;
       
        public ErpTempService(IRepository<ErpTemp> repo)
        {
            _repo = repo;
        }

        public List<ErpTemp> GetAll()
        {
            return _repo.GetAll();
        }

        public void Insert(ErpTemp Item)
        {
            _repo.Insert(Item);
        }

        public bool SaveChanges()
        {
            _repo.SaveChanges();
            return true;
        }
    }
}
