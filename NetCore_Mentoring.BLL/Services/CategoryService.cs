using AutoMapper;
using NetCore_Mentoring.BLL.Models;
using NetCore_Mentoring.BLL.Services.Interfaces;
using NetCore_Mentoring.DAL.Entities;
using NetCore_Mentoring.DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCore_Mentoring.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CategoryModel>> GetAsync()
        {
            var categories = await categoryRepository.GetAsync();

            return mapper.Map<IEnumerable<CategoryModel>>(categories);
        }

        public async Task<CategoryModel> GetByIdAsync(int categoryId)
        {
            var category = await categoryRepository.GetByIdAsync(categoryId);

            return mapper.Map<CategoryModel>(category);
        }

        public async Task CreateAsync(CategoryModel category)
        {
            var newCategory = mapper.Map<Category>(category);

            await categoryRepository.CreateAsync(newCategory);
        }

        public async Task EditAsync(CategoryModel category)
        {
            var editedCategory = mapper.Map<Category>(category);

            await categoryRepository.EditAsync(editedCategory);
        }

        public async Task DeleteAsync(CategoryModel category)
        {
            var deletedCategory = mapper.Map<Category>(category);

            await categoryRepository.DeleteAsync(deletedCategory);
        }
    }
}
