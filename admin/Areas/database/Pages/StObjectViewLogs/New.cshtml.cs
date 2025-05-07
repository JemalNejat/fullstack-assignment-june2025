using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ADMIN.ITEGAMAX._4._0.App_Data;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.StObjectViewLog
{
    public class NewModel : PageModel
    {
        private readonly ITeGAMAX4Context _db;

        public NewModel(ITeGAMAX4Context db)
        {
            _db = db;
        }

        [BindProperty]
        public StObjViewLog StObjectViewLog { get; set; } = new StObjViewLog();

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            StObjectViewLog.StUpdateddate = DateTime.Now;

            // Set default timestamp if not provided
            if (StObjectViewLog.StCreateddate == null)
            {
                StObjectViewLog.StCreateddate = DateTime.Now;
            }

            _db.StObjectViewLogs.Add(StObjectViewLog);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}

