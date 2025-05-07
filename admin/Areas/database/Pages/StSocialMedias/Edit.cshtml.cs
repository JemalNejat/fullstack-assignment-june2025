using ADMIN.ITEGAMAX._4._0.App_Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.StSocialMedias
{
    public class EditModel : PageModel
    {
        private readonly ITeGAMAX4Context _db;

        public EditModel(ITeGAMAX4Context db)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existingSocialMedia = await _db.StSocialMedias.FirstOrDefaultAsync(s => s.StSocialMediaId == StSocialMedia.StSocialMediaId);
            

            if (existingSocialMedia == null)
            {
                return NotFound();
            }

            existingSocialMedia.StSocialMediaName = StSocialMedia.StSocialMediaName;
            existingSocialMedia.StSocialMediaShort = StSocialMedia.StSocialMediaShort;
            existingSocialMedia.StSocialMediaStatus = StSocialMedia.StSocialMediaStatus;
            existingSocialMedia.Viewcount = existingSocialMedia.Viewcount;
            existingSocialMedia.StSocialMediaUpdateDate = DateTime.Now;

            _db.Update(existingSocialMedia);

            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
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
