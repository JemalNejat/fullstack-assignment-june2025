using ADMIN.ITEGAMAX._4._0.App_Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.SiteIsCustomer
{
    public class ViewModel : PageModel
    {
		private readonly ITeGAMAX4Context _db;

		public ViewModel(ITeGAMAX4Context db)
		{
			_db = db;
		}
		[BindProperty]
		public StIsCustomer Customer { get; set; }
		public async Task<IActionResult> OnGetAsync(int id)
		{
			var StCustomer = await _db.StIsCustomers.FindAsync(id);

			if (StCustomer == null)
			{
				return NotFound();
			}

			Customer = StCustomer;

			return Page();
		}
	}
}
