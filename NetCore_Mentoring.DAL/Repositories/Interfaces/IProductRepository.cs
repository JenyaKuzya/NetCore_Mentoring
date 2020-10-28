using NetCore_Mentoring.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCore_Mentoring.DAL.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAsync(int count);

        Task<Product> GetByIdAsync(int productId);

        Task CreateAsync(Product product);

        Task EditAsync(Product product);

        Task DeleteAsync(Product product);
    }
}
