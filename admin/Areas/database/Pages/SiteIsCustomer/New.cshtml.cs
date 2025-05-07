using ADMIN.ITEGAMAX._4._0.App_Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.SiteIsCustomer
{
	public class NewModel : PageModel
	{
		private readonly ITeGAMAX4Context _db;

		public NewModel(ITeGAMAX4Context db)
		{
			_db = db;
		}


		[BindProperty]
		public StIsCustomer? stiscustomer { get; set; }


		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			_db.StIsCustomers.Add(stiscustomer!);
			await _db.SaveChangesAsync();
			return RedirectToPage("index");
		}
	}
}