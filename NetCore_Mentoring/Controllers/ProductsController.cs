using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NetCore_Mentoring.BLL.Models;
using NetCore_Mentoring.BLL.Services.Interfaces;
using NetCore_Mentoring.DAL.EntityFramework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore_Mentoring.API.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ShopContext _context;
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly ISupplierService supplierService;
        private readonly IConfiguration configuration;

        public ProductsController(
            ShopContext context, 
            IProductService productService,
            ICategoryService categoryService,
            ISupplierService supplierService,
            IConfiguration configuration)
        {
            _context = context;
            this.productService = productService;
            this.categoryService = categoryService;
            this.supplierService = supplierService;
            this.configuration = configuration;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var count = Int32.Parse(configuration["CountOfProducts"]);
            var products = await productService.GetAsync(count);

            return View(products);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await productService.GetByIdAsync(id.Value);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            PopulateCategoriesDropDownList();
            PopulateSuppliersDropDownList();
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,CategoryId,SupplierId,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued")] ProductModel product)
        {
            if (ModelState.IsValid)
            {
                await productService.CreateAsync(product);

                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await productService.GetByIdAsync(id.Value);

            if (product == null)
            {
                return NotFound();
            }

            PopulateCategoriesDropDownList();
            PopulateSuppliersDropDownList();
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id, 
            [Bind("ProductId,ProductName,CategoryId,SupplierId,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued")] ProductModel product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await productService.EditAsync(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await productService.GetByIdAsync(id.Value);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await productService.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            await productService.DeleteAsync(product);

            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }

        private void PopulateCategoriesDropDownList()
        {
            var categories = categoryService.GetAll();

            ViewBag.CategoryId = new SelectList(categories, "CategoryId", "CategoryName");
        }

        private void PopulateSuppliersDropDownList()
        {
            var suppliers = supplierService.GetAll();

            ViewBag.SupplierId = new SelectList(suppliers, "SupplierId", "CompanyName");
        }
    }
}
