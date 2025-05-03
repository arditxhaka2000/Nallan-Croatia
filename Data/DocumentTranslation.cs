using Data.Privileges;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class DocumentTranslation : BaseEntity, IAuditTrail<Guid>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Purpose { get; set; }

        [Column("LanguageId")]
        [ForeignKey("Language")]
        public int? LanguageId { get; set; }
        public virtual Language Language { get; set; }
    }
}