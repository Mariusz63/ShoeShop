using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.Intrinsics.X86;
using ShoeShop.Data;

namespace ShoeShop.Pages.Person
{
    public class DisplayAll : PageModel
    {
        private readonly DatabaseContext _ctx;
        public DisplayAll(DatabaseContext ctx)
        {
            _ctx = ctx;
        }
        public IEnumerable<Data.Person> People { get; set; }
        public IActionResult OnGet()
        {
            People = _ctx.Person.ToList();
            return Page();
        }


        // Delete person
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var person = _ctx.Person.Find(id);
            if (person == null)
                return NotFound();
            try
            {
                _ctx.Person.Remove(person);
                _ctx.SaveChanges();
                TempData["success"] = "Deleted successfully";
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error on deleting record";
            }
            return RedirectToPage();
        }
    }
}
