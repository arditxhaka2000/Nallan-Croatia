using AutoMapper;
using Data;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Documents;
using Services.Orders;
using Services.ProductServ;
using System;
using System.Collections.Generic;
using System.Linq;
using Web.Extensions;
using Web.Models;

namespace Web.Controllers
{
    public class CartController : BaseController
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IApiServices _apiServices;


        public CartController(IProductService productService, IOrderService orderService, IApiServices apiServices)
        {
            _productService = productService;
            _orderService = orderService;
            _apiServices = apiServices;

        }
        public IActionResult Index()
        {
            return RedirectToAction("Checkout");
        }
        public  IActionResult AddToCart(string productId, string variantProductCode, int quantity, string selectedSize)
        {
            // Fetch product details (for example from database)
            var product = _apiServices.GetByIdAsync(productId).Result;
            //var product = _productService.GetById(productId);

            // Get the current cart session
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            // Check if the product is already in the cart
            var cartItem = cart.FirstOrDefault(p => string.Equals(p.ProductId, productId, StringComparison.OrdinalIgnoreCase)
 && p.SelectedSize == selectedSize);
            if (cartItem != null)
            {
                // Increase quantity if product exists
                cartItem.Quantity++;
            }
            else
            {
                // Add new product to the cart
                cart.Add(new CartItem
                {
                    ProductId = productId,
                    ProductName = product.Title,
                    ProductCode = variantProductCode,
                    Price = product.Price,
                    Quantity = quantity,
                    SelectedSize = selectedSize,
                    ImagePath = product?.ImageUrls?.FirstOrDefault(),
                    GTN = product.GTIN
                });
            }

            // Save the cart back to session
            HttpContext.Session.SetObjectAsJson("Cart", cart);

            return Json(new { success = true, cartCount = cart.Sum(item => item.Quantity) });
        }

        public IActionResult GetCartItems()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            return Json(new { cartItems = cart });
        }

        public IActionResult RemoveFromCart(string productId)
        {
            // Get the current cart session
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            // Find the product in the cart
            var cartItem = cart.FirstOrDefault(p => string.Equals(p.ProductId, productId, StringComparison.OrdinalIgnoreCase));

            if (cartItem != null)
            {
                // Remove the product from the cart
                cart.Remove(cartItem);

                // Save the updated cart back to session
                HttpContext.Session.SetObjectAsJson("Cart", cart);
            }

            return Json(new { success = true, cartCount = cart.Sum(item => item.Quantity) });
        }


        public IActionResult Checkout()
        {
            // Get the cart items from the session
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            var checkoutViewModel = new CheckoutViewModel
            {
                CartItems = cart,
                TotalPrice = cart.Sum(item => item.Price * item.Quantity)
            };

            return View(checkoutViewModel);
        }


        public IActionResult Confirmation()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetCartItemCount()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            int count = cart.Sum(item => item.Quantity);
            return new JsonResult(new { count = count });

        }

    }

}
