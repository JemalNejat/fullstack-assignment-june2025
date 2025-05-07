using ADMIN.ITEGAMAX._4._0.App_Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.FAQAreas
{
    public class EditModel : PageModel
    {
        private readonly ITeGAMAX4Context _db;

        public EditModel(ITeGAMAX4Context db)
        {
            _db = db;
        }

        [BindProperty]
        public StFaqArea stfaqarea { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            stfaqarea = await _db.StFaqAreas.FindAsync(id);

            if (stfaqarea == null)
            {
                return RedirectToPage("Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Attach(stfaqarea!).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception($"Site FAQ Area {stfaqarea!.StFaqAreaId} not found!");
            }

            return RedirectToPage("Index");
        }

     
        public async Task<IActionResult> OnPostDeleteAsync(int id) // Changed to int
        {
            if (id == 0) // Check for valid ID
            {
                return NotFound();
            }

            var areaToDelete = await _db.StFaqAreas.FindAsync(id); // Retrieve the specific FAQ area

            if (areaToDelete == null)
            {
                return NotFound();
            }

            _db.StFaqAreas.Remove(areaToDelete); // Correctly refer to the StFaqAreas set
            await _db.SaveChangesAsync();

            return RedirectToPage("Index"); // After deletion, redirect back to the list
        }
    }
}
