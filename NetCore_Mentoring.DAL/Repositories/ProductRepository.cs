using NetCore_Mentoring.DAL.Entities;
using NetCore_Mentoring.DAL.EntityFramework;
using NetCore_Mentoring.DAL.Repositories.Interfaces;
using System.Collections.Generic;

namespace NetCore_Mentoring.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopContext db;

        public ProductRepository(ShopContext context)
        {
            this.db = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Products;
        }
    }
}
