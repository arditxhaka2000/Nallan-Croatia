using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class SendEmail : BaseEntity
    {
        public Guid Id { get; set; }
        public string EmailTo { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public bool IsSended { get; set; }
        public bool Queue { get; set; }
        public bool SendedFromSystem { get; set; }
    }
}
