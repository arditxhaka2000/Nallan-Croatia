using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using System.IO;
using System.Net.Mime;
using System;
using Web.Models.EmailConfig;
using ContentDisposition = MimeKit.ContentDisposition;

namespace SimpleEmailApp.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }




        public bool SendEmail(EmailConfiguration request)
        {
            try
            {

                // Retrieve configuration values
                var Username = _config["EmailConfiguration:Username"]; // "info@nallan.eu"
                var Password = _config["EmailConfiguration:Password"]; // Your email password
                var FromEmail = _config["EmailConfiguration:From"]; // "info@nallan.eu"
                var Server = _config["EmailConfiguration:Host"]; // "mail.nallan.eu"
                int Port = int.Parse(_config["EmailConfiguration:Port"]); // 465
                bool SSL = bool.Parse(_config["EmailConfiguration:SSL"]); // true

                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(FromEmail));
                if (request != null && request.ToAsBcc.Count > 0)
                {
                    foreach (var item in request.ToAsBcc)
                    {
                        email.Bcc.Add(MailboxAddress.Parse(item));
                    }
                }
                email.Subject = request.Subject;
                email.Body = new TextPart(TextFormat.Html) { Text = request.Body };
                using var smtp = new SmtpClient();
                // Connect to the SMTP server using SSL if enabled
                smtp.Connect(Server, Port, SSL ? SecureSocketOptions.SslOnConnect : SecureSocketOptions.None);
                // Authenticate with the SMTP server
                smtp.Authenticate(Username, Password);
                // Send the email
                smtp.Send(email);
                // Disconnect after sending the email
                smtp.Disconnect(true);
                // Return success
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }


        public bool SendEmailWithImageAndFile(EmailConfiguration request)
        {
            try
            {
                var Username = _config.GetSection("EmailUsername").Value;
                var Password = _config.GetSection("EmailPassword").Value;
                var FromEmail = _config.GetSection("EmailFrom").Value;
                var Server = _config.GetSection("EmailHost").Value;
                int Port = Int32.Parse(_config.GetSection("EmailPort").Value);
                bool SSL = Boolean.Parse(_config.GetSection("EmailSSL").Value);


                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                message.From = new System.Net.Mail.MailAddress(FromEmail,"KQZ");
                message.Subject = request.Subject;

                if (request != null && request.ToAsBcc.Count > 0)
                {
                    foreach (var item in request.ToAsBcc)
                    {
                        message.Bcc.Add(new System.Net.Mail.MailAddress(item));
                    }
                }
                if (request.Image != null)
                {
                    System.Net.Mail.AlternateView htmlView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(request.Body, null, MediaTypeNames.Text.Html);
                    System.Net.Mail.LinkedResource imageResource = new System.Net.Mail.LinkedResource(request.Image, MediaTypeNames.Image.Jpeg);
                    imageResource.ContentId = "imgBarCode";
                    htmlView.LinkedResources.Add(imageResource);
                    message.AlternateViews.Add(htmlView);
                }
                else
                {
                    message.Body = request.Body;
                    message.IsBodyHtml = true;
                }
                if (request.DocumentPath != string.Empty)
                {
                  //  var path = Path.Combine("wwwroot", "html/", file);

                    System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(request.DocumentPath);

                    message.Attachments.Add(attachment);
                }

                if(request.IsDocumentMemoryStream)
                {
                    System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(new MemoryStream(request.DocumentMS),request.DocumentName);

                    message.Attachments.Add(attachment);
                }

                System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient(Server, Port);
                smtpClient.Credentials = new System.Net.NetworkCredential(Username, Password);
                smtpClient.EnableSsl = SSL;
                smtpClient.Send(message);
                smtpClient.Dispose();

                if (request.Image != null)
                {
                    request.Image.Close();
                }
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        public bool SentEmail(EmailViewModel request)
        {
            try
            {
                // Retrieve configuration values
                var Username = _config["EmailConfiguration:Username"]; // "info@nallan.eu"
                var Password = _config["EmailConfiguration:Password"]; // Your email password
                var FromEmail = _config["EmailConfiguration:From"]; // "info@nallan.eu"
                var Server = _config["EmailConfiguration:Host"]; // "mail.nallan.eu"
                int Port = int.Parse(_config["EmailConfiguration:Port"]); // 465
                bool SSL = bool.Parse(_config["EmailConfiguration:SSL"]); // true

                // Create the email message
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(FromEmail));

                // Add recipient email (Bcc)
                if (request != null && !string.IsNullOrEmpty(request.EmailTo))
                {
                    email.Bcc.Add(MailboxAddress.Parse(request.EmailTo)); // Bcc is used as per original code
                }

                // Set email subject and body
                email.Subject = request.Subject;
                email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

                // Create and configure the SMTP client
                using var smtp = new SmtpClient();

                // Connect to the SMTP server using SSL if enabled
                smtp.Connect(Server, Port, SSL ? SecureSocketOptions.SslOnConnect : SecureSocketOptions.None);

                // Authenticate with the SMTP server
                smtp.Authenticate(Username, Password);

                // Send the email
                smtp.Send(email);

                // Disconnect after sending the email
                smtp.Disconnect(true);

                // Return success
                return true;
            }
            catch (Exception ex)
            {
                // Log exception (optional)
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}
