using ADMIN.ITEGAMAX._4._0.App_Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.SiteContactAreas
{
    public class NewModel : PageModel
    {
        private readonly ITeGAMAX4Context _db;

        public NewModel(ITeGAMAX4Context db)
        {
            _db = db;
        }

        [BindProperty]
        public StContactArea StContactArea { get; set; }

        public void OnGet()
        {
            // Ensure StContactArea is initialized if this is the first page load
            if (StContactArea == null)
            {
                StContactArea = new StContactArea();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            StContactArea.StUpdatedDate = DateTime.Now;

            if (StContactArea.StCreatedDate == null)
            {
                StContactArea.StCreatedDate = DateTime.Now;
            }

            _db.StContactAreas.Add(StContactArea);

            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}