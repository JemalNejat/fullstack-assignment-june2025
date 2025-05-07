using ADMIN.ITEGAMAX._4._0.App_Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.SiteContactAreas
{
    public class IndexModel : PageModel
    {
        private readonly ITeGAMAX4Context _db;

        public IndexModel(ITeGAMAX4Context db)
        {
            _db = db;
        }

        public List<StContactArea> StContactAreas  { get; set; } = new List<StContactArea>();
        public int TotalItems { get; set; }

        public async Task OnGetAsync()
        {
            // Hämta totala antal poster
            TotalItems = await _db.StContactAreas.CountAsync();


            // Hämta alla poster från databasen
            StContactAreas = await _db.StContactAreas.ToListAsync();

        }
    }
}
