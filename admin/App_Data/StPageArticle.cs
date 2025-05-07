using System.ComponentModel.DataAnnotations;

namespace ADMIN.ITEGAMAX._4._0.App_Data
{
    public class StPageArticle
    {
        public int StArticleId { get; set; }

        public string? Articletitle { get; set; }

        public string? Articlesubtitle { get; set; }

        public string? Articletext { get; set; }

        [Required(ErrorMessage = "Detta fält är obligatoriskt.")]
        public int StPageId { get; set; } = 0;

        public DateTime? Articlecreateddate { get; set; }

        public DateTime Articleupdatedate { get; set; }

        public int ArticlestStatus { get; set; } = 2;

        public string? ArticlePicture { get; set; }

        public string? ArticlePictureAlign { get; set; }

        public string? ArticlePictureLinktitle { get; set; }

        public string? ArticlePictureLinkurl { get; set; }

        public string? ArticlePictureLinktarget { get; set; }

        [Required(ErrorMessage = "Detta fält är obligatoriskt.")]
        public int ArticlePosition { get; set; } = 1;

        public int? Viewcount { get; set; } = 0;
    }
}
