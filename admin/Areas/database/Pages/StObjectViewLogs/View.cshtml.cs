using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ADMIN.ITEGAMAX._4._0.App_Data;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.StObjectViewLog
{
    public class ViewModel : PageModel
    {
        private readonly ITeGAMAX4Context _db;

        public ViewModel(ITeGAMAX4Context db)
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
    }
}

