using Microsoft.EntityFrameworkCore;
using NetCore_Mentoring.DAL.Entities;
using NetCore_Mentoring.DAL.EntityFramework;
using NetCore_Mentoring.DAL.Repositories.Interfaces;
using System.Collections.Generic;

namespace NetCore_Mentoring.DAL.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ShopContext db;

        public SupplierRepository(ShopContext context)
        {
            this.db = context;
        }

        public IEnumerable<Supplier> GetAll()
        {
            return db.Suppliers.AsNoTracking();
        }
    }
}