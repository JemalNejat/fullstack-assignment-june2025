using ADMIN.ITEGAMAX._4._0.App_Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.SvcEmailMessages
{
    public class EditModel : PageModel
    {

        private readonly ITeGAMAX4Context _db;

        public EditModel(ITeGAMAX4Context db)
        {
            _db = db;
        }

        [BindProperty]
        public SvcEmailMessage SvcEmailMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            var email = await _db.SvcEmailMessages.FindAsync(id);

            if (email == null)
            {
                return NotFound();
            }

            SvcEmailMessage = email;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existingMessage = await _db.SvcEmailMessages.FirstOrDefaultAsync(m => m.SEMsgId == SvcEmailMessage.SEMsgId);

            if (existingMessage == null)
            {
                return NotFound();
            }

            existingMessage.SEMsgFrom = SvcEmailMessage.SEMsgFrom;
            existingMessage.SEMsgFromName = SvcEmailMessage.SEMsgFromName;
            existingMessage.SEMsgTo = SvcEmailMessage.SEMsgTo;
            existingMessage.SEMsgToName = SvcEmailMessage.SEMsgToName;
            existingMessage.SEMsgReplyTo = SvcEmailMessage.SEMsgReplyTo;
            existingMessage.SEMsgSubject = SvcEmailMessage.SEMsgSubject;
            existingMessage.SEMsgBodyHtml = SvcEmailMessage.SEMsgBodyHtml;

            existingMessage.SEMsgIsHtml = SvcEmailMessage.SEMsgIsHtml;
            existingMessage.SEMsgHasAttachments = SvcEmailMessage.SEMsgHasAttachments;

            existingMessage.SEMsgSystem = SvcEmailMessage.SEMsgSystem;
            existingMessage.SEMsgStatus = SvcEmailMessage.SEMsgStatus;
            existingMessage.SEMsgSentDate = SvcEmailMessage.SEMsgSentDate;
            existingMessage.Viewcount = SvcEmailMessage.Viewcount;
            existingMessage.SEMsgUpdatedDate = DateTime.Now;

            _db.Update(existingMessage);

            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }

        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            var existingMessage = await _db.SvcEmailMessages.FindAsync(id);
            if (existingMessage == null)
            {
                return NotFound();
            }

            _db.SvcEmailMessages.Remove(existingMessage);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
