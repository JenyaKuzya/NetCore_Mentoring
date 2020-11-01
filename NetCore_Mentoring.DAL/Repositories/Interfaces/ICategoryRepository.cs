using NetCore_Mentoring.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCore_Mentoring.DAL.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAsync();

        Task<Category> GetByIdAsync(int categoryId);

        Task CreateAsync(Category category);

        Task EditAsync(Category category);

        Task DeleteAsync(Category category);
    }
}
