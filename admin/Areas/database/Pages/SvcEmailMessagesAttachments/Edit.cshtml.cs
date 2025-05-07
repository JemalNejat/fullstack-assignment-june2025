using ADMIN.ITEGAMAX._4._0.App_Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.SvcEmailMessagesAttachments
{
    public class EditModel : PageModel
    {
        private readonly ITeGAMAX4Context _db;

        public EditModel(ITeGAMAX4Context db)
        {
            _db = db;
        }

        [BindProperty]
        public EmailAttachment EmailAttachment { get; set; }

        // Load Data for Editing
        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            EmailAttachment = await _db.EmailAttachments.FindAsync(id);

            if (EmailAttachment == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existingAttachment = await _db.EmailAttachments.FindAsync(EmailAttachment.EmssgAttachId);
            if (existingAttachment == null)
            {
                return NotFound();
            }

            // Update fields
            existingAttachment.EmssgId = EmailAttachment.EmssgId;
            existingAttachment.EmssgAttachFileName = EmailAttachment.EmssgAttachFileName;
            existingAttachment.EmssgAttachDownloadUrl = EmailAttachment.EmssgAttachDownloadUrl;
            existingAttachment.EmssgAttachFileType = EmailAttachment.EmssgAttachFileType;
            existingAttachment.EmssgAttachSend = EmailAttachment.EmssgAttachSend;

            // ? Set updated date to current timestamp
            existingAttachment.EmssgAttachUpdatedDate = DateTime.Now;

            await _db.SaveChangesAsync();
            return RedirectToPage("./Index");
        }


        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var attachment = await _db.EmailAttachments.FindAsync(id);

            if (attachment == null)
            {
                return NotFound();
            }

            _db.EmailAttachments.Remove(attachment);
            await _db.SaveChangesAsync();

            return RedirectToPage("./Index"); // Efter radering, gå tillbaka till listan
        }


    }
}
