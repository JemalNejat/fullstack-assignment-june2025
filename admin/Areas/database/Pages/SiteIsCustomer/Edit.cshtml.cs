using ADMIN.ITEGAMAX._4._0.App_Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ADMIN.ITEGAMAX._4._0.Areas.database.Pages.SiteIsCustomer
{
    public class EditModel : PageModel
    {
		private readonly ITeGAMAX4Context _context;

		public EditModel(ITeGAMAX4Context context)
		{
			_context = context;
		}
		[BindProperty]
		public StIsCustomer? stiscustomer { get; set; }
		public async Task<IActionResult> OnGetAsync(int id)
		{
			stiscustomer = await _context.StIsCustomers.FindAsync(id);

			if (stiscustomer == null)
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

			_context.Attach(stiscustomer!).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				throw new Exception($"Site Metatag {stiscustomer!.StIsCustomerId} not found!");
			}

			return RedirectToPage("Index");
		}
	}
}
