using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HandmadeCity.Data;
using HandmadeCity.Data.Entities;
using HandmadeCity.Services.Interfaces;
using HandmadeCity.ViewModels.Cart;
using HandmadeCity.ViewModels.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace HandmadeCity.Controllers
{
    [Route("[controller]/[action]")]
    public class CartController : Controller
    {
        private readonly HandmadeCityDbContext _dbContext;
        private readonly ICartService _cartService;

        public CartController(HandmadeCityDbContext dbContext,
                              ICartService cartService)
        {
            _dbContext = dbContext;
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            var cartListViewModel = new CartListViewModel();
            var listOfProdIds = _cartService.Get(HttpContext.Session);

            if (listOfProdIds != null)
            {
                var listOfProducts = new List<Product>();

                foreach (var prodId in listOfProdIds)
                {
                    var product = _dbContext.Products.Include(prod=>prod.Category).Include(prod => prod.Reviews).FirstOrDefault(prod => prod.Id == prodId);

                    if (product != null)
                    {
                        cartListViewModel.AddProductviewModel(new ProductViewModel(product, true));
                    }
                }
            }
            return View("Cart", cartListViewModel);
        }

        public IActionResult AddToCart(int productId)
        {
            _cartService.Add(HttpContext.Session, productId);
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult RemoveFromCart(int productId)
        {
            _cartService.Remove(HttpContext.Session, productId);
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
