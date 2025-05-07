using ADMIN.ITEGAMAX._4._0.App_Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.SiteFaqQuestions
{
	public class ViewModel : PageModel
	{
		private readonly ITeGAMAX4Context _db;

		public ViewModel(ITeGAMAX4Context db)
		{
			_db = db;
		}
		[BindProperty]
		public StFaqQuestions stFaqQuestions { get; set; }
		public async Task<IActionResult> OnGetAsync(int id)
		{
			var StFaqQuestionId = await _db.StFaqQuestionsProp.FindAsync(id);

			if (StFaqQuestionId == null)
			{
				return NotFound();
			}

			stFaqQuestions = StFaqQuestionId;

			return Page();
		}
	}
}
