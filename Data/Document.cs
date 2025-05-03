using Data.Privileges;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class Document : BaseEntity, IAuditTrail<Guid>
    {
        public Document()
        {
            Date = DateTime.Now;
        }

        public Guid Id { get; set; }
        public string Path { get; set; }
        public string DocumentName { get; set; }
        public DateTime Date { get; set; }
        public virtual List<DocumentTranslation> DocumentTranslations { get; set; }

        public int Size { get; set; }

        [Column("LanguageId")]
        [ForeignKey("Language")]
        public int? LanguageId { get; set; }
        public virtual Language Language { get; set; }

        //GetDataFromResourceKey
        public string SimpleName { get; set; }


        public bool IsSeen { get; set; } = false;
        [Column("SeenByUserId")]
        [ForeignKey("SeenByUser")]
        public string? SeenByUserId { get; set; }
        public virtual AppUser SeenByUser { get; set; }
        public DateTime? SeenDate { get; set; }
    }
}