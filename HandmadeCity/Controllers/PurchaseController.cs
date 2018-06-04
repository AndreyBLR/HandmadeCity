using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HandmadeCity.Data;
using HandmadeCity.Data.Entities;
using HandmadeCity.Services.Interfaces;
using HandmadeCity.ViewModels.Purchases;
using HandmadeCity.ViewModels.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace HandmadeCity.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class PurchaseController : Controller
    {
        private readonly HandmadeCityDbContext _dbContext;
        private readonly ICartService _cartService;
        private readonly UserManager<ApplicationUser> _userManager;

        public PurchaseController(HandmadeCityDbContext dbContext,
            ICartService cartService,
            UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _cartService = cartService;
            _userManager = userManager;

            foreach (var applicationUser in _dbContext.Users)
            {
                _userManager.DeleteAsync(applicationUser);
            }
           
        }

        [HttpGet]
        public IActionResult Index()
        {
            var activeUser = _userManager.GetUserAsync(User).Result;

            var purchases = _dbContext.Purchases.Include(item=>item.PurchaseProducts).Where(item=>item.User.Id == activeUser.Id);
            var purchaseHistoryViewModel = new PurchasesViewModel();

            foreach (var purchase in purchases)
            {
                var products = _dbContext.PurchaseProducts
                    .Where(item => item.PurchaseId == purchase.Id)
                    .Include(item => item.Product)
                    .Select(item => item.Product).ToList();

                purchaseHistoryViewModel.AddPurchaseViewModel(new PurchaseCardViewModel(purchase));
            }

            return View("Index", purchaseHistoryViewModel);
        }
        
        public IActionResult Purchase(PurchaseViewModel purchaseViewModel)
        {
            var activeUser = _userManager.GetUserAsync(User).Result;

            var productList = new List<Product>();
            var productIds = _cartService.Get(HttpContext.Session);

            foreach (var productId in productIds)
            {
                var product = _dbContext.Products.Include(prod=>prod.PurchaseProducts).FirstOrDefault(prod => prod.Id == productId);

                if (product != null)
                {
                    productList.Add(product);
                }
            }

            if (productList.Count != 0)
            {
                var purchase = new Purchase
                {
                    User = activeUser,
                    PurchaseProducts = new List<PurchaseProduct>(),
                    DateTime = DateTime.Now
                };

                _dbContext.Purchases.Add(purchase);

                foreach (var product in productList)
                {
                    purchase.TotalCost += product.Price - product.Price * product.Discount / 100;
                    var orderProduct = new PurchaseProduct()
                    {
                        Purchase = purchase,
                        Product = product
                    };

                    purchase.PurchaseProducts.Add(orderProduct);
                    product.PurchaseProducts.Add(orderProduct);
                }

                _dbContext.SaveChanges();
                _cartService.Clear(HttpContext.Session);

                return View("Purchase");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}