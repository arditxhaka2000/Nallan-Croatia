using Data;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Emails
{
    public class EmailsService : IEmailsService
    {
        private readonly IRepository<SendEmail> _repo;

        public EmailsService(IRepository<SendEmail> repo)
        {
            _repo = repo;
        }

        public List<SendEmail> GetAll()
        {
            return _repo.GetAll();
        }

        public List<SendEmail> GetAll(string email)
        {
            var results = _repo.GetAsQueryable();
            if (email != null)
            {
                results = results.Where(x => x.EmailTo == email);
            }
            return results.OrderByDescending(x => x.Date).ToList();
        }

        public SendEmail GetById(Guid Id)
        {
            return _repo.GetById(Id.ToString());
        }

        public void Insert(SendEmail emailItem)
        {
            _repo.Insert(emailItem);
        }

        public void Insert(List<SendEmail> emailItem)
        {
            _repo.InsertRange(emailItem);
        }

        public void Update(SendEmail emailItem)
        {
            _repo.Update(emailItem);
        }
    }
}
