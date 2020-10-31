using Microsoft.EntityFrameworkCore;
using NetCore_Mentoring.DAL.Entities;
using NetCore_Mentoring.DAL.EntityFramework;
using NetCore_Mentoring.DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore_Mentoring.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopContext db;

        public ProductRepository(ShopContext context)
        {
            this.db = context;
        }

        public async Task<IEnumerable<Product>> GetAsync(int count)
        {
            if (count == 0)
            {
                return await db.Products
                    .Include(p => p.Category)
                    .Include(p => p.Supplier).AsNoTracking().ToListAsync();
            }

            return await db.Products.Take(count)
                .Include(p => p.Category)
                .Include(p => p.Supplier).AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int productId)
        {
            return await db.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier).AsNoTracking().FirstOrDefaultAsync(
                product => product.ProductId == productId);
        }

        public async Task CreateAsync(Product product)
        {
            db.Add(product);
            await db.SaveChangesAsync();
        }

        public async Task EditAsync(Product product)
        {
            db.Update(product);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            db.Products.Remove(product);
            await db.SaveChangesAsync();
        }
    }
}
