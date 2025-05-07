using ADMIN.ITEGAMAX._4._0.App_Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.StSocialMedias
{
    public class ViewModel : PageModel
    {
        private readonly ITeGAMAX4Context _db;

        public ViewModel(ITeGAMAX4Context db)
        {
            _db = db;
        }

        [BindProperty]
        public StSocialMedia StSocialMedia { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var SocialNetwork = await _db.StSocialMedias.FindAsync(id);

            if (SocialNetwork == null)
            {
                return NotFound();
            }

            StSocialMedia = SocialNetwork;

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var socialMedia = await _db.StSocialMedias.FindAsync(id);
            if (socialMedia == null)
            {
                return NotFound();
            }

            _db.StSocialMedias.Remove(socialMedia);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
