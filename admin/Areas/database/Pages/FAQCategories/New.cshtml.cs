using ADMIN.ITEGAMAX._4._0.App_Data; // Justera s�kv�gen om det beh�vs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.FAQCategories
{
    public class NewModel : PageModel
    {
        private readonly ITeGAMAX4Context _db;

        public NewModel(ITeGAMAX4Context db)
        {
            _db = db;
        }

        [BindProperty]
        public StFaqCategory StFaqCategory { get; set; }

        public void OnGet()
        {
            // Denna metod kan anv�ndas f�r att f�rbereda sidan om n�dv�ndigt.
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.StFaqCategories.Add(StFaqCategory);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
