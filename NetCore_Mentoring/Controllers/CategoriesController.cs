using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NetCore_Mentoring.BLL.Models;
using NetCore_Mentoring.BLL.Services.Interfaces;
using NetCore_Mentoring.DAL.DatabaseContext;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore_Mentoring.API.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ShopContext _context;
        private readonly ILogger<CategoriesController> _logger;
        private readonly ICategoryService categoryService;

        public CategoriesController(
            ShopContext context,
            ILogger<CategoriesController> logger,
            ICategoryService categoryService)
        {
            _context = context;
            _logger = logger;
            this.categoryService = categoryService;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            var categories = await categoryService.GetAsync();

            return View(categories);
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                _logger.LogWarning("Category id wasn't found.");
                return NotFound();
            }

            var category = await categoryService.GetByIdAsync(id.Value);

            if (category == null)
            {
                _logger.LogWarning("Category wasn't found.");
                return NotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName,Description")] CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                await categoryService.CreateAsync(category);

                _logger.LogInformation("New category was created.");
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                _logger.LogWarning("Category id wasn't found.");
                return NotFound();
            }

            var category = await categoryService.GetByIdAsync(id.Value);

            if (category == null)
            {
                _logger.LogWarning("Category wasn't found.");
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,CategoryName,Description")] CategoryModel category)
        {
            if (id != category.CategoryId)
            {
                _logger.LogWarning("Category id wasn't found.");
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await categoryService.EditAsync(category);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.CategoryId))
                    {
                        _logger.LogWarning("Category wasn't found.");
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                _logger.LogInformation("Category was edited.");
                return RedirectToAction(nameof(Index));
            }

            _logger.LogWarning("Category model is not valid.");
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                _logger.LogWarning("Category id wasn't found.");
                return NotFound();
            }

            var category = await categoryService.GetByIdAsync(id.Value);

            if (category == null)
            {
                _logger.LogWarning("Category wasn't found.");
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await categoryService.GetByIdAsync(id);

            if (category == null)
            {
                _logger.LogWarning("Category wasn't found.");
                return NotFound();
            }

            await categoryService.DeleteAsync(category);

            _logger.LogInformation("Category was deleted.");
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.CategoryId == id);
        }
    }
}
