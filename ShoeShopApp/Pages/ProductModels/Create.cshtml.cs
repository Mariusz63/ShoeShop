using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoeShopApp.Data;

namespace ShoeShopApp.Pages.ProductModels
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
            return Page();
        }

        [BindProperty]
        public ProductModel ProductModel { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ProductModels.Add(ProductModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
