using ADMIN.ITEGAMAX._4._0.App_Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.SiteContactAreas
{
    public class EditModel : PageModel
    {
        private readonly ITeGAMAX4Context _db;

        public EditModel(ITeGAMAX4Context db)
        {
            _db = db;
        }

        [BindProperty]
        public StContactArea StContactArea { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var contactArea = await _db.StContactAreas.FindAsync(id);

            if (contactArea == null)
            {
                return NotFound();
            }

            StContactArea = contactArea;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existingContactArea = await _db.StContactAreas.FirstOrDefaultAsync(s => s.StContactAreaId == StContactArea.StContactAreaId);

            if (existingContactArea == null)
            {
                return NotFound();
            }

            existingContactArea.StContactAreaName = StContactArea.StContactAreaName;
            existingContactArea.StContactAreaStatus = StContactArea.StContactAreaStatus;
            existingContactArea.Position = StContactArea.Position;

            // Preserve the original StCreatedDate if it's already set
            if (!existingContactArea.StCreatedDate.HasValue)
            {
                existingContactArea.StCreatedDate = DateTime.Now; // Only set if it's NULL
            }


            
            existingContactArea.StUpdatedDate = DateTime.Now;

            existingContactArea.Viewcount = StContactArea.Viewcount ?? 0;

            _db.Update(existingContactArea);

            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var area = await _db.StContactAreas.FindAsync(id);
            if (area == null)
            {
                return NotFound();
            }

            _db.StContactAreas.Remove(area);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }

    }
}

