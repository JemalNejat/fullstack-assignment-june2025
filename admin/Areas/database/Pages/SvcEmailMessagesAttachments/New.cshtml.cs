using ADMIN.ITEGAMAX._4._0.App_Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.SvcEmailMessagesAttachments
{
    public class NewModel : PageModel
    {
        private readonly ITeGAMAX4Context _db;

        public NewModel(ITeGAMAX4Context db)
        {
            _db = db;
        }

        [BindProperty]
        public EmailAttachment EmailAttachment { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            // Lägg till den nya bilagan i databasen
            await _db.EmailAttachments.AddAsync(EmailAttachment);
            await _db.SaveChangesAsync();

            // Omdirigera till indexsidan efter framgång
            return RedirectToPage("Index");
        }
    }
}
