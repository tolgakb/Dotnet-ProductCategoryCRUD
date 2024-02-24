using Microsoft.EntityFrameworkCore;
using ProductCategoryManagement.Application.Common.Interfaces;
using ProductCategoryManagement.Domain.Entities;
using ProductCategoryManagement.Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCategoryManagement.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetProductsByCategory(string categoryName)
        {
            var products = await _context.Products.Where(p => p.CategoryName == categoryName).ToListAsync();

            return products;
        }
    }
}
