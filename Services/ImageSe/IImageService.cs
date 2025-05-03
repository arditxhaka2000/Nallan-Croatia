using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Documents
{
    public interface IImageService
    {
        List<Image> GetAll();
        IQueryable<Image> GetAllAsQuerable(int ProductId);
        Image GetByCategoryId(int CategoryId);
        void Update(Image Item);
        void Insert(Image Item);
        Image GetById(int id);
        bool SaveChanges();
        void Delete(Image item);

     

    }
}
