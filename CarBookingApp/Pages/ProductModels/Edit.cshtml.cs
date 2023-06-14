using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoeShopApp.Data;

namespace ShoeShopApp.Pages.ProductModels
{
    public class EditModel : PageModel
    {
        private readonly ShoeShopApp.Data.ProductShopAppDbContext _context;

        public EditModel(ShoeShopApp.Data.ProductShopAppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProductModel ProductModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductModel = await _context.ProductModels
                .Include(p => p.Make).FirstOrDefaultAsync(m => m.Id == id);

            if (ProductModel == null)
            {
                return NotFound();
            }
           ViewData["MakeId"] = new SelectList(_context.Makes, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ProductModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductModelExists(ProductModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProductModelExists(int id)
        {
            return _context.ProductModels.Any(e => e.Id == id);
        }
    }
}
