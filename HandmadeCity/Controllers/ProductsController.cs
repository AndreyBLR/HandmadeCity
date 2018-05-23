using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HandmadeCity.Data;
using HandmadeCity.Data.Entities;
using HandmadeCity.ViewModels.Home;
using HandmadeCity.ViewModels.Products;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HandmadeCity.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly HandmadeCityDbContext _dbContext;

        public ProductsController(IHostingEnvironment hostingEnvironment,
                                 HandmadeCityDbContext dbContext)
        {
            _hostingEnvironment = hostingEnvironment;
            _dbContext = dbContext;
        }
        
        [HttpGet]
        public IActionResult GetByCategory(int categoryId)
        {
            var products = _dbContext.Products.Include(prod => prod.Reviews).Include(prod => prod.Category).ToList();

            var productListViewModel = new ProductListViewModel(products);

            return View("Products", productListViewModel);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var categories = _dbContext.Categories.ToList();
            return View(new ProductForAddingViewModel(categories));
        }

        [HttpPost]
        public IActionResult Add(ProductForAddingViewModel productForAddingViewModel)
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
