using ADMIN.ITEGAMAX._4._0.App_Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.SiteNewsletterSubs
{
	public class ViewModel : PageModel
	{
		private readonly ITeGAMAX4Context _db;

		public ViewModel(ITeGAMAX4Context db)
		{
			_db = db;
		}
		[BindProperty]
		public StNewsletterSubscriber stnewslettersubscriber { get; set; }
		public async Task<IActionResult> OnGetAsync(int id)
		{
			var StNewsLetterById = await _db.StNewsletterSubscribers.FindAsync(id);

			if (StNewsLetterById == null)
			{
				return NotFound();
			}

			stnewslettersubscriber = StNewsLetterById;

			return Page();
		}
	}
}