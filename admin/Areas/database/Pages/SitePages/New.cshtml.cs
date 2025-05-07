using ADMIN.ITEGAMAX._4._0.App_Data;
using ADMIN.ITEGAMAX._4._0.App_Code;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.SitePages
{
    public class NewModel : PageModel
    {
        private readonly ITeGAMAX4Context _db;

        [BindProperty]
        public StPage NewPage { get; set; } = new StPage();

        public NewModel(ITeGAMAX4Context db)
        {
            _db = db;
        }

        public void OnGet()
        {
            // Nothing needed here, just load the form.
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.StPages.Add(NewPage);
            await _db.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
