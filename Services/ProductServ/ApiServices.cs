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

        // Category descriptions - same description for all products in category
        private readonly Dictionary<string, Dictionary<string, string>> _categoryTranslations = new()
        {
            ["ARTSY"] = new()
            {
                ["hr"] = "Anatomske cipele koje vam omogućavaju da se osjećate dobro.",
                ["en"] = "Anatomical shoes that make you feel good."
            },
            ["PRIAM"] = new()
            {
                ["hr"] = "Udobne anatomske cipele za svakodnevno nošenje.",
                ["en"] = "Comfortable anatomical shoes for everyday wear."
            },
            ["LURA"] = new()
            {
                ["hr"] = "Stylish anatomske cipele u različitim bojama.",
                ["en"] = "Stylish anatomical shoes in various colors."
            },
            ["ZOE"] = new()
            {
                ["hr"] = "Moderne anatomske cipele za aktivnu ženu.",
                ["en"] = "Modern anatomical shoes for the active woman."
            },
            ["RUBIK"] = new()
            {
                ["hr"] = "Dinamičke anatomske cipele s jedinstvenim dizajnom.",
                ["en"] = "Dynamic anatomical shoes with unique design."
            },
            ["LANA"] = new()
            {
                ["hr"] = "Elegantne anatomske cipele za posebne prilike.",
                ["en"] = "Elegant anatomical shoes for special occasions."
            },
            ["JULIET"] = new()
            {
                ["hr"] = "Romantične anatomske cipele s delikatnim detaljima.",
                ["en"] = "Romantic anatomical shoes with delicate details."
            },
            ["ALBA"] = new()
            {
                ["hr"] = "Klasične anatomske cipele za svaki dan.",
                ["en"] = "Classic anatomical shoes for every day."
            },
            ["MAVERICK"] = new()
            {
                ["hr"] = "Anatomske sandale za muškarce - udobne i izdržljive.",
                ["en"] = "Anatomical sandals for men - comfortable and durable."
            },
            ["PRIAM MEN"] = new()
            {
                ["hr"] = "Muške anatomske cipele za profesionalnu upotrebu.",
                ["en"] = "Men's anatomical shoes for professional use."
            },
            ["ROMEO"] = new()
            {
                ["hr"] = "Elegantne muške anatomske cipele.",
                ["en"] = "Elegant men's anatomical shoes."
            },
            ["ANTONIO"] = new()
            {
                ["hr"] = "Klasične muške anatomske cipele.",
                ["en"] = "Classic men's anatomical shoes."
            },
            ["NOMAD"] = new()
            {
                ["hr"] = "Muške anatomske cipele za aktivni životni stil.",
                ["en"] = "Men's anatomical shoes for active lifestyle."
            }
        };

        // Color translations
        private readonly Dictionary<string, Dictionary<string, string>> _colorTranslations = new()
        {
            ["e zeze"] = new() { ["hr"] = "crne", ["en"] = "black" },
            ["e bardhe"] = new() { ["hr"] = "bijele", ["en"] = "white" },
            ["e kuqe"] = new() { ["hr"] = "crvene", ["en"] = "red" },
            ["e gjelber"] = new() { ["hr"] = "zelene", ["en"] = "green" },
            ["e gjelbert"] = new() { ["hr"] = "zelene", ["en"] = "green" },
            ["e kalter"] = new() { ["hr"] = "plave", ["en"] = "blue" },
            ["e kaltert"] = new() { ["hr"] = "plave", ["en"] = "blue" },
            ["e kaltEr"] = new() { ["hr"] = "plave", ["en"] = "blue" },
            ["e kaltErt"] = new() { ["hr"] = "plave", ["en"] = "blue" },
            ["Blue e erret"] = new() { ["hr"] = "tamno plave", ["en"] = "dark blue" },
            ["blu e erret"] = new() { ["hr"] = "tamno plave", ["en"] = "dark blue" },
            ["Blu e erret"] = new() { ["hr"] = "tamno plave", ["en"] = "dark blue" },
            ["e kuqe e erret"] = new() { ["hr"] = "tamno crvene", ["en"] = "dark red" },
            ["kuqe e erret"] = new() { ["hr"] = "tamno crvene", ["en"] = "dark red" },
            ["kafe"] = new() { ["hr"] = "kafe boje", ["en"] = "coffee" },
            ["kafe e erret"] = new() { ["hr"] = "tamno kafe", ["en"] = "dark coffee" },
            ["Kafe e erret"] = new() { ["hr"] = "tamno kafe", ["en"] = "dark coffee" },
            ["verdhe"] = new() { ["hr"] = "žute", ["en"] = "yellow" },
            ["Verdhe"] = new() { ["hr"] = "žute", ["en"] = "yellow" },
            ["hiri"] = new() { ["hr"] = "sive", ["en"] = "grey" },
            ["vjollce"] = new() { ["hr"] = "ljubičaste", ["en"] = "purple" },
            ["Vjollce"] = new() { ["hr"] = "ljubičaste", ["en"] = "purple" },
            ["Bordo"] = new() { ["hr"] = "bordo", ["en"] = "burgundy" },
            ["Mocha"] = new() { ["hr"] = "mocha", ["en"] = "mocha" },
            ["Pacific"] = new() { ["hr"] = "pacific plava", ["en"] = "pacific blue" },
            ["Pastel Roze"] = new() { ["hr"] = "pastel ružičasta", ["en"] = "pastel pink" },
            ["Roze e lehte"] = new() { ["hr"] = "svjetlo ružičasta", ["en"] = "light pink" },
            ["Turkeze"] = new() { ["hr"] = "tirkizna", ["en"] = "turquoise" },
            ["Orchide"] = new() { ["hr"] = "orhideja", ["en"] = "orchid" },
            ["Maroon"] = new() { ["hr"] = "kestenjasta", ["en"] = "maroon" },
            ["Lime"] = new() { ["hr"] = "lime zelena", ["en"] = "lime green" },
            ["kajsi"] = new() { ["hr"] = "kajsija", ["en"] = "apricot" },
            ["biskote"] = new() { ["hr"] = "biscuit", ["en"] = "biscuit" },
            ["BezhE"] = new() { ["hr"] = "bež", ["en"] = "beige" }
        };

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
                            string title = TranslateProductTitle(dbProduct.Title, language);
                            string description = GetCategoryDescription(dbProduct.Title, language);
                            string category = ExtractCategoryFromTitle(dbProduct.Title);
                            var localImages = FindProductImages(category, dbProduct.ProductCode, new List<string> { category });
                            var variants = GetProductVariants(dbProduct);

                            result.Add(new ApiData
                            {
                                ProductCode = dbProduct.ProductCode,
                                GTIN = dbProduct.GTIN,
                                Title = title,
                                Description = description,
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
                        // Option 2: Get from ERP and translate (your original logic)
                        products = await GetFromERPAndTranslate(language);
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

        private async Task<List<ApiData>> GetFromERPAndTranslate(string language)
        {
            // Your original ERP logic with translations
            using var connection = new SqlConnection(_configuration.GetConnectionString("ERP"));
            await connection.OpenAsync();

            string query = @"
                Select LOGICALREF,ITEMREF,(select CODE from lg_001_ITEMS where LOGICALREF=A.ITEMREF ) AS MAINCODE,BARCODE,UNITLINEREF,
							(select SPECODE from lg_001_ITEMS where LOGICALREF=A.ITEMREF ) AS SPECODE,
							(select SPECODE2 from lg_001_ITEMS where LOGICALREF=A.ITEMREF ) AS SPECODE2,
							(select SPECODE3 from lg_001_ITEMS where LOGICALREF=A.ITEMREF ) AS SPECODE3,
							(select SPECODE4 from lg_001_ITEMS where LOGICALREF=A.ITEMREF ) AS SPECODE4,
							(select SPECODE5 from lg_001_ITEMS where LOGICALREF=A.ITEMREF ) AS SPECODE5,
                            isnull((Select SUM(STINVTOT.ONHAND) FROM  LV_001_04_STINVTOT AS STINVTOT LEFT OUTER JOIN LG_001_ITEMS AS ITEMS ON STINVTOT.STOCKREF=ITEMS.LOGICALREF WHERE Items.CARDTYPE=1 AND STINVTOT.INVENNO=-1 AND ITEMS.CODE=(select CODE from lg_001_ITEMS where LOGICALREF=A.ITEMREF )),0) AS SASIA,
							isnull((Select 'https://www.nallan.eu/index.php?'+TEXTFLDS1+'~https://nallan.eu/products/'+TEXTFLDS2 +'~https://nallan.eu/products/'+TEXTFLDS3+'~'+TEXTFLDS10+'~'+TEXTFLDS11+'~'+TEXTFLDS12+'~'+TEXTFLDS13+'~'+cast(NUMFLDS5 as varchar)  AS OldPrice from LG_001_DEFNFLDSCARDV where PARENTREF=A.ITEMREF),'') AS INFO,
                            isnull((Select 'https://nallan.eu/products/'+TEXTFLDS4+'~https://nallan.eu/products/'+TEXTFLDS6+'~https://nallan.eu/products/'+TEXTFLDS7+'~https://nallan.eu/products/'+TEXTFLDS8+'~https://nallan.eu/products/'+TEXTFLDS9 from LG_001_DEFNFLDSCARDV where PARENTREF=A.ITEMREF),'') AS INFO2,
                            isnull((Select TEXTFLDS14 from LG_001_DEFNFLDSCARDV where PARENTREF=A.ITEMREF),'') AS PARENT,
							ISNULL((
    SELECT CAST(NUMFLDS5 AS VARCHAR)
    FROM LG_001_DEFNFLDSCARDV
    WHERE PARENTREF = A.ITEMREF
), '') AS OLD_PRICE,

ISNULL((
    SELECT TEXTFLDS13
    FROM LG_001_DEFNFLDSCARDV
    WHERE PARENTREF = A.ITEMREF
), '') AS SIZE_VALUE,

ISNULL((
    SELECT TEXTFLDS10
    FROM LG_001_DEFNFLDSCARDV
    WHERE PARENTREF = A.ITEMREF
), '') AS DESCRIPTION,

                            (select Top 1 REPLACE(REPLACE(itm.name,'Ë','E'),'ë','e') AS name from Nallan.dbo.lg_001_prclist prc left join lg_001_items itm on itm.logicalref = prc.cardref LEFT JOIN lg_001_UNITSETL USL ON PRC.UOMREF = USL.LOGICALREF where  (PRC.clspecode = '"" & Njesia & ""' OR PRC.CLSPECODE = '')  and PRC.ptype = 2 /* AND PRC.UOMREF IN(23, 26,30, 31) */ and itm.CODE=((select CODE from lg_001_ITEMS where LOGICALREF=A.ITEMREF )) and usl.LOGICALREF=A.UNITLINEREF ORDER BY ITM.CODE , PRC.PRIORITY, PRC.BEGDATE  DESC,  PRC.CLSPECODE DESC) AS name,
                            (select Top 1 PRC.BEGDATE  AS DATE_FILLIMI from Nallan.dbo.lg_001_prclist prc left join lg_001_items itm on itm.logicalref = prc.cardref LEFT JOIN lg_001_UNITSETL USL ON PRC.UOMREF = USL.LOGICALREF where  (PRC.clspecode = 'Njesia' OR PRC.CLSPECODE = '')  and PRC.ptype = 2 /* AND PRC.UOMREF IN(23, 26,30, 31) */ and itm.CODE=((select CODE from lg_001_ITEMS where LOGICALREF=A.ITEMREF )) and usl.LOGICALREF=A.UNITLINEREF ORDER BY ITM.CODE , PRC.PRIORITY, PRC.BEGDATE  DESC,  PRC.CLSPECODE DESC) AS DATE_FILLIMI,
                            (select Top 1 PRC.ENDDATE AS DATA_FUNDIT from Nallan.dbo.lg_001_prclist prc left join lg_001_items itm on itm.logicalref = prc.cardref LEFT JOIN lg_001_UNITSETL USL ON PRC.UOMREF = USL.LOGICALREF where  (PRC.clspecode = 'Njesia' OR PRC.CLSPECODE = '')  and PRC.ptype = 2 /* AND PRC.UOMREF IN(23, 26,30, 31) */ and itm.CODE=((select CODE from lg_001_ITEMS where LOGICALREF=A.ITEMREF )) and usl.LOGICALREF=A.UNITLINEREF ORDER BY ITM.CODE , PRC.PRIORITY, PRC.BEGDATE  DESC,  PRC.CLSPECODE DESC) AS DATA_FUNDIT,
                            (select Top 1 PRC.PRICE AS CMIMI_SH from Nallan.dbo.lg_001_prclist prc left join lg_001_items itm on itm.logicalref = prc.cardref LEFT JOIN lg_001_UNITSETL USL ON PRC.UOMREF = USL.LOGICALREF where  (PRC.clspecode = 'Njesia' OR PRC.CLSPECODE = '')  and PRC.ptype = 2 /* AND PRC.UOMREF IN(23, 26,30, 31) */ and itm.CODE=((select CODE from lg_001_ITEMS where LOGICALREF=A.ITEMREF )) and usl.LOGICALREF=A.UNITLINEREF ORDER BY ITM.CODE , PRC.PRIORITY, PRC.BEGDATE  DESC,  PRC.CLSPECODE DESC) AS CMIMI_SH,
                            (select Top 1 USL.CODE AS NJESIA from Nallan.dbo.lg_001_prclist prc left join lg_001_items itm on itm.logicalref = prc.cardref LEFT JOIN lg_001_UNITSETL USL ON PRC.UOMREF = USL.LOGICALREF where  (PRC.clspecode = 'Njesia' OR PRC.CLSPECODE = '')  and PRC.ptype = 2 /* AND PRC.UOMREF IN(23, 26,30, 31) */ and itm.CODE=((select CODE from lg_001_ITEMS where LOGICALREF=A.ITEMREF )) and usl.LOGICALREF=A.UNITLINEREF ORDER BY ITM.CODE , PRC.PRIORITY, PRC.BEGDATE  DESC,  PRC.CLSPECODE DESC) AS NJESIA,
                            (select Top 1 itm.VAT AS VAT from Nallan.dbo.lg_001_prclist prc left join lg_001_items itm on itm.logicalref = prc.cardref LEFT JOIN lg_001_UNITSETL USL ON PRC.UOMREF = USL.LOGICALREF where  (PRC.clspecode = 'Njesia' OR PRC.CLSPECODE = '') and PRC.ptype = 2 /* AND PRC.UOMREF IN(23, 26,30, 31) */ and itm.CODE=((select CODE from lg_001_ITEMS where LOGICALREF=A.ITEMREF )) and usl.LOGICALREF=A.UNITLINEREF ORDER BY ITM.CODE , PRC.PRIORITY, PRC.BEGDATE  DESC,  PRC.CLSPECODE DESC)AS VAT
                            from lg_001_UNITBARCODE A  where (select Top 1 PRC.PRICE AS CMIMI_SH from Nallan.dbo.lg_001_prclist prc left join lg_001_items itm on itm.logicalref = prc.cardref LEFT JOIN lg_001_UNITSETL USL ON PRC.UOMREF = USL.LOGICALREF where  (PRC.clspecode = 'Njesia' OR PRC.CLSPECODE = '')  and PRC.ptype = 2 /* AND PRC.UOMREF IN(23, 26,30, 31) */ and itm.CODE=((select CODE from lg_001_ITEMS where LOGICALREF=A.ITEMREF )) and usl.LOGICALREF=A.UNITLINEREF ORDER BY ITM.CODE , PRC.PRIORITY, PRC.BEGDATE  DESC,  PRC.CLSPECODE DESC) is not null Order by MAINCODE;
            ";

            using var command = new SqlCommand(query, connection);
            using var reader = await command.ExecuteReaderAsync();

            var result = new List<ApiData>();
            var variantGroups = new Dictionary<string, List<VariantApi>>();

            while (await reader.ReadAsync())
            {
                string info = reader["INFO"]?.ToString() ?? "";
                List<string> localImages = new();

                var category = reader["SPECODE4"]?.ToString()?.Split('~', StringSplitOptions.RemoveEmptyEntries).ToList() ?? new List<string>();
                string mainCode = reader["MAINCODE"]?.ToString() ?? "";
                string originalName = reader["name"]?.ToString() ?? "";

                // Extract base code by removing last 2 digits (size)
                string baseCode = mainCode.Length >= 2 ? mainCode.Substring(0, mainCode.Length - 2) : mainCode;
                string size = mainCode.Length >= 2 ? mainCode.Substring(mainCode.Length - 2) : "00";

                string imageSearchCode = baseCode;
                string categoryPath = Path.Combine("wwwroot", "Products", category.Count > 0 ? category[0] : "");
                localImages = FindProductImages(categoryPath, imageSearchCode, category);

                // Translate the product name and get category description
                string translatedTitle = TranslateProductTitle(originalName, language);
                string categoryDescription = GetCategoryDescription(originalName, language);

                var variant = new VariantApi
                {
                    ProductCode = mainCode,
                    GTIN = reader["BARCODE"]?.ToString(),
                    Title = translatedTitle,
                    Description = categoryDescription,
                    Brand = reader["SPECODE"]?.ToString(),
                    ProductUrl = info,
                    ImageUrls = localImages,
                    Categories = category,
                    Price = reader["CMIMI_SH"] != DBNull.Value ? Convert.ToDecimal(reader["CMIMI_SH"]) : 0,
                    OldPrice = decimal.TryParse(reader["OLD_PRICE"]?.ToString(), out var oldPrice1) ? oldPrice1 : 0,
                    StoreStockQuantity = reader["SASIA"] != DBNull.Value ? Convert.ToInt32(reader["SASIA"]) : 0,
                    StoreSupplierQuantity = 0,
                    Specifications = new List<Specification>
                    {
                        new Specification
                        {
                            Name = "Madhesia",
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
                            Name = "Available Sizes",
                            Value = string.Join(", ", variants.Select(v =>
                                v.Specifications.FirstOrDefault(s => s.Name == "Madhesia")?.Value ?? "Unknown"))
                        }
                    },
                    Variants = variants
                });
            }

            return result;
        }

        private string TranslateProductTitle(string originalTitle, string language)
        {
            if (string.IsNullOrEmpty(originalTitle)) return originalTitle;

            string translatedTitle = originalTitle;

            if (language == "hr")
            {
                translatedTitle = translatedTitle
                    .Replace("Papuçe Anatomike per Femra", "Anatomske cipele za žene")
                    .Replace("Papuçe e Anatomike per Femra", "Anatomske cipele za žene")
                    .Replace("Papuqe Anatomike per Femra", "Anatomske cipele za žene")
                    .Replace("Sandale Anatomike per Meshkuj", "Anatomske sandale za muškarce")
                    .Replace("Papuçe Anatomike per Meshkuj", "Anatomske cipele za muškarce")
                    .Replace("Papuçe Anato. per Meshkuj", "Anatomske cipele za muškarce");

                foreach (var colorPair in _colorTranslations)
                {
                    if (colorPair.Value.ContainsKey("hr"))
                    {
                        translatedTitle = translatedTitle.Replace($"-{colorPair.Key}", $" - {colorPair.Value["hr"]}");
                    }
                }
            }
            else if (language == "en")
            {
                translatedTitle = translatedTitle
                    .Replace("Papuçe Anatomike per Femra", "Anatomical Shoes for Women")
                    .Replace("Papuçe e Anatomike per Femra", "Anatomical Shoes for Women")
                    .Replace("Papuqe Anatomike per Femra", "Anatomical Shoes for Women")
                    .Replace("Sandale Anatomike per Meshkuj", "Anatomical Sandals for Men")
                    .Replace("Papuçe Anatomike per Meshkuj", "Anatomical Shoes for Men")
                    .Replace("Papuçe Anato. per Meshkuj", "Anatomical Shoes for Men");

                foreach (var colorPair in _colorTranslations)
                {
                    if (colorPair.Value.ContainsKey("en"))
                    {
                        translatedTitle = translatedTitle.Replace($"-{colorPair.Key}", $" - {colorPair.Value["en"]}");
                    }
                }
            }

            return translatedTitle;
        }

        private string GetCategoryDescription(string productTitle, string language)
        {
            string category = ExtractCategoryFromTitle(productTitle);

            if (_categoryTranslations.ContainsKey(category) &&
                _categoryTranslations[category].ContainsKey(language))
            {
                return _categoryTranslations[category][language];
            }

            return language == "hr" ? "Kvalitetne cipele za udobnost i stil." : "Quality shoes for comfort and style.";
        }

        private string ExtractCategoryFromTitle(string title)
        {
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

            if (Directory.Exists(categoryPath))
            {
                var matchingDirs = Directory.GetDirectories(categoryPath)
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