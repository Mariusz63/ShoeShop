using ShoeShopApp.Data;
using ShoeShopApp.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShopApp.Repositories.Repositories
{
    public class ProductsRepository : GenericRepository<Product>, IProductsRepository
    {
        private readonly ProductShopAppDbContext _context;

        public ProductsRepository(ProductShopAppDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<List<Product>> GetProductsWithDetails()
        {
            return await _context.Products
                .Include(q => q.Make)
                .Include(q => q.ProductModel)
                .Include(q => q.Type)
                .ToListAsync();
        }

        public async Task<Product> ProductWithDetails(int id)
        {
            return await _context.Products
                .Include(q => q.Make)
                .Include(q => q.ProductModel)
                .Include(q => q.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public Task<Product> GetProductWithDetails(int id)
        {
            throw new NotImplementedException();
        }
    }
}
