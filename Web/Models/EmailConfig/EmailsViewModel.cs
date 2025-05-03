using System;
using X.PagedList;

namespace Web.Models.EmailConfig
{
    public class ShowEmailsViewModel
    {
        public IPagedList<EmailsViewModel> Emails { get; set; }
        public string email { get; set; }
    }

    public class EmailsViewModel
    {
        public Guid Id { get; set; }
        public string EmailTo { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public bool IsSended { get; set; }
        public bool Queue { get; set; }
    }

    public class BulkEmailViewModel
    {
        public string email { get; set; }
        public bool IsChecked { get; set; }
    }

    public class BulkEmail4PollincCenterViewModel
    {
        public string body { get; set; }
        public string subject { get; set; }
        public int descisionid { get; set; }
    } 
    
    public class BulkEmail4AbroadVoterViewModel
    {
        public string body { get; set; }
        public string subject { get; set; }
        public int descisionid { get; set; }
        public int abroadvotertypeid { get; set; }
    }
}


