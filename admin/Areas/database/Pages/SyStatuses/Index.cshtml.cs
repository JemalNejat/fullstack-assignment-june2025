using ADMIN.ITEGAMAX._4._0.App_Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.SyStatuses
{
    public class IndexModel : PageModel
    {
        private readonly ITeGAMAX4Context _db;

        public IndexModel(ITeGAMAX4Context db)
        {
            _db = db;
        }

        public List<SyStatus> SyStatuses { get; set; } = new List<SyStatus>();

        public int TotalItems { get; set; }

        public async Task OnGetAsync()
        {

            // Total count of items
            TotalItems = await _db.SyStatuses.CountAsync();

            // Fetch all data records
            SyStatuses = await _db.SyStatuses.ToListAsync();
        }
    }
}
