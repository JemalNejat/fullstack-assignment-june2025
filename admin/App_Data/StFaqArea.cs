namespace ADMIN.ITEGAMAX._4._0.App_Data
{
    public class StFaqArea
    {
        public int StFaqAreaId { get; set; }
        public string StFaqAreaName { get; set; }
        public string? StFaqAreaDescription { get; set; }
        public int? StFaqAreaStatus { get; set; }
        public int? Viewcount { get; set; }

        // Change these to nullable DateTime

        public DateTime? StFaqCreatedDate { get; set; }
        public DateTime? StFaqUpdatedDate { get; set; } = DateTime.Now;

    }
}

