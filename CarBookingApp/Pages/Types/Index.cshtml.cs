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
    public class IndexModel : PageModel
    {
        private readonly ShoeShopApp.Data.ProductShopAppDbContext _context;

        public IndexModel(ShoeShopApp.Data.ProductShopAppDbContext context)
        {
            _context = context;
        }

        public IList<Type> Type { get;set; }

        public async Task OnGetAsync()
        {
            Type = await _context.Type.ToListAsync();
        }
    }
}
