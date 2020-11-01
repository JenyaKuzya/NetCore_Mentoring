using NetCore_Mentoring.BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCore_Mentoring.BLL.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryModel>> GetAsync();

        Task<CategoryModel> GetByIdAsync(int categoryId);

        Task CreateAsync(CategoryModel category);

        Task EditAsync(CategoryModel category);

        Task DeleteAsync(CategoryModel category);
    }
}
