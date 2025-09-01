using CsvHelper;
using Data;
using DocumentFormat.OpenXml.Office2013.Drawing.Chart;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Services.ProductServ
{
    public class ApiServices : IApiServices
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _cache;
        private readonly ApplicationContext _context; // Your Croatia database context
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(30);
        private readonly IWebHostEnvironment _env;

        public ApiServices(HttpClient httpClient, IConfiguration configuration, IMemoryCache cache, ApplicationContext context, IWebHostEnvironment env)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _cache = cache;
            _context = context;
            _env = env;
        }

        public async Task<List<ApiData>> GetAllAsync(string language = "hr")
        {
            var cacheKey = $"products_{language}";

            if (!_cache.TryGetValue(cacheKey, out List<ApiData> products))
            {
                try
                {
                    // Option 1: Get from your Croatian database (if you have products there)
                    var dbProducts = await _context.Products
                        .Where(p => !p.IsDeleted)
                        .ToListAsync();

                    if (dbProducts.Any())
                    {
                        // Use Croatian database
                        var result = new List<ApiData>();
                        foreach (var dbProduct in dbProducts)
                        {
                            string category = ExtractCategoryFromTitle(dbProduct.Title);
                            var localImages = FindProductImages(category, dbProduct.ProductCode, new List<string> { category });
                            var variants = GetProductVariants(dbProduct);

                            result.Add(new ApiData
                            {
                                ProductCode = dbProduct.ProductCode,
                                GTIN = dbProduct.GTIN,
                                Title = dbProduct.Title, // Already in Croatian
                                Description = dbProduct.Description, // Already in Croatian
                                Brand = dbProduct.Brand,
                                ProductUrl = dbProduct.ProductUrl,
                                ImageUrls = localImages,
                                Categories = new List<string> { category },
                                Price = dbProduct.Price,
                                OldPrice = dbProduct.OldPrice,
                                StoreStockQuantity = dbProduct.Quantity,
                                StoreSupplierQuantity = 0,
                                Variants = variants
                            });
                        }
                        products = result;
                    }
                    else
                    {
                        // Option 2: Get from Croatian ERP directly
                        products = await GetFromCroatianERP();
                    }

                    _cache.Set(cacheKey, products, new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = _cacheExpiration
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error querying database: {ex.Message}");
                    products = new List<ApiData>();
                }
            }

            return products;
        }

        private async Task<List<ApiData>> GetFromCroatianERP()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("ERP"));
            await connection.OpenAsync();

            // New Croatian query - simple and efficient
            string query = @"
                SELECT 
                    items.LOGICALREF,
                    items.CODE AS MAINCODE,
                    items.NAME,
                    ISNULL(items.SPECODE, '') AS SPECODE,
                    ISNULL(items.SPECODE2, '') AS SPECODE2,
                    ISNULL(items.SPECODE3, '') AS SPECODE3,
                    ISNULL(items.SPECODE4, '') AS SPECODE4,
                    ISNULL(items.SPECODE5, '') AS SPECODE5,
                    items.VAT,
                    ISNULL(inv.ONHAND, 0) AS SASIA,
                    '' AS INFO,
                    '' AS INFO2,
                    '' AS PARENT,
                    '' AS OLD_PRICE,
                    '' AS SIZE_VALUE,
                    '' AS DESCRIPTION,
                    '' AS DATE_FILLIMI,
                    '' AS DATA_FUNDIT,
                    0 AS CMIMI_SH,
                    '' AS NJESIA
                FROM lg_011_ITEMS items
                LEFT JOIN LV_011_03_STINVTOT inv ON items.LOGICALREF = inv.STOCKREF 
                    AND inv.INVENNO = 0
                WHERE items.CARDTYPE = 1
                ORDER BY items.CODE;
            ";

            using var command = new SqlCommand(query, connection);
            using var reader = await command.ExecuteReaderAsync();

            var result = new List<ApiData>();
            var variantGroups = new Dictionary<string, List<VariantApi>>();

            while (await reader.ReadAsync())
            {
                string mainCode = reader["MAINCODE"]?.ToString() ?? "";
                string originalName = reader["NAME"]?.ToString() ?? "";

                // Extract base code by removing last 2 digits (size)
                string baseCode = mainCode.Length >= 2 ? mainCode.Substring(0, mainCode.Length - 2) : mainCode;
                string size = mainCode.Length >= 2 ? mainCode.Substring(mainCode.Length - 2) : "00";

                // Use SPECODE4 for category (or fallback to extracting from name)
                string category = !string.IsNullOrEmpty(reader["SPECODE4"]?.ToString())
                    ? reader["SPECODE4"].ToString()
                    : ExtractCategoryFromTitle(originalName);

                var localImages = FindProductImages(category, baseCode, new List<string> { category });

                var variant = new VariantApi
                {
                    ProductCode = mainCode,
                    GTIN = "", // No barcode in this simple query
                    Title = originalName, // Already in Croatian
                    Description = originalName, // Use name as description since products are already in Croatian
                    Brand = reader["SPECODE"]?.ToString() ?? "",
                    ProductUrl = "",
                    ImageUrls = localImages,
                    Categories = new List<string> { category },
                    Price = 0, // No price data in Croatian ERP
                    OldPrice = 0,
                    StoreStockQuantity = reader["SASIA"] != DBNull.Value ? Convert.ToInt32(reader["SASIA"]) : 0,
                    StoreSupplierQuantity = 0,
                    Specifications = new List<Specification>
                    {
                        new Specification
                        {
                            Name = "Veličina", // Size in Croatian
                            Value = size
                        }
                    }
                };

                if (!variantGroups.ContainsKey(baseCode))
                {
                    variantGroups[baseCode] = new List<VariantApi>();
                }

                variantGroups[baseCode].Add(variant);
            }

            // Group variants by base code
            foreach (var group in variantGroups)
            {
                string baseCode = group.Key;
                List<VariantApi> variants = group.Value;
                VariantApi firstVariant = variants.First();

                List<string> allImages = variants
                    .SelectMany(v => v.ImageUrls)
                    .Distinct()
                    .ToList();

                result.Add(new ApiData
                {
                    ProductCode = baseCode,
                    GTIN = firstVariant.GTIN,
                    Title = firstVariant.Title,
                    Description = firstVariant.Description,
                    Brand = firstVariant.Brand,
                    ProductUrl = firstVariant.ProductUrl,
                    ImageUrls = allImages,
                    Categories = firstVariant.Categories,
                    Price = firstVariant.Price,
                    OldPrice = firstVariant.OldPrice,
                    StoreStockQuantity = variants.Sum(v => v.StoreStockQuantity),
                    StoreSupplierQuantity = variants.Sum(v => v.StoreSupplierQuantity),
                    Specifications = new List<Specification>
                    {
                        new Specification
                        {
                            Name = "Dostupne veličine", // Available sizes in Croatian
                            Value = string.Join(", ", variants.Select(v =>
                                v.Specifications.FirstOrDefault(s => s.Name == "Veličina")?.Value ?? "Nepoznato"))
                        }
                    },
                    Variants = variants
                });
            }

            return result;
        }

        private string ExtractCategoryFromTitle(string title)
        {
            if (string.IsNullOrEmpty(title)) return "DEFAULT";

            var parts = title.Split('-');
            if (parts.Length >= 2)
            {
                return parts[1].Trim();
            }
            return "DEFAULT";
        }

        private List<string> FindProductImages(string categoryPath, string imageSearchCode, List<string> category)
        {
            var localImages = new List<string>();

            string fullCategoryPath = Path.Combine("wwwroot", "Products", category.Count > 0 ? category[0] : "");

            if (Directory.Exists(fullCategoryPath))
            {
                var matchingDirs = Directory.GetDirectories(fullCategoryPath)
                 .Where(dir =>
                 {
                     string folderName = Path.GetFileName(dir);
                     if (folderName.Equals(imageSearchCode, StringComparison.OrdinalIgnoreCase))
                         return true;
                     if (folderName.Contains(". " + imageSearchCode, StringComparison.OrdinalIgnoreCase))
                         return true;
                     string normalizedFolder = folderName.Replace(" ", "").Replace("-", "").ToUpper();
                     string normalizedSearch = imageSearchCode.Replace(" ", "").Replace("-", "").ToUpper();
                     if (normalizedFolder.Contains(normalizedSearch))
                         return true;
                     return false;
                 })
                 .OrderBy(dir =>
                 {
                     string folderName = Path.GetFileName(dir);
                     if (folderName.Contains(". "))
                     {
                         string[] parts = folderName.Split(new string[] { ". " }, StringSplitOptions.RemoveEmptyEntries);
                         if (int.TryParse(parts[0], out int num))
                             return num;
                     }
                     return 1000;
                 });

                bool imageFound = false;
                foreach (var dir in matchingDirs)
                {
                    var foundImages = Directory.GetFiles(dir)
                        .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) || f.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                        .Where(f => !Path.GetFileName(f).StartsWith("P ") &&
                                   !char.IsDigit(Path.GetFileName(f)[0]) &&
                                   !Path.GetFileName(f).Equals("index.html", StringComparison.OrdinalIgnoreCase))
                        .Select(f => Path.Combine("/Products", category[0], Path.GetFileName(dir), Path.GetFileName(f)).Replace("\\", "/"))
                        .ToList();

                    if (foundImages.Any())
                    {
                        var orderedImages = foundImages
                            .OrderByDescending(img =>
                                img.EndsWith("_1.jpg", StringComparison.OrdinalIgnoreCase) ||
                                img.EndsWith("_1.png", StringComparison.OrdinalIgnoreCase))
                            .ThenBy(img => img)
                            .ToList();

                        localImages = orderedImages;
                        imageFound = true;
                        break;
                    }
                }

                if (!imageFound)
                {
                    localImages = new List<string> { "/no-image.png" };
                }
            }
            else
            {
                localImages = new List<string> { "/no-image.png" };
            }

            return localImages;
        }

        private List<VariantApi> GetProductVariants(Product product)
        {
            // Implement this based on how you want to handle product variants from your database
            return new List<VariantApi>();
        }

        public async Task<ApiData> GetByIdAsync(string productId, string language = "hr")
        {
            var products = await GetAllAsync(language);
            var product = products.FirstOrDefault(p => p.ProductCode == productId);

            if (product == null)
            {
                throw new Exception($"Product with ProductCode {productId} not found.");
            }

            return product;
        }

        public Task<List<ApiData>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}