using ADMIN.ITEGAMAX._4._0.App_Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.SvcEmailMessagesAttachments
{
    public class IndexModel : PageModel
    {
        private readonly ITeGAMAX4Context _db;

        public IndexModel(ITeGAMAX4Context db)
        {
            _db = db;
        }

        public List<EmailAttachment> EmailAttachments { get; set; } = new List<EmailAttachment>();

        public int TotalItems { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SearchTerm { get; set; }  // ? Property to hold search term

        public async Task OnGetAsync()
        {
            // Total count of items
            TotalItems = await _db.EmailAttachments.CountAsync();

            // Query for all data
            IQueryable<EmailAttachment> query = _db.EmailAttachments.AsNoTracking();

            // ? FIX: Ensure `EmssgAttachId` is treated as a string
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                query = query.Where(a => a.EmssgAttachId.Contains(SearchTerm) || a.EmssgAttachFileName.Contains(SearchTerm));
            }

            // Fetch filtered records
            EmailAttachments = await query.ToListAsync();
        }
    }
}
