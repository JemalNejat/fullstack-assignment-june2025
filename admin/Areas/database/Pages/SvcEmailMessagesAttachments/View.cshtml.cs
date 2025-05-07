using System.Threading.Tasks;
using ADMIN.ITEGAMAX._4._0.App_Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.SvcEmailMessagesAttachments
{
    public class ViewModel : PageModel
    {
        private readonly ITeGAMAX4Context _db;

        public ViewModel(ITeGAMAX4Context db)
        {
            _db = db;
        }

        [BindProperty]
        public EmailAttachment EmailAttachment { get; set; } // Bind the EmailAttachment property

        public async Task<IActionResult> OnGetAsync(string id) // Ensure id type matches the expected type
        {
            EmailAttachment = await _db.EmailAttachments.FindAsync(id); // Retrieve the attachment

            if (EmailAttachment == null)
            {
                return NotFound(); // Return 404 if the attachment is not found
            }

            return Page(); // Return the view if found
        }

    }
}
