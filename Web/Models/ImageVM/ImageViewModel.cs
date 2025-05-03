using Data;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Web.Models.ImageVM
{
    public class ImageViewModel
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public string DocumentName { get; set; }
        public DateTime? Date { get; set; }
        public int Size { get; set; }
        public int? ProductId { get; set; }
        public int? CategoryId { get; set; }
    }
}
