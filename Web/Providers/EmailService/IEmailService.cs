using System.IO;
using Web.Models.EmailConfig;

namespace SimpleEmailApp.Services.EmailService
{
    public interface IEmailService
    {
        bool SendEmail(EmailConfiguration request);
        bool SentEmail(EmailViewModel request);

        bool SendEmailWithImageAndFile(EmailConfiguration request);
    }
}
