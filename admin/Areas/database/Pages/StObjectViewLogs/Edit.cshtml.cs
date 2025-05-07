using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ADMIN.ITEGAMAX._4._0.App_Data;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.StObjectViewLog
{
    public class EditModel : PageModel
    {
        private readonly ITeGAMAX4Context _db;

        public EditModel(ITeGAMAX4Context db)
        {
            _db = db;
        }

        [BindProperty]
        public StObjViewLog StObjectViewLog { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var logEntry = await _db.StObjectViewLogs.FindAsync(id);

            if (logEntry == null)
            {
                return NotFound();
            }

            StObjectViewLog = logEntry;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existingLogEntry = await _db.StObjectViewLogs.FirstOrDefaultAsync(s => s.StObjVlId == StObjectViewLog.StObjVlId);

            if (existingLogEntry == null)
            {
                return NotFound();
            }

            existingLogEntry.StObjId = StObjectViewLog.StObjId;
            existingLogEntry.StObjType = StObjectViewLog.StObjType;
            existingLogEntry.StCreateddate = StObjectViewLog.StCreateddate;
            existingLogEntry.StUpdateddate = DateTime.Now;
            existingLogEntry.Viewcount = StObjectViewLog.Viewcount;

           

            _db.Update(existingLogEntry);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var objekt = await _db.StObjectViewLogs.FindAsync(id);
            if (objekt == null)
            {
                return NotFound();
            }

            _db.StObjectViewLogs.Remove(objekt);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
