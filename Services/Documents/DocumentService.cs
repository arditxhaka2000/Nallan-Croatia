using Data;
using DocumentFormat.OpenXml.Office2010.Excel;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Services.Documents
{
    public class DocumentService : IDocumentService
    {
        private IRepository<Document> _repo;
        public DocumentService(IRepository<Document> repo)
        {
            _repo = repo;
        }

        public List<Document> GetAll()
        {
            return _repo.GetAll();
        }

        public IQueryable<Document> GetAllAsQuerable(string Document, Guid? RootId)
        {
            var includes = new string[] { "DocumentTranslations" };
            var result = _repo.GetAsQueryable(includeProperties: includes, filter: x => x.Id == RootId);
            if (!string.IsNullOrEmpty(Document))
            {
                result = result.Where(x => x.DocumentName.Contains(Document));
            }
            return result;
        }

        public IQueryable<Document> GetAllAsQuerable(string Document, Guid? RootId, int DocumetTypeId)
        {
            var includes = new string[] { "Language" };
            var result = _repo.GetAsQueryable(includeProperties: includes, filter: x => x.Id == RootId);

            return result;
        }

        public Document GetById(Guid id)
        {
            var rezult = _repo.GetById(id.ToString());
            return rezult;

        }

        public void Insert(Document Item)
        {
            _repo.Insert(Item);
        }

        public bool SaveChanges()
        {
            _repo.SaveChanges();
            return true;
        }

        public void Update(Document Item)
        {
            _repo.Update(Item);
        }
        public bool Delete(Guid id)
        {
            bool deleted = true;
            var documentdb = _repo.GetById(id.ToString());
            if (documentdb == null)
            {
                deleted = false;
                return deleted;
            }
            _repo.Delete(documentdb);

            return deleted;
        }

    }
}
