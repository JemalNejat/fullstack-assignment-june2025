using ADMIN.ITEGAMAX._4._0.App_Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.SiteMetatags
{
	public class EditModel : PageModel
	{
		private readonly ITeGAMAX4Context _context;

		public EditModel(ITeGAMAX4Context context)
		{
			_context = context;
		}
		[BindProperty]
		public StMetatag? stmetatag { get; set; }
		public async Task<IActionResult> OnGetAsync(int id)
		{
			stmetatag = await _context.StMetatags.FindAsync(id);

			if (stmetatag == null)
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

			_context.Attach(stmetatag!).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				throw new Exception($"Site Metatag {stmetatag!.StMetatagid} not found!");
			}

			return RedirectToPage("Index");
		}
	}
}
