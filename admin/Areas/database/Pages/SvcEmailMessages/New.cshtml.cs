using ADMIN.ITEGAMAX._4._0.App_Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Mail;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.SvcEmailMessages
{
    public class NewModel : PageModel
    {
        private readonly ITeGAMAX4Context _db;

        public NewModel(ITeGAMAX4Context db)
        {
            _db = db;
        }

        [BindProperty]
        public SvcEmailMessage SvcEmailMessage { get; set; }

        public void OnGet()
        {
            SvcEmailMessage = new SvcEmailMessage
            {
                SEMsgCreatedDate = DateTime.Now,
                SEMsgUpdatedDate = DateTime.Now,
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            SvcEmailMessage.SEMsgCreatedDate = DateTime.Now;
            SvcEmailMessage.SEMsgUpdatedDate = DateTime.Now;

            _db.SvcEmailMessages.Add(SvcEmailMessage);

            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }

    }
}
