using ADMIN.ITEGAMAX._4._0.App_Data;
using ADMIN.ITEGAMAX._4._0.App_Code;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.SitePages
{
    public class ViewModel : PageModel
    {
        private readonly ITeGAMAX4Context _db;

        public ViewModel(ITeGAMAX4Context db)
        {
            _db = db;
        }

        public StPage ViewPage { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            ViewPage = await _db.StPages.FindAsync(id);
            if (ViewPage == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
