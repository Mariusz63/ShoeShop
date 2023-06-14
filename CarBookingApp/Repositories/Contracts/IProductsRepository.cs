using ShoeShopApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShopApp.Repositories.Contracts
{
    public interface IProductsRepository : IGenericRepository<Product>
    {
        Task<Product> GetProductWithDetails(int id);
        Task<List<Product>> GetProductsWithDetails();
    }
}
