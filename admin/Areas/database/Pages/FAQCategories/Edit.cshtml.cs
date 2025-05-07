using ADMIN.ITEGAMAX._4._0.App_Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.FAQCategories
{
    public class EditModel : PageModel
    {
        private readonly ITeGAMAX4Context _db;

        public EditModel(ITeGAMAX4Context db)
        {
            _db = db;
        }

        [BindProperty]
        public StFaqCategory stfaqcategory { get; set; }

        // Load Data for Editing
        public async Task<IActionResult> OnGetAsync(int id)
        {
            stfaqcategory = await _db.StFaqCategories.FindAsync(id);

            if (stfaqcategory == null)
            {
                return RedirectToPage("./Index"); // Redirect to Index if not found
            }

            return Page(); // Return the page if found
        }

        // Save changes on POST
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Return to page if validation fails
            }

            _db.Attach(stfaqcategory).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync(); // Save changes to the database
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StFaqCategoryExists(stfaqcategory.StFaqCategoryId))
                {
                    return NotFound(); // Return NotFound if the category does not exist
                }
                else
                {
                    throw; // Re-throw if there's a different error
                }
            }

            return RedirectToPage("./Index"); // Redirect to Index after saving
        }

        // Helper method to check if category exists
        private bool StFaqCategoryExists(int id)
        {
            return _db.StFaqCategories.Any(e => e.StFaqCategoryId == id);
        }

        // Optional: Method to handle deletion if needed
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
