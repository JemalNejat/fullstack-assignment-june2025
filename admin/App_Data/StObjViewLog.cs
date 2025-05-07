using System.ComponentModel.DataAnnotations;

namespace ADMIN.ITEGAMAX._4._0.App_Data
{
    public class StObjViewLog

    {
        public int StObjVlId { get; set; }

        [Required(ErrorMessage = "Detta fält är obligatoriskt.")]
        public int StObjId { get; set; }

        public int StObjType { get; set; }

        public DateTime? StCreateddate { get; set; }

        public DateTime? StUpdateddate { get; set; }
        

        public int? Viewcount { get; set; } = 0;

    }
}
