using NetCore_Mentoring.BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCore_Mentoring.BLL.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetAsync(int count);

        Task<ProductModel> GetByIdAsync(int productId);

        Task CreateAsync(ProductModel product);

        Task EditAsync(ProductModel product);

        Task DeleteAsync(ProductModel product);
    }
}
