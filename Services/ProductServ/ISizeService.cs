using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProductServ
{
    public interface ISizeService
    {
        List<Size> GetAll();
        Size GetById(int SizeId);
        void Update(Size Item);
        void Insert(Size Item);
        void Delete(Size Item);
        bool SaveChanges();
    }
}
