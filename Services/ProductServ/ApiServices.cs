using CsvHelper;
using Data;
using DocumentFormat.OpenXml.Office2013.Drawing.Chart;
using Microsoft.AspNetCore.Hosting;
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
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Services.ProductServ
{
    public class ApiServices : IApiServices
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _cache;
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(30); // example cache expiration
        private readonly IWebHostEnvironment _env;

        public ApiServices(HttpClient httpClient, IConfiguration configuration, IMemoryCache cache, IWebHostEnvironment env)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _cache = cache;
            _env = env;
        }

        public async Task<List<ApiData>> GetAllAsync()
        {
            var cacheKey = "articles";

            if (!_cache.TryGetValue(cacheKey, out List<ApiData> articles))
            {
                try
                {
                    var csvPath = _configuration["CsvSettings:ArticleCsvPath"];

                    if (!File.Exists(csvPath))
                    {
                        Console.WriteLine("CSV file not found.");
                        return new List<ApiData>();
                    }

                    using var reader = new StreamReader(csvPath);
                    using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

                    // Read from CSV using the correct model
                    var rawArticles = csv.GetRecords<Articles>().ToList();

                    // Map Articles to ArticleData
                    articles = rawArticles.Select(article => new ApiData
                    {
                        ProductCode = article.MAINCODE,
                        GTIN = article.BARCODE,
                        Title = article.name,
                        Description = article.SPECODE2,
                        Brand = article.SPECODE,
                        ProductUrl = article.INFO,
                        ImageUrls = article.INFO?
    .Split('~', StringSplitOptions.RemoveEmptyEntries)
    .Where(url => url.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) || url.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
    .ToList() ?? new List<string>(),
                        Categories = article.SPECODE4?.Split('~', StringSplitOptions.RemoveEmptyEntries).ToList() ?? new List<string>(),
                        Price = article.CMIMI_SH,
                        OldPrice = 20,
                        StoreStockQuantity = (int)article.SASIA,
                        StoreSupplierQuantity = 0,
                        Specifications = new List<Specification>
                        {
                            new Specification { Name = "Color", Value = "Blue" },
                        },



                        Variants = new List<VariantApi>
                        {
                            new VariantApi
                            {
                                ProductCode = article.MAINCODE,
                        GTIN = article.BARCODE,
                        Title = article.name,
                        Description = article.SPECODE2,
                        Brand = article.SPECODE,
                        ProductUrl = article.INFO,
                        ImageUrls = new List<string>(),
                        Categories = article.SPECODE4?.Split('~', StringSplitOptions.RemoveEmptyEntries).ToList() ?? new List<string>(),
                        Price = article.CMIMI_SH,
                        OldPrice = 20,
                        StoreStockQuantity = (int)article.SASIA,
                        StoreSupplierQuantity = 0,
                        Specifications = new List<Specification>
                        {
                            new Specification { Name = "Blue", Value = "38" },
                        },
                            }
                        }
                    }).ToList();

                    // Set to cache
                    _cache.Set(cacheKey, articles, new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = _cacheExpiration
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading CSV: {ex.Message}");
                    articles = new List<ApiData>();
                }
            }

            return articles;
        }




        // Implement other methods similarly...

        public async Task<ApiData> GetByIdAsync(string productId)
        {
            // Reuse the GetAllAsync method to fetch all products from the cache or API
            var products = await GetAllAsync();

            // Find the product with the matching ProductCode
            var product = products.FirstOrDefault(p => p.ProductCode == productId);

            // If no product is found, throw an exception or return null (your choice)
            if (product == null)
            {
                throw new Exception($"Product with ProductCode {productId} not found.");
            }

            return product;
        }
    }
}
