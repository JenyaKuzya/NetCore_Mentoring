using NetCore_Mentoring.DAL.Entities;
using NetCore_Mentoring.DAL.EntityFramework;
using NetCore_Mentoring.DAL.Repositories.Interfaces;
using System.Collections.Generic;

namespace NetCore_Mentoring.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShopContext db;

        public CategoryRepository(ShopContext context)
        {
            this.db = context;
        }

        public IEnumerable<Category> GetAll()
        {
            return db.Categories;
        }
    }
}
