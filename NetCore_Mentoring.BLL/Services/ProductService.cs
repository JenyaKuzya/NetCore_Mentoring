using AutoMapper;
using NetCore_Mentoring.BLL.Models;
using NetCore_Mentoring.BLL.Services.Interfaces;
using NetCore_Mentoring.DAL.Repositories.Interfaces;
using System.Collections.Generic;

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

        public IEnumerable<Product> GetAll()
        {
            var products = productRepository.GetAll();

            return mapper.Map<IEnumerable<Product>>(products);
        }
    }
}
