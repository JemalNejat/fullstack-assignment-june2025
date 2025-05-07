using ADMIN.ITEGAMAX._4._0.App_Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.SiteMetatags
{
    public class NewModel : PageModel
    {
		private readonly ITeGAMAX4Context _db;

		public NewModel(ITeGAMAX4Context db)
		{
			_db = db;
		}


		[BindProperty]
		public StMetatag? stmetatag { get; set; }


		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			_db.StMetatags.Add(stmetatag!);
			await _db.SaveChangesAsync();
			return RedirectToPage("index");
		}
	}
}
