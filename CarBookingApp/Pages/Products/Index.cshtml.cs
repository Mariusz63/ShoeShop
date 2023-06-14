using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShoeShopApp.Data;

namespace ShoeShopApp.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly ShoeShopApp.Data.ProductShopAppDbContext _context;

        public IndexModel(ShoeShopApp.Data.ProductShopAppDbContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Products
                .Include(p => p.Make)
                .Include(p => p.ProductModel)
                .Include(p => p.Type).ToListAsync();
        }
    }
}
