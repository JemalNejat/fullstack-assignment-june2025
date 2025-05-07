using ADMIN.ITEGAMAX._4._0.App_Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.FAQAreas
{
    public class IndexModel : PageModel
    {
        private readonly ITeGAMAX4Context _db;

        public IndexModel(ITeGAMAX4Context db)
        {
            _db = db;
        }

        public List<StFaqArea> stfaqareas { get; private set; } = new List<StFaqArea>();
        public int TotalItems { get; set; }

        public async Task OnGetAsync()
        {
            TotalItems = await _db.StFaqAreas.CountAsync();
            stfaqareas = await _db.StFaqAreas.AsNoTracking().ToListAsync();
        }

        public async Task<IActionResult> OnPostInactivateAsync(int id)
        {
            var stfaqarea = await _db.StFaqAreas.FindAsync(id);
            if (stfaqarea == null)
            {
                return NotFound();
            }

            stfaqarea.StFaqAreaStatus = 1; // Inaktiverad status
            _db.Attach(stfaqarea).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception($"Site FAQ Area {id} not found!");
            }

            return RedirectToPage();
        }
    }
}

