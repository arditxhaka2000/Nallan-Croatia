using Data;
using DocumentFormat.OpenXml.Office2010.Excel;
using Irony.Parsing;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Services.Documents
{
    public class ImageService : IImageService
    {
        private IRepository<Image> _repo;
        public ImageService(IRepository<Image> repo)
        {
            _repo = repo;
        }

        public List<Image> GetAll()
        {
            return _repo.GetAll();
        }

        public IQueryable<Image> GetAllAsQuerable(int ProductId)
        {
            var result = _repo.GetAsQueryable( filter: x => x.ProductId == ProductId);
        
            return result;
        }


        public Image GetById(int id)
        {
            var rezult = _repo.GetById(id.ToString());
            return rezult;

        }

        public void Insert(Image Item)
        {
            _repo.Insert(Item);
        }

        public bool SaveChanges()
        {
            _repo.SaveChanges();
            return true;
        }

        public void Update(Image Item)
        {
            _repo.Update(Item);
        }
        public void Delete(Image item)
        {
            _repo.Delete(item);

        }

        public Image GetByCategoryId(int CategoryId)
        {
            var result = _repo.GetAsQueryable(filter: x => x.CategoryId == CategoryId).FirstOrDefault();

            return result;
        }
    }
}
