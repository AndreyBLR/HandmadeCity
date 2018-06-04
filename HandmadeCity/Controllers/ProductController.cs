using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HandmadeCity.Data;
using HandmadeCity.Data.Entities;
using HandmadeCity.Services.Interfaces;
using HandmadeCity.ViewModels.Home;
using HandmadeCity.ViewModels.Product;
using HandmadeCity.ViewModels.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HandmadeCity.Controllers
{
    [Route("[controller]/[action]")]
    public class ProductController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ICartService _cartService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly HandmadeCityDbContext _dbContext;

        public ProductController(IHostingEnvironment hostingEnvironment,
                                 ICartService cartService,
                                 UserManager<ApplicationUser> userManager,
                                 HandmadeCityDbContext dbContext)
        {
            _hostingEnvironment = hostingEnvironment;
            _cartService = cartService;
            _userManager = userManager;
            _dbContext = dbContext;
        }
        
        [HttpGet]
        public IActionResult GetByCategory(int categoryId)
        {
            var prodIdsInCart = _cartService.Get(HttpContext.Session);
            var products = _dbContext.Products.Include(prod => prod.Reviews).Include(prod => prod.Category).ToList();

            var productsViewModel = new ProductsViewModel();

            foreach (var product in products)
            {
                productsViewModel.AddProductviewModel(new ProductCardViewModel(product)
                {
                    IsInCart = prodIdsInCart.Contains(product.Id)
                });  
            }

            return View("Products", productsViewModel);
        }

        [HttpGet]
        public IActionResult GetById(int productId)
        {
            var product = _dbContext.Products.Include(prod => prod.Reviews).ThenInclude(item=>item.User).Include(prod => prod.Category)
                .FirstOrDefault(prod => prod.Id == productId);

            var productViewModel = new ProductViewModel(product);

            return View("Product", productViewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Add()
        {
            var categories = _dbContext.Categories.ToList();
            var productForAddingViewModel = new AddProductViewModel(categories);

            return View("Add", productForAddingViewModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddReview(AddReviewViewModel addReviewViewModel)
        {
            var activeUser = _userManager.GetUserAsync(User).Result;
            var product = _dbContext.Products.Include(prod=>prod.Reviews).FirstOrDefault(prod => prod.Id == addReviewViewModel.ProductId);

            if (product != null)
            {
                var newReview = new Review()
                {
                    Product = product,
                    Rating = addReviewViewModel.Rating,
                    Text = addReviewViewModel.Text,
                    User = activeUser
                };

                _dbContext.Reviews.Add(newReview);
                _dbContext.SaveChanges();
            }

            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddProduct(AddProductViewModel productForAddingViewModel)
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
