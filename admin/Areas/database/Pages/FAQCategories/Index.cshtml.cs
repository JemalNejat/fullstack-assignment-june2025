using ADMIN.ITEGAMAX._4._0.App_Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.FAQCategories
{
    public class IndexModel : PageModel
    {
        private readonly ITeGAMAX4Context _db;

        public IndexModel(ITeGAMAX4Context db)
        {
            _db = db;
        }

        public List<StFaqCategory> stfaqcategories { get; private set; } = new List<StFaqCategory>();
        public int TotalItems { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SearchTerm { get; set; }  // Property to hold search term

        public int CurrentPage { get; set; } = 1; // Standard till första sidan
        public int PageSize { get; set; } = 10; // Antal objekt per sida

        public async Task OnGetAsync(int page = 1)
        {
            CurrentPage = page;

            IQueryable<StFaqCategory> query = _db.StFaqCategories.AsNoTracking();

            // Filtrera baserat på sökterm
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                query = query.Where(f => f.StFaqCategoryName.Contains(SearchTerm) ||
                                         f.StFaqCategoryDescription.Contains(SearchTerm));
            }

            TotalItems = await query.CountAsync(); // Räkna totalt antal objekt
            stfaqcategories = await query
                .Skip((CurrentPage - 1) * PageSize) // Hoppa över tidigare sidor
                .Take(PageSize) // Ta endast ett visst antal objekt
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostInactivateAsync(int id)
        {
            var stfaqcategory = await _db.StFaqCategories.FindAsync(id);
            if (stfaqcategory == null)
            {
                return NotFound();
            }

            stfaqcategory.StFaqCategoryStatus = 1; // Inaktiverad status
            _db.Attach(stfaqcategory).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
                // Här kan du lägga till en meddelandeflagga för att informera användaren
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception($"FAQ Category {id} not found!");
            }

            return RedirectToPage(); // Återgå till samma sida efter inaktivering
        }
    }
}
