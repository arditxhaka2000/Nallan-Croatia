using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProductServ
{
    public interface IColorService
    {
        List<Color> GetAll();
        Color GetById(int ColorId);
        void Update(Color Item);
        void Insert(Color Item);
        void Delete(Color Item);
        bool SaveChanges();
    }
}
