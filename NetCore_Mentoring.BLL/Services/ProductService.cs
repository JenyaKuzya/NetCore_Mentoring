﻿using AutoMapper;
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

        public IEnumerable<Product> Get(int count)
        {
            var products = productRepository.Get(count);

            return mapper.Map<IEnumerable<Product>>(products);
        }

        public Product GetById(int productId)
        {
            var product = productRepository.GetById(productId);

            return mapper.Map<Product>(product);
        }
    }
}
