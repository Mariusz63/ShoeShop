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
    public class ProductModelsRepository : GenericRepository<ProductModel>, IProductModelsRepository
    {
        private readonly ProductShopAppDbContext _context;

        public ProductModelsRepository(ProductShopAppDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<List<ProductModel>> GetProductModelsByMake(int makeId)
        {
            var models = await _context.ProductModels
                .Where(q => q.MakeId == makeId)
                .ToListAsync();

            return models;
        }


        public Task<ProductModel> GetProductModelWithDetails(int id)
        {
            throw new NotImplementedException();
        }
    }
}
