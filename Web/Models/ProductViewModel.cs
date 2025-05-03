using Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models.ImageVM;
using Web.Models.SettingsVM;
using X.PagedList;

namespace OA_Web.Models
{
    public class IndexProductViewModel
    {
        public IPagedList<ApiData> Products { get; set; }
        public List<ApiCategoryViewModel> Categories { get; set; }
        public List<SizeViewModel> Sizes { get; set; }
    }
    public class Index4ProductDetailsViewModel
    {
        public List<ProductViewModel> Products { get; set; }
        public ProductViewModel Product { get; set; }
    }
    public class Index4ApiProd
    {
        public List<ApiData> Products { get; set; }
        public ApiData Product { get; set; }
    }
    public class ApiProdDetails
    {

        public string ProductCode { get; set; }
        public string GTIN { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string ProductUrl { get; set; }
        public List<string> ImageUrls { get; set; }
        public List<string> Categories { get; set; } // Now a list of strings
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public int StoreStockQuantity { get; set; }
        public int StoreSupplierQuantity { get; set; }
        public List<Specification> Specifications { get; set; }
        public List<VariantApi> Variants { get; set; }
    }

    public class Index4CreateProductViewModel
    {
        public List<CategoryViewModel> Categories { get; set; }
        public List<SizeViewModel> Sizes { get; set; }
        public List<ColorViewModel> Colors { get; set; }
        public List<ImageViewModel> Images { get; set; }
    }
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string ProductCode { get; set; }
        public string GTIN { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string ProductUrl { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public int Quantity { get; set; }

        //public virtual List<CategoryViewModel> Categories { get; set; }
        public virtual List<ProductSizeViewModel> Sizes { get; set; }
        public virtual List<ProductColorViewModel> Colors { get; set; }
        public virtual List<ProductCategoryViewModel> Categories { get; set; }
        public virtual List<ImageViewModel> Images { get; set; }
    }
    public class CreateProductViewModel
    {
        public List<int> _ColorIds { get; set; }
        public List<int> _SizeIds { get; set; }
        public List<int> _CategoryIds { get; set; }
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string ProductCode { get; set; }
        public string GTIN { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string ProductUrl { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public int Quantity { get; set; }

        public List<IFormFile> File { get; set; }
    }

    public class ProductColorViewModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public int ColorId { get; set; }
        public string ColorName { get; set; }

    }
    public class ProductSizeViewModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public int SizeId { get; set; }

        public string SizeNr { get; set; }
    }
    public class ProductCategoryViewModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }

}
