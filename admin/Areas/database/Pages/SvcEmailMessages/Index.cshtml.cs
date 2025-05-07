using ADMIN.ITEGAMAX._4._0.App_Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.SvcEmailMessages
{
    public class IndexModel : PageModel
    {
        private readonly ITeGAMAX4Context _db;

        public IndexModel(ITeGAMAX4Context db)
        {
            _db = db;
        }

        public List<SvcEmailMessage> EmailMessages { get; set; } = new List<SvcEmailMessage>();

        public int TotalItems { get; set; }

        public async Task OnGetAsync()
        {

            // Total count of items
            TotalItems = await _db.SvcEmailMessages.CountAsync();

            // Fetch all data records
            EmailMessages = await _db.SvcEmailMessages.ToListAsync();
        }
    }
}
