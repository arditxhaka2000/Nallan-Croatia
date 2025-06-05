using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Web.Models;

namespace Web.Controllers
{
    public class CatalogController : BaseController
    {
        private readonly IWebHostEnvironment _env;

        public CatalogController(IWebHostEnvironment env)
        {
            _env = env;
        }

        public IActionResult Index()
        {
            var lang = CurrentLanguage;
            ViewBag.Lang = lang;
            string catalogPath = Path.Combine(_env.WebRootPath, "catalogs");
            string imagePath = Path.Combine(catalogPath, "images");

            if (!Directory.Exists(catalogPath))
                return NotFound("Catalog folder not found.");

            var files = Directory.GetFiles(catalogPath, "*.pdf");

            var catalogFiles = files.Select(file =>
            {
                var fileName = Path.GetFileName(file);
                var title = Path.GetFileNameWithoutExtension(file);
                var imageFileName = title + ".png"; // or .png depending on what you use
                var imageFullPath = Path.Combine(imagePath, imageFileName);
                var imageUrl = System.IO.File.Exists(imageFullPath)
                    ? "/catalogs/images/" + imageFileName
                    : "/catalogs/images/default.jpg";

                return new Catalog
                {
                    Title = title,
                    FileName = fileName,
                    Url = "/catalogs/" + fileName,
                    ImageUrl = imageUrl
                };
            }).ToList();

            return View(catalogFiles);
        }

        public IActionResult Viewer(string file, string name = null)
        {
            if (string.IsNullOrEmpty(file))
            {
                return BadRequest("PDF file path is required");
            }

            // Construct the full path
            var pdfPath = file.StartsWith("/") ? file : $"/catalogs/{file}";

            // Set ViewBag data for the view
            ViewBag.PdfUrl = pdfPath;
            ViewBag.PdfName = name ?? Path.GetFileNameWithoutExtension(file);

            return View();
        }

    }
}
