using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data
{
    public class History  : BaseEntity
    {
        [Key]
        [Column("historyid")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid HistoryId { get; set; }

        [Column("HistoryParentId")]
        public Guid HistoryParentId { get; set; }

        [Required]
        [Column("actionname")]
        public ActionName ActionName { get; set; }

        [Required]
        [Column("tablename")]
        public string TableName { get; set; }

        [Required]
        [Column("objectid")]
        public string ObjectId { get; set; }

        [Column("columnname")]
        public string ColumnName { get; set; }

        [Column("oldvalue")]
        public string OldValue { get; set; }

        [Column("newvalue")]
        public string NewValue { get; set; }


        [Required]
        [Column("date")]
        public DateTime Date { get; set; }

        public string username { get; set; }
        public string UserId { get; set; }

        [Column("pcName")]
        public string PcName { get; set; }
        [Column("ipAddress")]
        public string IpAddress { get; set; }

    }


    public enum ActionName
    {
        Added = 1,
        Modified,
        Deleted
    }
}
