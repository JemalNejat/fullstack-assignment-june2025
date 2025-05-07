using ADMIN.ITEGAMAX._4._0.App_Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.SiteContactAreas
{
    public class ViewModel : PageModel
    {
        private readonly ITeGAMAX4Context _db; // Inject database context

        public ViewModel(ITeGAMAX4Context db)
        {
            _db = db;
        }

        [BindProperty]
        public StContactArea? StContactArea { get; set; } // Nullable property to prevent warnings

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid contact area ID.");
            }

            StContactArea = await _db.StContactAreas.FindAsync(id);

            if (StContactArea == null)
            {
                return NotFound(); // Return 404 if not found
            }

            return Page();
        }
    }
}
