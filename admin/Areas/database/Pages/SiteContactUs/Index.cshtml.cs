using ADMIN.ITEGAMAX._4._0.App_Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.StContactIssues
{
    public class IndexModel : PageModel
    {
        private readonly ITeGAMAX4Context _db;

        public IndexModel(ITeGAMAX4Context db)
        {
            _db = db;
        }

        public List<StContactIssue> StContactIssues { get; set; } = new();
        public int TotalItems { get; set; }

        public async Task OnGetAsync()
        {
            TotalItems = await _db.StContactIssues.CountAsync();
            StContactIssues = await _db.StContactIssues.ToListAsync();
        }
    }
}
