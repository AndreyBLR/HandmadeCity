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
        private readonly string _listOfProductsInCartSessionKey = "ListOfProductsInCart";
        private readonly string _amountOfProductsInCartSessionKey = "AmountOfProductsInCart";
        private readonly HandmadeCityDbContext _dbContext;
        private readonly ICartService _cartService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CartController(HandmadeCityDbContext dbContext,
                              ICartService cartService,
                              UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _cartService = cartService;
            _userManager = userManager;
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

        [Authorize]
        public IActionResult Purchase()
        {
            var activeUser = _userManager.GetUserAsync(User).Result;

            if (activeUser != null)
            {
                var productList = new List<Product>();
                var productIds = _cartService.Get(HttpContext.Session);

                foreach (var productId in productIds)
                {
                    var product = _dbContext.Products.FirstOrDefault(prod => prod.Id == productId);

                    if (product != null)
                    {
                        productList.Add(product);
                    }
                }

                if (productList.Count != 0)
                {
                    var newOrder = new Order
                    {
                        User = activeUser,
                        OrderProducts = new List<OrderProduct>()
                    };

                    _dbContext.Orders.Add(newOrder);

                    foreach (var product in productList)
                    {
                        newOrder.TotalCost += product.Price - product.Price * product.Discount / 100;
                        var orderProduct = new OrderProduct()
                        {
                            Order = newOrder,
                            Product = product
                        };
                        
                        newOrder.OrderProducts.Add(orderProduct);
                    }

                    _dbContext.SaveChanges();

                    return View("Purchase");
                }
            }
            else
            {
                RedirectToAction("Login", "Account");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
