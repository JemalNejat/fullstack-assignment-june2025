using ADMIN.ITEGAMAX._4._0.App_Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.SyStatuses
{
    public class DeleteModel : PageModel
    {
        private readonly ITeGAMAX4Context _db;

        public DeleteModel(ITeGAMAX4Context db)
        {
            _db = db;
        }

        [BindProperty]
        public SyStatus SyStatus { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            SyStatus = await _db.SyStatuses.FindAsync(id);

            if (SyStatus == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (SyStatus == null)
            {
                return NotFound();
            }

            var statusToDelete = await _db.SyStatuses.FindAsync(SyStatus.id);

            if (statusToDelete == null)
            {
                return NotFound();
            }

            _db.SyStatuses.Remove(statusToDelete);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
