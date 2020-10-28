using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCore_Mentoring.BLL.Models;
using NetCore_Mentoring.BLL.Services.Interfaces;

namespace NetCore_Mentoring.API.Controllers
{
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService productService;

        public ProductsController(
            ILogger<ProductsController> logger,
            IProductService productService)
        {
            _logger = logger;
            this.productService = productService;
        }

        [HttpGet]
        public IActionResult GetProducts(int count = 0)
        {
            var products = productService.Get(count);

            return View(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute]int id)
        {
            var product = productService.GetById(id);

            return View("EditProduct", product);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPut("{id}")]
        public IActionResult EditProduct(
            [FromRoute] int id, 
            [FromBody] Product product)
        {


            return View();
        }
    }
}
