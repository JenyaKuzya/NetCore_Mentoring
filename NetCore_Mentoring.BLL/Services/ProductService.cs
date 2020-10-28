using AutoMapper;
using NetCore_Mentoring.BLL.Models;
using NetCore_Mentoring.BLL.Services.Interfaces;
using NetCore_Mentoring.DAL.Entities;
using NetCore_Mentoring.DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCore_Mentoring.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ProductModel>> GetAsync(int count)
        {
            var products = await productRepository.GetAsync(count);

            return mapper.Map<IEnumerable<ProductModel>>(products);
        }

        public async Task<ProductModel> GetByIdAsync(int productId)
        {
            var product = await productRepository.GetByIdAsync(productId);

            return mapper.Map<ProductModel>(product);
        }

        public async Task CreateAsync(ProductModel product)
        {
            var newProduct = mapper.Map<Product>(product);

            await productRepository.CreateAsync(newProduct);
        }

        public async Task EditAsync(ProductModel product)
        {
            var editedProduct = mapper.Map<Product>(product);

            await productRepository.EditAsync(editedProduct);
        }

        public async Task DeleteAsync(ProductModel product)
        {
            var deletedProduct = mapper.Map<Product>(product);

            await productRepository.DeleteAsync(deletedProduct);
        }
    }
}
