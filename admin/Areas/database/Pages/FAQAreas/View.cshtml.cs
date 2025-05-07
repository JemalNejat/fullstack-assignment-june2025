using ADMIN.ITEGAMAX._4._0.App_Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.FAQAreas
{
    public class ViewModel : PageModel
    {
        private readonly ITeGAMAX4Context _db;

        public ViewModel(ITeGAMAX4Context db)
        {
            _db = db;
        }

        [BindProperty]
        public StFaqArea StFaqArea { get; set; }

        public async Task OnGetAsync(int id)
        {
            StFaqArea = await _db.StFaqAreas.FindAsync(id);
        }

        public async Task<IActionResult> OnPostSaveAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Attach(StFaqArea).State = EntityState.Modified;

            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
