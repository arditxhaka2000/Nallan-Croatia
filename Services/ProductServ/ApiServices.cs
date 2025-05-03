using Data;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

        public ApiServices(HttpClient httpClient, IConfiguration configuration, IMemoryCache cache)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _cache = cache;
        }

        public async Task<List<ApiData>> GetAllAsync()
        {
            var cacheKey = "products";

            // Check if products are in cache
            if (!_cache.TryGetValue(cacheKey, out List<ApiData> products))
            {
                try
                {
                    var apiUrl = _configuration["ApiSettings:ProductApiUrl"];
                    var response = await _httpClient.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var xmlContent = await response.Content.ReadAsStringAsync();
                        var xmlDoc = XDocument.Parse(xmlContent);
                        var jsonString = xmlDoc.Root?.Value;

                        products = JsonConvert.DeserializeObject<List<ApiData>>(jsonString);


                        products = products
                            .Select(product =>
                            {
                                product.Variants = product.Variants
                                    .Where(variant => variant.StoreStockQuantity > 0)
                                    .ToList();
                                return product;
                            })
                            .Where(product => product.Variants.Any()) // Exclude products with no variants in stock
                            .ToList();

                        _cache.Set(cacheKey, products, new MemoryCacheEntryOptions
                        {
                            AbsoluteExpirationRelativeToNow = _cacheExpiration
                        });
                    }
                    else
                    {
                        Console.WriteLine($"Error fetching products: {response.StatusCode} - {response.ReasonPhrase}");
                        products = new List<ApiData>(); // Return empty list as fallback
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Server is not responding: {ex.Message}");
                    products = new List<ApiData>(); // Return empty list if server is down
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected error: {ex.Message}");
                    products = new List<ApiData>(); // Return empty list for any unexpected error
                }
            }

            return products;
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
