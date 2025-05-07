namespace ADMIN.ITEGAMAX._4._0.App_Data
{
    public class StFaqCategory
    {
        public int StFaqCategoryId { get; set; }

        public string? StFaqCategoryName { get; set; }

        public string? StFaqCategoryDescription { get; set; }

        public int? StFaqAreaId { get; set; }

        public int? StFaqCategoryStatus { get; set; }

        public int? Viewcount { get; set; }

        public DateTime? StFaqCreatedDate { get; set; } // Nullable
        public DateTime? StFaqUpdatedDate { get; set; } = DateTime.Now;// Inte nullable
    }
}
