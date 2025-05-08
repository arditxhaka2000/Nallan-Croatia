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

                    while (await reader.ReadAsync())
                    {
                        string info = reader["INFO"]?.ToString() ?? "";
                        string[] imageUrls = info.Split('~', StringSplitOptions.RemoveEmptyEntries)
                                                 .Where(url => url.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) || url.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                                                 .ToArray();

                        result.Add(new ApiData
                        {
                            ProductCode = reader["MAINCODE"]?.ToString(),
                            GTIN = reader["BARCODE"]?.ToString(),
                            Title = reader["name"]?.ToString(),
                            Description = reader["DESCRIPTION"]?.ToString(),
                            Brand = reader["SPECODE"]?.ToString(),
                            ProductUrl = info,
                            ImageUrls = imageUrls.ToList(),
                            Categories = reader["SPECODE4"]?.ToString()?.Split('~', StringSplitOptions.RemoveEmptyEntries).ToList() ?? new List<string>(),
                            Price = reader["CMIMI_SH"] != DBNull.Value ? Convert.ToDecimal(reader["CMIMI_SH"]) : 0,
                            OldPrice = decimal.TryParse(reader["OLD_PRICE"]?.ToString(), out var oldPrice) ? oldPrice : 0,
                            StoreStockQuantity = reader["SASIA"] != DBNull.Value ? Convert.ToInt32(reader["SASIA"]) : 0,
                            StoreSupplierQuantity = 0,
                            Specifications = new List<Specification>
                            {
                                new Specification{
                                 Name = "Madhesia",
                                Value = !string.IsNullOrEmpty(reader["MAINCODE"].ToString()) && reader["MAINCODE"].ToString().Length >= 2 ? reader["MAINCODE"].ToString().Substring(reader["MAINCODE"].ToString().Length - 2): "00",},
                            },
                            Variants = new List<VariantApi>
                    {
                        new VariantApi
                        {
                            ProductCode = reader["MAINCODE"]?.ToString(),
                            GTIN = reader["BARCODE"]?.ToString(),
                            Title = reader["name"]?.ToString(),
                            Description = reader["DESCRIPTION"]?.ToString(),
                            Brand = reader["SPECODE"]?.ToString(),
                            ProductUrl = info,
                            ImageUrls = new List<string>(),
                            Categories = reader["SPECODE4"]?.ToString()?.Split('~', StringSplitOptions.RemoveEmptyEntries).ToList() ?? new List<string>(),
                            Price = reader["CMIMI_SH"] != DBNull.Value ? Convert.ToDecimal(reader["CMIMI_SH"]) : 0,
                            OldPrice = decimal.TryParse(reader["OLD_PRICE"]?.ToString(), out var oldPrice1) ? oldPrice1 : 0,
                            StoreStockQuantity = reader["SASIA"] != DBNull.Value ? Convert.ToInt32(reader["SASIA"]) : 0,
                            StoreSupplierQuantity = 0,
                            Specifications = new List<Specification>
                            {
                                new Specification{
                                Name = "Madhesia",
                                Value = !string.IsNullOrEmpty(reader["MAINCODE"].ToString()) && reader["MAINCODE"].ToString().Length >= 2 ? reader["MAINCODE"].ToString().Substring(reader["MAINCODE"].ToString().Length - 2): "00",},
                            },
                        }
                    }
                        });
                    }

                    articles = result;

                    // Set to cache
                    _cache.Set(cacheKey, articles, new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = _cacheExpiration
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error querying SQL: {ex.Message}");
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
