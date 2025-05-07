using System.ComponentModel.DataAnnotations;

namespace ADMIN.ITEGAMAX._4._0.App_Data
{
    public class SyStatus
    {
        public int id {  get; set; }

        [Required(ErrorMessage = "Detta fält är obligatoriskt.")]
        public string Status { get; set; } = string.Empty;

        public DateTime? SyCreatedDate { get; set; } = DateTime.Now;

        public DateTime? SyUpdateDate { get; set; } = DateTime.Now;

        public int? Viewcount { get; set; } = 0;
    }
}
