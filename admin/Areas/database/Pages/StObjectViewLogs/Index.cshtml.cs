using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ADMIN.ITEGAMAX._4._0.App_Data; // Ensure this namespace matches your actual project structure

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.StObjectViewLog
{
    public class IndexModel : PageModel
    {
        private readonly ITeGAMAX4Context _db;

        public IndexModel(ITeGAMAX4Context db)
        {
            _db = db;
        }

        public List<StObjViewLog> StObjectViewLogs { get; set; } = new List<StObjViewLog>();

        public int TotalItems { get; set; }

        public async Task OnGetAsync()
        {
            // Ensure you have `using Microsoft.EntityFrameworkCore;` for async methods
            TotalItems = await _db.StObjectViewLogs.CountAsync();
            StObjectViewLogs = await _db.StObjectViewLogs.ToListAsync();
        }
    }
}
