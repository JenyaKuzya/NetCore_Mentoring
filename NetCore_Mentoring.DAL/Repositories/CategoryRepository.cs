using Microsoft.EntityFrameworkCore;
using NetCore_Mentoring.DAL.Entities;
using NetCore_Mentoring.DAL.DatabaseContext;
using NetCore_Mentoring.DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCore_Mentoring.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShopContext db;

        public CategoryRepository(ShopContext context)
        {
            this.db = context;
        }

        public async Task<IEnumerable<Category>> GetAsync()
        {
            return await db.Categories.AsNoTracking().ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int categoryId)
        {
            return await db.Categories.AsNoTracking().FirstOrDefaultAsync(
                category => category.CategoryId == categoryId);
        }

        public async Task CreateAsync(Category category)
        {
            db.Add(category);
            await db.SaveChangesAsync();
        }

        public async Task EditAsync(Category category)
        {
            db.Update(category);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Category category)
        {
            db.Categories.Remove(category);
            await db.SaveChangesAsync();
        }
    }
}
