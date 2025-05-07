using ADMIN.ITEGAMAX._4._0.App_Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.StContactIssues
{
    public class ViewModel : PageModel
    {
        private readonly ITeGAMAX4Context _db;

        public ViewModel(ITeGAMAX4Context db)
        {
            _db = db;
        }

        [BindProperty]
        public StContactIssue StContactIssue { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var contactIssue = await _db.StContactIssues.FindAsync(id);

            if (contactIssue == null)
            {
                return NotFound();
            }

            StContactIssue = contactIssue;

            return Page();
        }
    }
}
