using ADMIN.ITEGAMAX._4._0.App_Data;
using ADMIN.ITEGAMAX._4._0.App_Code;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.SiteFaqQuestions
{
    public class IndexModel : PageModel
    {
		private readonly ITeGAMAX4Context _db;

		public IndexModel(ITeGAMAX4Context db)
		{
			_db = db;
		}
		public List<StFaqQuestions> AllPages { get; set; }

		public int TotalItems { get; set; }

		public async Task OnGetAsync()
		{
			TotalItems = await _db.StFaqQuestionsProp.CountAsync();
			AllPages = await _db.StFaqQuestionsProp.ToListAsync();
		}
	}
}
