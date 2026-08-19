using CsvHelper;
using Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Services.ProductServ
{
    public class ApiServices : IApiServices
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _cache;
        private readonly ApplicationContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(30);

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
                    var dbProducts = await _context.Products
                        .Where(p => !p.IsDeleted)
                        .ToListAsync();

                    if (dbProducts.Any())
                    {
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
                                Title = dbProduct.Title,
                                Description = dbProduct.Description,
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
                        products = await GetFromCroatianERP();
                    }

                    _cache.Set(cacheKey, products, new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = _cacheExpiration
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"⚠️ Error querying DB: {ex.Message}");
                    products = new List<ApiData>();
                }
            }

            return products;
        }

        private async Task<List<ApiData>> GetFromCroatianERP()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("ERP"));
            await connection.OpenAsync();

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
                    ISNULL(inv.ONHAND, 0) AS SASIA
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

                string baseCode = mainCode.Length >= 2 ? mainCode[..^2] : mainCode;
                string size = mainCode.Length >= 2 ? mainCode[^2..] : "00";

                string category = !string.IsNullOrEmpty(reader["SPECODE4"]?.ToString())
                    ? reader["SPECODE4"].ToString()
                    : ExtractCategoryFromTitle(originalName);

                var localImages = FindProductImages(category, baseCode, new List<string> { category });

                var variant = new VariantApi
                {
                    ProductCode = mainCode,
                    GTIN = "",
                    Title = originalName,
                    Description = originalName,
                    Brand = reader["SPECODE"]?.ToString() ?? "",
                    ProductUrl = "",
                    ImageUrls = localImages,
                    Categories = new List<string> { category },
                    Price = 0,
                    OldPrice = 0,
                    StoreStockQuantity = reader["SASIA"] != DBNull.Value ? Convert.ToInt32(reader["SASIA"]) : 0,
                    StoreSupplierQuantity = 0,
                    Specifications = new List<Specification>
                    {
                        new Specification
                        {
                            Name = "Veličina",
                            Value = size
                        }
                    }
                };

                if (!variantGroups.ContainsKey(baseCode))
                    variantGroups[baseCode] = new List<VariantApi>();

                variantGroups[baseCode].Add(variant);
            }

            foreach (var group in variantGroups)
            {
                var baseCode = group.Key;
                var variants = group.Value;
                var firstVariant = variants.First();

                var allImages = variants
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
                            Name = "Dostupne veličine",
                            Value = string.Join(", ", variants.Select(v =>
                                v.Specifications.FirstOrDefault(s => s.Name == "Veličina")?.Value ?? "Nepoznato"))
                        }
                    },
                    Variants = variants
                });
            }

            try
            {
                string logDir = Path.Combine(_env.ContentRootPath, "logs");
                Directory.CreateDirectory(logDir);

                string logPath = Path.Combine(logDir, $"articles_hr_{DateTime.Now:yyyyMMdd_HHmmss}.json");
                string json = JsonConvert.SerializeObject(result, Formatting.Indented);
                await File.WriteAllTextAsync(logPath, json, Encoding.UTF8);
                Console.WriteLine($"✅ Articles logged to: {logPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Failed to log JSON: {ex.Message}");
            }

            return result;
        }

        private string ExtractCategoryFromTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title)) return "DEFAULT";
            var parts = title.Split('-');
            return parts.Length >= 2 ? parts[1].Trim() : "DEFAULT";
        }

        private string NormalizeCode(string code)
        {
            code = Regex.Replace(code ?? "", @"[^A-Z0-9]", "").ToUpperInvariant();

            code = code
                .Replace("BLCK", "BLK")
                .Replace("BLACK", "BLK")
                .Replace("DKBL", "BLK")
                .Replace("DARKBLU", "BLU")
                .Replace("NAVY", "BLU")
                .Replace("WHIT", "WHT")
                .Replace("WHITE", "WHT")
                .Replace("BGE", "BEG")
                .Replace("BG", "BEG")
                .Replace("BRN", "BRWN")
                .Replace("GRY", "GREY")
                .Replace("RED", "RD")
                .Replace("PINK", "PNK")
                .Replace("YELL", "YLW")
                .Replace("BEIGE", "BEG");

            code = Regex.Replace(code, @"(\D)0+(\d{2,})", "$1$2");
            return code;
        }

        private static List<string>? _allProductDirsCache = null;

        private List<string> FindProductImages(string categoryPath, string imageSearchCode, List<string> category)
        {
            var localImages = new List<string>();
            string rootPath = Path.Combine(_env.WebRootPath, "Products");

            if (!Directory.Exists(rootPath))
                return new List<string> { "/no-image.png" };

            if (_allProductDirsCache == null)
            {
                _allProductDirsCache = new List<string>();
                var genderFolders = new[] { "WOMAN", "MAN", "KIDS" };
                foreach (var gender in genderFolders)
                {
                    var path = Path.Combine(rootPath, gender);
                    if (Directory.Exists(path))
                        _allProductDirsCache.AddRange(Directory.GetDirectories(path, "*", SearchOption.AllDirectories));
                }
            }

            string normalizedSearch = NormalizeCode(imageSearchCode);

            var matchingDirs = _allProductDirsCache
                .Where(dir =>
                {
                    string folderName = Path.GetFileName(dir);
                    string normalizedFolder = NormalizeCode(folderName);
                    bool prefixMatch = normalizedFolder.StartsWith(normalizedSearch[..Math.Min(10, normalizedSearch.Length)]);
                    bool midMatch = normalizedFolder.Contains(normalizedSearch);
                    bool suffixMatch = normalizedFolder.EndsWith(normalizedSearch[^6..]);
                    return prefixMatch || midMatch || suffixMatch;
                })
                .Distinct()
                .ToList();

            if (!matchingDirs.Any())
            {
                LogMissingImage(imageSearchCode, category);
                return new List<string> { "/no-image.png" };
            }

            foreach (var dir in matchingDirs)
            {
                var foundImages = Directory.GetFiles(dir)
                    .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                f.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                    .Where(f => !Path.GetFileName(f).Equals("index.html", StringComparison.OrdinalIgnoreCase))
                    .Select(f =>
                    {
                        var relativePath = f.Replace(_env.WebRootPath, "").Replace("\\", "/");
                        if (!relativePath.StartsWith("/")) relativePath = "/" + relativePath;
                        return relativePath;
                    })
                    .ToList();

                if (foundImages.Any())
                {
                    localImages = foundImages
                        .OrderByDescending(img => img.EndsWith("_1.jpg", StringComparison.OrdinalIgnoreCase) ||
                                                  img.EndsWith("_1.png", StringComparison.OrdinalIgnoreCase))
                        .ThenBy(img => img)
                        .ToList();
                    break;
                }
            }

            if (!localImages.Any())
            {
                LogMissingImage(imageSearchCode, category);
                localImages = new List<string> { "/no-image.png" };
            }

            return localImages;
        }

        private void LogMissingImage(string code, List<string> category)
        {
            try
            {
                string logDir = Path.Combine(_env.ContentRootPath, "logs");
                Directory.CreateDirectory(logDir);
                string logPath = Path.Combine(logDir, "missing_images_hr.txt");
                string line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | Code: {code} | Category: {(category.Count > 0 ? category[0] : "Unknown")}";
                File.AppendAllLines(logPath, new[] { line });
            }
            catch { /* ignore */ }
        }

        private List<VariantApi> GetProductVariants(Product product)
        {
            return new List<VariantApi>();
        }

        public async Task<ApiData> GetByIdAsync(string productId, string language = "hr")
        {
            var products = await GetAllAsync(language);
            var product = products.FirstOrDefault(p => p.ProductCode == productId);

            if (product == null)
                throw new Exception($"Product with ProductCode {productId} not found.");

            return product;
        }

        public Task<List<ApiData>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
