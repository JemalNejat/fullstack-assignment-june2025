using ADMIN.ITEGAMAX._4._0.App_Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.StContactIssues
{
    public class NewModel : PageModel
    {
        private readonly ITeGAMAX4Context _db;

        public NewModel(ITeGAMAX4Context db)
        {
            _db = db;
        }

        [BindProperty]
        public StContactIssue StContactIssue { get; set; } = new StContactIssue();

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            

            StContactIssue.StCtIssueUpdateddate = DateTime.Now;
            // Set default timestamp if not provided
            if (StContactIssue.StCtIssueCreateddate == null)
            {
                StContactIssue.StCtIssueCreateddate = DateTime.Now;
            }

            _db.StContactIssues.Add(StContactIssue);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}

