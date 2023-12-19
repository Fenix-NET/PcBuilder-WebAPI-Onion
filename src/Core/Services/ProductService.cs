﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities.Models;
using Core.Interfaces;
using Core.Interfaces.Repository;
using Core.Shared.DataTransferObjects;
using Core.Shared.RequestFeatures;

namespace Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public ProductService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;   
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync(bool trackChanges, int categoryId, CatalogParameters parameters)
        {
            var products = await _repository.Product.GetAllProductsAsync(trackChanges, categoryId, parameters);
            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);
            return productsDto;
        }

        //public async Task<ProductDto> GetProductAsync(Guid Id, bool trackChanges)
        //{
        //    var product = await _repository.Product.GetProductAsync(Id, trackChanges);

        //    var productDto = _mapper.Map<ProductDto>(product);
        //    return productDto;
        //}
    }
}
