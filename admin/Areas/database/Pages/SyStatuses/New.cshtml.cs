using ADMIN.ITEGAMAX._4._0.App_Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.SyStatuses
{
    public class NewModel : PageModel
    {
        private readonly ITeGAMAX4Context _db;

        public NewModel(ITeGAMAX4Context db)
        {
            _db = db;
        }

        [BindProperty]
        public SyStatus SyStatus { get; set; }

        public void OnGet()
        {
            SyStatus = new SyStatus
            {
                SyCreatedDate = DateTime.Now,
                SyUpdateDate = DateTime.Now,
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.SyStatuses.Add(SyStatus);

            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
