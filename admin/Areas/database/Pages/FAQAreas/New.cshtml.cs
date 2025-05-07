using ADMIN.ITEGAMAX._4._0.App_Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.FAQAreas
{
    public class NewModel : PageModel
    {
        private readonly ITeGAMAX4Context _db;

        public NewModel(ITeGAMAX4Context db)
        {
            _db = db;
        }

        [BindProperty]
        public StFaqArea stfaqarea { get; set; }

        public void OnGet()
        {
            // Metoden kan användas för att förbereda sidan om nödvändigt.
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.StFaqAreas.Add(stfaqarea);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
