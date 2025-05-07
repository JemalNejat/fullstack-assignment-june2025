using ADMIN.ITEGAMAX._4._0.App_Data;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ADMIN.ITEGAMAX._4._0.Areas.data.Pages
{
    public class data_areasModel : PageModel
    {
        private readonly ITeGAMAX4Context _db;

        public data_areasModel(ITeGAMAX4Context db)
        {
            _db = db;
        }

        public int TotalTables { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var query = "SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = 'itegamax_se'";

            TotalTables = await _db.Database.GetDbConnection().ExecuteScalarAsync<int>(query);

            return Page();
        }

    }
}
