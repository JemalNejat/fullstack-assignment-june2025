using ADMIN.ITEGAMAX._4._0.App_Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.FAQCategories
{
    public class ViewModel : PageModel
    {
        private readonly ITeGAMAX4Context _db;

        public ViewModel(ITeGAMAX4Context db)
        {
            _db = db;
        }

        public StFaqCategory stfaqcategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int id) // Ensure 'id' is of type int
        {
            stfaqcategory = await _db.StFaqCategories.FindAsync(id); // This expects an integer
            if (stfaqcategory == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var category = await _db.StFaqCategories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _db.StFaqCategories.Remove(category);
            await _db.SaveChangesAsync();
            return RedirectToPage("./Index"); // Redirect after deletion
        }
    }
}

