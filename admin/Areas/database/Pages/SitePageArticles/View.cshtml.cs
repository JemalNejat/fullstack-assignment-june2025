using ADMIN.ITEGAMAX._4._0.App_Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.SitePageArticles
{
    public class ViewModel : PageModel
    {
        private readonly ITeGAMAX4Context _db;

        public ViewModel(ITeGAMAX4Context db)
        {
            _db = db;
        }

        [BindProperty]
        public StPageArticle StPageArticle { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var article = await _db.StPageArticles.FindAsync(id);

            if (article == null)
            {
                return NotFound();
            }

            StPageArticle = article;

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var article = await _db.StPageArticles.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }

            _db.StPageArticles.Remove(article);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
