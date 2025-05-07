using System.ComponentModel.DataAnnotations;

namespace ADMIN.ITEGAMAX._4._0.App_Data
{
    public class StSocialMedia
    {
        public int StSocialMediaId { get; set; }

        [Required(ErrorMessage = "Detta fält är obligatoriskt.")]
        public string StSocialMediaName { get; set; } = null!;

        [Required(ErrorMessage = "Detta fält är obligatoriskt.")]
        public string StSocialMediaShort { get; set; } = null!;

        public int StSocialMediaStatus { get; set; } = 3;

        public DateTime? StSocialMediaCreatedDate { get; set; } = DateTime.Now;

        public DateTime? StSocialMediaUpdateDate { get; set; } = DateTime.Now;

        public int? Viewcount { get; set; } = 0;
    }
}
