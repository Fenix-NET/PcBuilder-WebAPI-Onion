﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Models;
using Core.Interfaces.Repository;
using Core.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges, CatalogParameters parameters)
        {
            //await FindAll(trackChanges).OrderBy(c => c.Price).ToListAsync();
            var products = await FindAll(trackChanges)
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();
            return products;
        }


        public async Task<Product> GetProductAsync(Guid productId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(productId), trackChanges).SingleOrDefaultAsync();
    }
}
