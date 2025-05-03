using Data.Privileges;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data
{
    public class Localization : BaseEntity//, IAuditTrail<int>
    {
        public int Id { get; set; }
        public string ResourceKey { get; set; }
        public string KeyName { get; set; }
        public string KeyValue { get; set; }
        public string Description { get; set; }

        [Column("LanguageId")]
        [ForeignKey("Language")]
        public int LanguageId { get; set; }
        public virtual Language Language { get; set; } 
    }
}
