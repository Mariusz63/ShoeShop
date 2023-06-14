using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoeShopApp.Data;

namespace ShoeShopApp.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly ShoeShopApp.Data.ProductShopAppDbContext _context;

        public CreateModel(ShoeShopApp.Data.ProductShopAppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["MakeId"] = new SelectList(_context.Makes, "Id", "Id");
        ViewData["ProductModelId"] = new SelectList(_context.ProductModels, "Id", "Id");
        ViewData["TypeId"] = new SelectList(_context.Type, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
