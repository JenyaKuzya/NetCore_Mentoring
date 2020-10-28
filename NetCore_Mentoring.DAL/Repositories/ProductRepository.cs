using NetCore_Mentoring.DAL.Entities;
using NetCore_Mentoring.DAL.EntityFramework;
using NetCore_Mentoring.DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace NetCore_Mentoring.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopContext db;

        public ProductRepository(ShopContext context)
        {
            this.db = context;
        }

        public IEnumerable<Product> Get(int count)
        {
            if (count == 0)
            {
                return db.Products;
            }

            return db.Products.Take(count);
        }

        public Product GetById(int productId)
        {
            return db.Products.FirstOrDefault(product => product.ProductId == productId);
        }
    }
}
