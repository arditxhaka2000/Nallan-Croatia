using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using Web.Models.ImageVM;

namespace Web.Models.SettingsVM
{
   

    public class SettingsViewModel
    {
        public List<SizeViewModel> Sizes { get; set;}
        public List<ColorViewModel> Colors { get; set;}
        public List<CategoryViewModel> Categories { get; set;}
    }
    public class SizeViewModel
    {
        public int Id { get; set; }
        public string SizeNr { get; set; }
    }
    public class ColorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
    public class CreateCategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile File { get; set; }
    }

    public class ApiCategoryViewModel
    {
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
