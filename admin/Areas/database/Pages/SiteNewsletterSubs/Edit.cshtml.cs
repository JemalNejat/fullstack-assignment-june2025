using ADMIN.ITEGAMAX._4._0.App_Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.SiteNewsletterSubs
{

	public class EditModel : PageModel
	{
		private readonly ITeGAMAX4Context _db;

		public EditModel(ITeGAMAX4Context db)
		{
			_db = db;
		}
		[BindProperty]
		public StNewsletterSubscriber? stnewslettersubscriber { get; set; }

		public async Task<IActionResult> OnGetAsync(int id)
		{
			stnewslettersubscriber = await _db.StNewsletterSubscribers.FindAsync(id);

			if (stnewslettersubscriber == null)
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

			_db.Attach(stnewslettersubscriber!).State = EntityState.Modified;

			try
			{
				await _db.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				throw new Exception($"Newsletter subscriber {stnewslettersubscriber!.StNlSubscribersId} not found!");
			}

			return RedirectToPage("Index");
		}

	}

}
