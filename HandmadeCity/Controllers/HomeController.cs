using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HandmadeCity.Data;
using HandmadeCity.Data.Entities;
using HandmadeCity.ViewModels;
using HandmadeCity.ViewModels.Home;
using HandmadeCity.ViewModels.Products;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HandmadeCity.Controllers
{
    public class HomeController : Controller
    {
        private readonly HandmadeCityDbContext _dbContext;

        public HomeController(HandmadeCityDbContext dbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;

            //foreach (var applicationUser in userManager.Users)
            //{
            //    userManager.DeleteAsync(applicationUser);
            //}

            //foreach (var role in roleManager.Roles)
            //{
            //    roleManager.DeleteAsync(role);
            //}
                      
            
            _dbContext.SaveChanges();
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel()
            {
                Topics = _dbContext.Topics.Include(topic=> topic.Categories).ToList()
            };

            return View(viewModel);
        }
        
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
