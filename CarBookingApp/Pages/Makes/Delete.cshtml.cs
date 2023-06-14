using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShoeShopApp.Data;

namespace ShoeShopApp.Pages.Makes
{
    public class DeleteModel : PageModel
    {
        private readonly ShoeShopApp.Data.ProductShopAppDbContext _context;

        public DeleteModel(ShoeShopApp.Data.ProductShopAppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Make Make { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Make = await _context.Makes.FirstOrDefaultAsync(m => m.Id == id);

            if (Make == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Make = await _context.Makes.FindAsync(id);

            if (Make != null)
            {
                _context.Makes.Remove(Make);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
