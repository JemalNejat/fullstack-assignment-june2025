using ADMIN.ITEGAMAX._4._0.App_Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.SiteMetatags
{
	public class ViewModel : PageModel
	{
		private readonly ITeGAMAX4Context _db;

		public ViewModel(ITeGAMAX4Context db)
		{
			_db = db;
		}
		[BindProperty]
		public StMetatag stmetatag { get; set; }
		public async Task<IActionResult> OnGetAsync(int id)
		{
			var StMetatagById = await _db.StMetatags.FindAsync(id);

			if (StMetatagById == null)
			{
				return NotFound();
			}

			stmetatag = StMetatagById;

			return Page();
		}
	}
}
