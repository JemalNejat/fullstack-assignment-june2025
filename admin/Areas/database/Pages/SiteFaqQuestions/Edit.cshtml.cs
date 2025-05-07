using ADMIN.ITEGAMAX._4._0.App_Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.SiteFaqQuestions
{
    public class EditModel : PageModel
    {
		private readonly ITeGAMAX4Context _db;

		public EditModel(ITeGAMAX4Context db)
		{
			_db = db;
		}
		[BindProperty]
		public StFaqQuestions? stFaqQuestions { get; set; }

		public async Task<IActionResult> OnGetAsync(int id)
		{
			stFaqQuestions = await _db.StFaqQuestionsProp.FindAsync(id);

			if (stFaqQuestions == null)
			{
				return RedirectToPage("Index");
			}

			return Page();
		}
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			_db.Attach(stFaqQuestions!).State = EntityState.Modified;

			try
			{
				await _db.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				throw new Exception($"St Question Page {stFaqQuestions!.StFaqQuesAnsId} not found!");
			}

			return RedirectToPage("Index");
		}
	}
}
