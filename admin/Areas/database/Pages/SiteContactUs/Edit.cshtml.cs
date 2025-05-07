using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ADMIN.ITEGAMAX._4._0.App_Data;
using System.Threading.Tasks;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.StContactIssues
{
    public class EditModel : PageModel
    {
        private readonly ITeGAMAX4Context _db;

        public EditModel(ITeGAMAX4Context db)
        {
            _db = db;
        }

        [BindProperty]
        public StContactIssue StContactIssue { get; set; } = new StContactIssue(); // Ensuring initialization

        public async Task<IActionResult> OnGetAsync(int id)
        {
            StContactIssue = await _db.StContactIssues.FindAsync(id);

            if (StContactIssue == null)
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

            var issueToUpdate = await _db.StContactIssues.FindAsync(StContactIssue.StCtIssueId);
            if (issueToUpdate == null)
            {
                return NotFound();
            }

            // Update only existing fields
            issueToUpdate.StCtIssueCustName = StContactIssue.StCtIssueCustName;
            issueToUpdate.StCtIssueEmail = StContactIssue.StCtIssueEmail;
            issueToUpdate.StCtIssuePhone = StContactIssue.StCtIssuePhone;
            issueToUpdate.StCtIssueSubject = StContactIssue.StCtIssueSubject;
            issueToUpdate.StCtIssueText = StContactIssue.StCtIssueText;
            issueToUpdate.StCtIssueStatus = StContactIssue.StCtIssueStatus;
            issueToUpdate.StCtIssueIscustomer = StContactIssue.StCtIssueIscustomer; // Update customer status
            issueToUpdate.StCtIssueArea = StContactIssue.StCtIssueArea;// Update the area
            issueToUpdate.StCtIssueComfirmEmail = StContactIssue.StCtIssueComfirmEmail;// Update email confirmation status
            issueToUpdate.StCtIssueUpdateddate = System.DateTime.Now;
            issueToUpdate.Viewcount = StContactIssue.Viewcount;

            await _db.SaveChangesAsync();

            return RedirectToPage("./Index");

        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var post = await _db.StContactIssues.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            _db.StContactIssues.Remove(post);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
