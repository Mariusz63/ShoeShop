using ShoeShopApp.Data.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ShoeShopApp.Data
{
    public class ProductShopAppDbContext : IdentityDbContext<ApplicationUser>
    {
        public ProductShopAppDbContext(DbContextOptions<ProductShopAppDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<ProductModel> ProductModels { get; set; }
        public DbSet<Type> Type { get; set; }
    }
}
