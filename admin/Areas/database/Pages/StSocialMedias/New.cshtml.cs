using ADMIN.ITEGAMAX._4._0.App_Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.StSocialMedias
{
    public class NewModel : PageModel
    {
        private readonly ITeGAMAX4Context _db;

        public NewModel(ITeGAMAX4Context db)
        {
            _db = db;
        }

        [BindProperty]
        public StSocialMedia StSocialMedia { get; set; }

        public void OnGet()
        {
            StSocialMedia = new StSocialMedia
            {
                StSocialMediaCreatedDate = DateTime.Now,
                StSocialMediaUpdateDate = DateTime.Now,
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.StSocialMedias.Add(StSocialMedia);

            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
