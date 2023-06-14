using ShoeShopApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShopApp.Repositories.Contracts
{
    public interface IProductModelsRepository : IGenericRepository<ProductModel>
    {
        Task<List<ProductModel>> GetProductModelsByMake(int makeId);
        Task<ProductModel> GetProductModelWithDetails(int id);
    }
}
