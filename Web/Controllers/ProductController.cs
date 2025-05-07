using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Data;
using Services;
using OA_Web.Models;
using Microsoft.AspNetCore.Authorization;
using Services.ProductServ;
using Web.Models.SettingsVM;
using System.Transactions;
using Web.Models.DocumentsVM;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Infrastructure;
using Services.Documents;
using Web.Models.ImageVM;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Repository.Migrations;
using X.PagedList;
using Services.Orders;
using Web.Models;

namespace Web.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly ISizeService _sizeService;
        private readonly IColorService _colorService;
        private readonly ICategoryService _categoryService;
        private readonly IProductColorService _productColorService;
        private readonly IProductSizeService _productSizeService;
        private readonly IProductCategoryService _productCategoryService;
        private readonly IDocumentService _documentService;
        private readonly IImageService _imgService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IApiServices _apiServices;
        private readonly IErpTempService _erpTempService;
        private readonly string basicPath = "";


        public ProductController(IMapper mapper, IWebHostEnvironment webHostEnvironment,
 IApiServices apiServices, IProductService productService, ISizeService sizeService, IColorService colorService, ICategoryService categoryService
            , IProductColorService productColorService, IProductSizeService productSizeService, IProductCategoryService productCategoryService, IDocumentService documentService, IImageService imgService, IErpTempService erpTempService)
        {
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _erpTempService = erpTempService;
            _productService = productService;
            _sizeService = sizeService;
            _colorService = colorService;
            _categoryService = categoryService;
            _productColorService = productColorService;
            _productSizeService = productSizeService;
            _productCategoryService = productCategoryService;
            _documentService = documentService;
            _imgService = imgService;
            basicPath = Path.Combine(_webHostEnvironment.WebRootPath, "Documents");
            _apiServices = apiServices;

        }
        public async Task<IActionResult> Index(string name = null, string category = null, string size = null, int page = 1)
        {
            var model = new IndexProductViewModel();
            var prodDb = await _apiServices.GetAllAsync();

            int pageSize = 15;
            // Filter based on search parameters
            if (!string.IsNullOrEmpty(name))
            {
                prodDb = prodDb.Where(p => p.Title.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(category))
            {
                prodDb = prodDb.Where(p => p.Title.Contains(category, StringComparison.OrdinalIgnoreCase)).ToList();

            }

            if (!string.IsNullOrEmpty(size))
            {
                prodDb = prodDb.Where(p => p.Variants.Any(x => x.StoreStockQuantity > 0 && x.Specifications.Any(u => u.Value == size))).ToList();
            }

            model.Products = _mapper.Map<List<ApiData>>(prodDb).ToPagedList(page, pageSize);
            model.Categories = await GetCategoriesFromApi();
            model.Sizes = await GetSizesFromApi();

            return View(model);
        }

        public static string ExtractTextBetweenDashes(string input)
        {
            int firstDashIndex = input.IndexOf('-');
            if (firstDashIndex == -1) return string.Empty; 

            int secondDashIndex = input.IndexOf('-', firstDashIndex + 1);
            if (secondDashIndex == -1) return string.Empty; 

            // Extract text between the two dashes
            return input.Substring(firstDashIndex + 1, secondDashIndex - firstDashIndex - 1).Trim();
        }
        public async Task<List<ApiCategoryViewModel>> GetCategoriesFromApi()
        {
            var prodDb = await _apiServices.GetAllAsync();

            var modeli = prodDb
            .Select(product =>
            {
                var name = product.Title.Split('-').Skip(1).FirstOrDefault(); 

                return new ApiCategoryViewModel
                {
                    Name = name
                };
            })
            .DistinctBy(viewModel => viewModel.Name) 
            .ToList();
            return modeli;
        }
        public async Task<List<SizeViewModel>> GetSizesFromApi()
        {
            var prodDb = await _apiServices.GetAllAsync();

            var sizes = prodDb
                .Select(product =>
                {
                    var sizeSpec = product.Specifications?.FirstOrDefault(s => s.Name == "Madhesia");
                    var value = sizeSpec?.Value;

                    return new SizeViewModel
                    {
                        SizeNr = value
                    };
                })
                .Where(s => !string.IsNullOrWhiteSpace(s.SizeNr)) 
                .DistinctBy(s => s.SizeNr)
                .ToList();

            return sizes;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Products(int page = 1)
        {
            int pageSize = 15;
            var model = new IndexProductViewModel();
            var prodDb = await _apiServices.GetAllAsync();
            model.Products = _mapper.Map<List<ApiData>>(prodDb).ToPagedList(page, pageSize);
            return View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ProductDetail(string ProductId)
        {
            //var model = new Index4ApiProd();
            var productsDb = await _apiServices.GetByIdAsync(ProductId);
            var model = _mapper.Map<ApiProdDetails>(productsDb);

            //var prodDB = await _apiServices.GetAllAsync();
            //model.Products = _mapper.Map<List<ApiData>>(prodDB).Take(3).ToList();


            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Details(string ProductId)
        {
            var dbmodel = new Index4ApiProd();
            var productsDb = await _apiServices.GetByIdAsync(ProductId);
            dbmodel.Product = _mapper.Map<ApiData>(productsDb);

            var prodDB = await _apiServices.GetAllAsync();
            string input = productsDb.Title;
            string sameCategory = ExtractTextBetweenDashes(input);
            dbmodel.Products = _mapper.Map<List<ApiData>>(prodDB).Where(x => x.Title.Contains(sameCategory)).Take(3).ToList();

            string productName = ExtractProductFolderName(productsDb.ProductUrl);
            string category = SanitizeFileName(productsDb.Categories.FirstOrDefault());
            string basePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Products", category+"\\");

            var targetFolder = Directory.GetDirectories(basePath)
        .FirstOrDefault(dir =>
        {
            var folderName = Path.GetFileName(dir);
            var nameWithoutPrefix = folderName.Contains(". ")
                ? folderName.Substring(folderName.IndexOf(". ") + 2)
                : folderName;

            return nameWithoutPrefix.Equals(productName, StringComparison.OrdinalIgnoreCase);
        });

            if (!string.IsNullOrEmpty(targetFolder))
            {
                var imageUrls = Directory.GetFiles(targetFolder)
                    .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) || f.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                    .Select(f =>
                    {
                        var relativePath = f.Substring(basePath.Length).Replace("\\", "/");
                        return $"/Products/{category}/" + relativePath;
                    })
                    .ToList();

                dbmodel.Product.ImageUrls = imageUrls;
            }
            else
            {
                dbmodel.Product.ImageUrls = new List<string>(); 
            }

            return View(dbmodel);
        }
        public string ExtractProductFolderName(string info)
        {
            var parts = info.Split('~');

            foreach (var part in parts)
            {
                if (part.Contains("/products/"))
                {
                    try
                    {
                        var uri = new Uri(part);
                        var segments = uri.Segments;

                        if (segments.Length >= 4)
                        {
                            var rawFolder = Uri.UnescapeDataString(segments[3].TrimEnd('/'));
                            var spaceIndex = rawFolder.IndexOf(' ');
                            if (spaceIndex >= 0 && spaceIndex + 1 < rawFolder.Length)
                            {
                                return rawFolder.Substring(spaceIndex + 1);
                            }
                            return rawFolder;
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
            }

            return null;
        }


        private string SanitizeFileName(string input)
        {
            foreach (var c in Path.GetInvalidFileNameChars())
                input = input.Replace(c, '-');
            return input.Trim();
        }

        private string ExtractCategory(string title)
        {
            // Adjust this logic to match your naming format
            // For example, if title is: "Papuçe Anatomike per Meshkuj-ROMEO-Hiri/kaltert"
            var parts = title.Split('-', StringSplitOptions.RemoveEmptyEntries);
            return parts.Length > 0 ? parts[0].Trim() : "Unknown";
        }


        #region Menaxhimi Produkteve
        [HttpGet]
        [Authorize]

        public IActionResult CreateProduct()
        {
            var model = new Index4CreateProductViewModel();

            var categories = _mapper.Map<List<CategoryViewModel>>(_categoryService.GetAll());
            var sizes = _mapper.Map<List<SizeViewModel>>(_sizeService.GetAll());
            var colors = _mapper.Map<List<ColorViewModel>>(_colorService.GetAll());
            model.Categories = categories;
            model.Sizes = sizes;
            model.Colors = colors;
            return View(model);
        }
        [HttpPost]
        [Authorize]

        public JsonResult AddProduct(CreateProductViewModel model)
        {

            using (var scope = new TransactionScope())
            {
                try
                {

                    if (model != null)
                    {
                        var mapped = _mapper.Map<Product>(model);
                        _productService.Insert(mapped);

                        //insertimi ngjyravw
                        foreach (int color in model._ColorIds)
                        {
                            var colorMod = new ProductColorViewModel();
                            var mapModel = _mapper.Map<ProductColor>(colorMod);
                            var colordb = _colorService.GetById(color);
                            mapModel.ColorId = colordb.Id;
                            mapModel.ColorName = colordb.Name;
                            mapModel.ProductId = mapped.ProductId;

                            _productColorService.Insert(mapModel);
                        }

                        //insertimi madhesive
                        foreach (int Size in model._SizeIds)
                        {
                            var sizeMod = new ProductSizeViewModel();
                            var sizeddb = _sizeService.GetById(Size);
                            var mapModel = _mapper.Map<ProductSize>(sizeMod);

                            mapModel.SizeId = sizeddb.Id;
                            mapModel.SizeNr = sizeddb.SizeNr.ToString();
                            mapModel.ProductId = mapped.ProductId;

                            _productSizeService.Insert(mapModel);
                        }//insertimi kategorive
                        foreach (int category in model._CategoryIds)
                        {
                            var catModel = new ProductCategoryViewModel();
                            var catdb = _categoryService.GetById(category);
                            var mapModel = _mapper.Map<ProductCategory>(catModel);
                            mapModel.CategoryId = catdb.Id;
                            mapModel.CategoryName = catdb.Name;
                            mapModel.ProductId = mapped.ProductId;

                            _productCategoryService.Insert(mapModel);
                        }

                        var imgMod = new ImageViewModel();
                        //docMod.SpecialNeedsVotersId = mapped.ProductId;
                        imgMod.Date = DateTime.Now;
                        imgMod.ProductId = mapped.ProductId;
                        foreach (var img in model.File)
                        {
                            if (img.FileName == null)
                                continue;
                            imgMod.DocumentName = img.FileName;
                            InsertImg4All(imgMod, img);
                        }

                        scope.Complete();
                        return Json(new { success = true });
                    }
                    return Json(new { success = false, msg = "Te dhenat nuk u procesuan" });

                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    return Json(new { success = false, msg = "Insertimi deshtoi" });

                }
            }


        }
        #endregion

        #region Color,Size, Category
        [Authorize]

        [HttpGet]
        public IActionResult Size()
        {
            var model = new SettingsViewModel();
            var db = _sizeService.GetAll();
            model.Sizes = _mapper.Map<List<SizeViewModel>>(db);

            return View(model);
        }


        [Authorize]

        [HttpPost]
        public IActionResult CreateSize(SizeViewModel model)
        {

            using (var scope = new TransactionScope())
            {
                try
                {
                    if (model != null)
                    {
                        var mapped = _mapper.Map<Size>(model);
                        _sizeService.Insert(mapped);
                        scope.Complete();
                        return Json(new { success = true });
                    }
                    return Json(new { success = false, msg = "Te dhenat nuk u procesuan" });

                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    return Json(new { success = false, msg = "Insertimi deshtoi" });

                }
            }


        }
        [Authorize]

        [HttpPost]
        public IActionResult UpdateSize(SizeViewModel model, int sizeId)
        {
            using (var scope = new TransactionScope())
            {
                try
                {
                    if (sizeId > 0) // Check for valid ID
                    {
                        // Get the category by ID
                        var size = _sizeService.GetById(sizeId);

                        if (sizeId == null)
                        {
                            return Json(new { success = false, msg = "Size not found" });
                        }

                        var mappedState = _mapper.Map(model, size);
                        // Update the mapped category view model
                        _sizeService.Update(mappedState);


                        scope.Complete();
                        return Json(new { success = true });
                    }
                    return Json(new { success = false, msg = "Invalid category ID" });
                }
                catch (Exception ex)
                {
                    // No need to explicitly call scope.Dispose(), it's handled when exiting the `using` block
                    return Json(new { success = false, msg = "Update failed", error = ex.Message });
                }
            }
        }



        [Authorize]

        [HttpGet]
        public IActionResult Color()
        {
            var db = _colorService.GetAll();
            var model = new SettingsViewModel();
            model.Colors = _mapper.Map<List<ColorViewModel>>(db);

            return View(model);
        }
        [Authorize]

        [HttpPost]
        public IActionResult CreateColor(ColorViewModel model)
        {

            using (var scope = new TransactionScope())
            {
                try
                {
                    if (model != null)
                    {
                        var mapped = _mapper.Map<Color>(model);
                        _colorService.Insert(mapped);
                        scope.Complete();
                        return Json(new { success = true });
                    }
                    return Json(new { success = false, msg = "Te dhenat nuk u procesuan" });

                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    return Json(new { success = false, msg = "Insertimi deshtoi" });

                }
            }


        }
        [Authorize]

        [HttpPost]
        public IActionResult UpdateColor(ColorViewModel model, int colorId)
        {
            using (var scope = new TransactionScope())
            {
                try
                {
                    if (colorId > 0) // Check for valid ID
                    {
                        // Get the category by ID
                        var color = _colorService.GetById(colorId);

                        if (color == null)
                        {
                            return Json(new { success = false, msg = "Category not found" });
                        }

                        var mappedState = _mapper.Map(model, color);
                        // Update the mapped category view model
                        _colorService.Update(mappedState);


                        scope.Complete();
                        return Json(new { success = true });
                    }
                    return Json(new { success = false, msg = "Invalid category ID" });
                }
                catch (Exception ex)
                {
                    // No need to explicitly call scope.Dispose(), it's handled when exiting the `using` block
                    return Json(new { success = false, msg = "Update failed", error = ex.Message });
                }
            }
        }


        [Authorize]

        [HttpGet]
        public IActionResult Category()
        {
            var db = _categoryService.GetAll();
            var model = new SettingsViewModel();
            model.Categories = _mapper.Map<List<CategoryViewModel>>(db);

            return View(model);
        }
        [Authorize]

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryViewModel model)
        {

            using (var scope = new TransactionScope())
            {
                try
                {
                    if (model != null)
                    {
                        var mapped = _mapper.Map<Category>(model);
                        _categoryService.Insert(mapped);


                        if (model.File != null)
                        {
                            var imgMod = new ImageViewModel();
                            //docMod.SpecialNeedsVotersId = mapped.ProductId;
                            imgMod.Date = DateTime.Now;
                            imgMod.CategoryId = mapped.Id;

                            imgMod.DocumentName = model.File.FileName;
                            InsertImg4All(imgMod, model.File);

                        }

                        scope.Complete();
                        return Json(new { success = true });
                    }
                    return Json(new { success = false, msg = "Te dhenat nuk u procesuan" });

                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    return Json(new { success = false, msg = "Insertimi deshtoi" });

                }
            }


        }
        [Authorize]
        [HttpPost]
        public IActionResult UpdateCategory(CreateCategoryViewModel model, int categoryId)
        {
            using (var scope = new TransactionScope())
            {
                try
                {
                    if (categoryId <= 0)
                    {
                        return Json(new { success = false, msg = "Invalid category ID" });
                    }

                    // Fetch the category from the database
                    var category = _categoryService.GetById(categoryId);
                    if (category == null)
                    {
                        return Json(new { success = false, msg = "Category not found" });
                    }

                    // Map the updated data from the view model to the existing entity
                    var updatedCategory = _mapper.Map(model, category);
                    _categoryService.Update(updatedCategory);

                    // Handle image upload if there's a new file
                    if (model.File != null)
                    {
                        var existingImage = _imgService.GetByCategoryId(updatedCategory.Id);
                        if (existingImage != null)
                        {
                            _imgService.Delete(existingImage);
                        }
                        var imgMod = new ImageViewModel
                        {
                            Date = DateTime.Now,
                            CategoryId = updatedCategory.Id,
                            DocumentName = model.File.FileName
                        };

                        // Insert or update image
                        InsertImg4All(imgMod, model.File);
                    }

                    // Commit transaction if everything goes well
                    scope.Complete();

                    return Json(new { success = true });
                }
                catch (Exception ex)
                {
                    // Rollback transaction automatically when the scope is disposed
                    return Json(new { success = false, msg = "Update failed", error = ex.Message });
                }
            }
        }


        #endregion



        [HttpPost]
        public JsonResult InsertImg4All(ImageViewModel model, IFormFile file)
        {
            if (file == null)
            {
                return Json(new { success = false });
            }


            var pathExtension = Path.GetExtension(file.FileName);
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName + pathExtension;


            model.DocumentName = file.FileName;
            model.Path = Path.Combine("/documents/", fileName);
            var mappedList = _mapper.Map<Image>(model);
            _imgService.Insert(mappedList);


            var path = Path.Combine(basicPath, fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                // file.CopyToAsync(stream);
                file.CopyTo(stream);
            }




            return Json(new { success = true });
        }


    }
}
