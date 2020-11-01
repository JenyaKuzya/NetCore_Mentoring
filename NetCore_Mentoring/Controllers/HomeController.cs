using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCore_Mentoring.BLL.Services.Interfaces;
using NetCore_Mentoring.Models;
using System.Diagnostics;

namespace NetCore_Mentoring.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService categoryService;

        public HomeController(
            ILogger<HomeController> logger, 
            ICategoryService categoryService)
        {
            _logger = logger;
            this.categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogInformation("Home page was opened.");
            return View();
        }

        [HttpGet("categories")]
        public IActionResult Categories()
        {
            var categories = categoryService.GetAll();

            return View(categories);
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
