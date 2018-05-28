using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HandmadeCity.Data;
using HandmadeCity.Data.Entities;
using HandmadeCity.Services.Interfaces;
using HandmadeCity.ViewModels.Home;
using HandmadeCity.ViewModels.Products;
using HandmadeCity.ViewModels.Shared;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HandmadeCity.Controllers
{
    [Route("[controller]/[action]")]
    public class ProductsController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ICartService _cartService;
        private readonly HandmadeCityDbContext _dbContext;

        public ProductsController(IHostingEnvironment hostingEnvironment,
                                  ICartService cartService,
                                  HandmadeCityDbContext dbContext)
        {
            _hostingEnvironment = hostingEnvironment;
            _cartService = cartService;
            _dbContext = dbContext;
        }
        
        [HttpGet]
        public IActionResult GetByCategory(int categoryId)
        {
            var prodIdsInCart = _cartService.Get(HttpContext.Session);
            var products = _dbContext.Products.Include(prod => prod.Reviews).Include(prod => prod.Category).ToList();

            var productListViewModel = new ProductListViewModel();

            foreach (var product in products)
            {
                productListViewModel.AddProductviewModel(new ProductViewModel(product, prodIdsInCart.Contains(product.Id)));  
            }

            return View("Products", productListViewModel);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            var categories = _dbContext.Categories.ToList();
            var productForAddingViewModel = new ProductForAddingViewModel(categories);

            return View("AddProduct", productForAddingViewModel);
        }
        
        [HttpPost]
        public IActionResult AddProduct(ProductForAddingViewModel productForAddingViewModel)
        {
            var pictureUrl = SaveImageToContentFolder(productForAddingViewModel.Image);
            var category = _dbContext.Categories.FirstOrDefault(item => item.Id == productForAddingViewModel.SelectedCategoryId);

            var newProduct = new Product()
            {
                Name = productForAddingViewModel.Name,
                Description = productForAddingViewModel.Description,
                Discount = productForAddingViewModel.Discount,
                Price = productForAddingViewModel.Price,
                PictureUrl = pictureUrl,
                TotalRating = 0,
                Category = category

            };

            _dbContext.Products.Add(newProduct);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        private string SaveImageToContentFolder(IFormFile formFile)
        {
            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", "products", formFile.FileName);

            using (var stream = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                formFile.CopyTo(stream);
            }

            return $"/images/products/{formFile.FileName}";
        }
    }
}
