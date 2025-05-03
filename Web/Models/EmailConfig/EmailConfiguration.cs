using System.Collections.Generic;
using System.IO;

namespace Web.Models.EmailConfig
{
    public class EmailConfiguration
    {
        public List<string> ToAsBcc { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; } = "POROSI - Nallan ka një porosi të rë";

        public MemoryStream Image { get; set; } = null;

        public string DocumentPath { get; set; } = string.Empty;


        public bool IsDocumentMemoryStream { get; set; } = false;

        public byte[] DocumentMS { get; set; } = null;

        public string DocumentName { get; set; }


        public string[] dynamictext { get; set; }

        public string Template { get; set; }

    }

    public class EmailViewModel
    {
        public string EmailTo { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
    }
}
  