using ADMIN.ITEGAMAX._4._0.App_Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.SyStatuses
{
    public class EditModel : PageModel
    {
        private readonly ITeGAMAX4Context _db;

        public EditModel(ITeGAMAX4Context db)
        {
            _db = db;
        }

        [BindProperty]
        public SyStatus SyStatus { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var status = await _db.SyStatuses.FindAsync(id);

            if (status == null)
            {
                return NotFound();
            }

            SyStatus = status;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existingStatus = await _db.SyStatuses.FirstOrDefaultAsync(s => s.id == SyStatus.id);


            if (existingStatus == null)
            {
                return NotFound();
            }

            existingStatus.Status = SyStatus.Status;

            existingStatus.Viewcount = SyStatus.Viewcount;
            existingStatus.SyUpdateDate = DateTime.Now;

            _db.Update(existingStatus);

            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
