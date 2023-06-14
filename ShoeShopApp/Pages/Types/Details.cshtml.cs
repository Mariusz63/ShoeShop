using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShoeShopApp.Data;
using Type = ShoeShopApp.Data.Type;

namespace ShoeShopApp.Pages.Types
{
    public class DetailsModel : PageModel
    {
        private readonly ShoeShopApp.Data.ProductShopAppDbContext _context;

        public DetailsModel(ShoeShopApp.Data.ProductShopAppDbContext context)
        {
            _context = context;
        }

        public Type Type { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Type = await _context.Type.FirstOrDefaultAsync(m => m.Id == id);

            if (Type == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
