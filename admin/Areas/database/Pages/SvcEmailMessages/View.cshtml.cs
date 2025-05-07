using ADMIN.ITEGAMAX._4._0.App_Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.SvcEmailMessages
{
    public class ViewModel : PageModel
    {
        private readonly ITeGAMAX4Context _db;

        public ViewModel(ITeGAMAX4Context db)
        {
            _db = db;
        }

        [BindProperty]
        public SvcEmailMessage SvcEmailMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            var email = await _db.SvcEmailMessages.FindAsync(id);

            if (email == null)
            {
                return NotFound();
            }

            SvcEmailMessage = email;

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            var existingMessage = await _db.SvcEmailMessages.FindAsync(id);
            if (existingMessage == null)
            {
                return NotFound();
            }

            _db.SvcEmailMessages.Remove(existingMessage);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
