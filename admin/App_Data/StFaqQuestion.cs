namespace ADMIN.ITEGAMAX._4._0.App_Data
{
	public partial class StFaqQuestions
	{
		public int StFaqQuesAnsId { get; set; }  // Auto increment, primary key
		public string? StFaqQuestion { get; set; }  // Nullable field
		public string? StFaqAnswer { get; set; }  // Nullable field
		public int? StFaqCategoryid { get; set; }  // Nullable field, default value 0
		public int? StFaqQuesAnsStatus { get; set; }  // Nullable field, default value 3
		public DateTime? StFaqQuesAnsCreateddate { get; set; }  // Nullable field
		public DateTime? StFaqQuesAnsUpdateddate { get; set; }  // Nullable field, default value current_timestamp()
		public int? Viewcount { get; set; }
	}
}
