using ADMIN.ITEGAMAX._4._0.App_Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.SiteNewsletterSubs
{
    public class NewModel : PageModel
    {
		private readonly ITeGAMAX4Context _db;

		public NewModel(ITeGAMAX4Context db)
		{
			_db = db;
		}
		[BindProperty]
		public StNewsletterSubscriber? stnewslettersubscriber { get; set; }
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
				{
					Console.WriteLine($"Error: {error.ErrorMessage}");
				}
				return Page();
			}

			_db.StNewsletterSubscribers.Add(stnewslettersubscriber!);
			await _db.SaveChangesAsync();
			return RedirectToPage("index");
		}
	}
}
