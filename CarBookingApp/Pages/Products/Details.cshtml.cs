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
    public class DetailsModel : PageModel
    {
        private readonly ShoeShopApp.Data.ProductShopAppDbContext _context;

        public DetailsModel(ShoeShopApp.Data.ProductShopAppDbContext context)
        {
            _context = context;
        }

        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Products
                .Include(p => p.Make)
                .Include(p => p.ProductModel)
                .Include(p => p.Type).FirstOrDefaultAsync(m => m.Id == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
