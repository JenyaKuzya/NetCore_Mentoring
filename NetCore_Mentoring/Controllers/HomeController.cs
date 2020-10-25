using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCore_Mentoring.BLL.Services.Interfaces;
using NetCore_Mentoring.Models;

namespace NetCore_Mentoring.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;

        public HomeController(
            ILogger<HomeController> logger, 
            ICategoryService categoryService,
            IProductService productService)
        {
            _logger = logger;
            this.categoryService = categoryService;
            this.productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("categories")]
        public IActionResult Categories()
        {
            var categories = categoryService.GetAll();

            return View(categories);
        }

        [HttpGet("products")]
        public IActionResult Products()
        {
            var products = productService.GetAll();

            return View(products);
        }

        [HttpGet("contacts")]
        public IActionResult Contacts()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
