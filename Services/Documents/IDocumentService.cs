using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Documents
{
    public interface IDocumentService
    {
        List<Document> GetAll();
        IQueryable<Document> GetAllAsQuerable(string Document, Guid? RootId);
        IQueryable<Document> GetAllAsQuerable(string Document, Guid? RootId, int DocumetTypeId);
        void Update(Document Item);
        void Insert(Document Item);
        Document GetById(Guid id);
        bool SaveChanges();
        bool Delete(Guid id);

     

    }
}
