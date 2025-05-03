using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Emails
{
    public interface IEmailsService
    {
        List<SendEmail> GetAll();
        List<SendEmail> GetAll(string email);
        SendEmail GetById(Guid Id);
        void Insert(SendEmail emailItem);
        void Insert(List<SendEmail> emailItem);
        void Update(SendEmail emailItem);
    }
}
