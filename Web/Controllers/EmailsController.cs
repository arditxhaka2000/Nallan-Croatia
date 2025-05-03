using AutoMapper;
using Data;
using iText.Html2pdf.Attach.Impl.Layout.Form.Element;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using Services.Emails;
using Services.Enum;
using SimpleEmailApp.Services.EmailService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using Web.Infrastructure;
using Web.Models.EmailConfig;
using X.PagedList;

namespace Web.Controllers
{
    [Authorize]
    [ClaimRequirement(Mode.CanView, ControllerEnum.Emails)]
    public class EmailsController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IEmailsService _emailsService;
        private readonly IEmailService _emailService; 
        private readonly IConfiguration _config;

        public EmailsController(IMapper mapper, IEmailsService emailsService, IEmailService emailService, IConfiguration config)
        {
            _mapper = mapper;
            _emailsService = emailsService;
            _emailService = emailService;
            _config = config;
        }
        [Authorize]
      
        public IActionResult Index(int page = 1, string email = null)
        {
            var pageSize = 10;
         
            var model = new ShowEmailsViewModel();
            var _getAllEmails = _mapper.Map<List<EmailsViewModel>>(_emailsService.GetAll(email));
            model.Emails = _getAllEmails.ToPagedList(page, pageSize);
            model.email = email;
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
      
        public JsonResult BulkEmails(List<BulkEmailViewModel> sendEmail, string body, string subject)
        {
            try
            {
                if (sendEmail == null || sendEmail.All(x => x.IsChecked == false))
                {
                    return Json(new { success = false, msg = "Zgjedh te pakten njeren nga email-at" });
                }

                var _distinctAllEmail = sendEmail.Where(x => x.IsChecked).Select(x => x.email).Distinct();

                if (_emailService.SendEmail(new EmailConfiguration { Body = body, Subject = subject, ToAsBcc = _distinctAllEmail.ToList() }))
                {
                    var _addOnTable = new List<SendEmail>();
                    foreach (var email in _distinctAllEmail.ToList())
                    {
                        _addOnTable.Add(new SendEmail { Body = body, Subject = subject, Date = DateTime.Now, EmailTo = email, IsSended = true, Queue = false, SendedFromSystem = true });
                    }
                    _emailsService.Insert(_addOnTable);
                    return Json(new { success = true, msg = "Email-i eshte derguar me sukses!" });
                }
                else
                {
                    return Json(new { success = false, msg = "Ju lutemi kontrolloni email-at" });
                }
            }
            catch
            {
                return Json(new { success = false, msg = "Diqka nuk shkoi mire" });
            }
        }
    }
}
