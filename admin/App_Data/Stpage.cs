namespace ADMIN.ITEGAMAX._4._0.App_Data
{
	public partial class StPage
	{
		public int PageId { get; set; }

		public string Pageurlid { get; set; } = null!;

		public string Pagetitle { get; set; } = null!;

		public string? Pagesubtitle { get; set; }

		public string? Pageshortdescription { get; set; }

		public string? Pagelayoutname { get; set; }

		public int Pagecategoryid { get; set; }

		public string? Pagetopbannerpic { get; set; }

		public string? Pagetopbannertitle { get; set; }

		public string? Pagetopbannersubtitle { get; set; }

		public string? Pagetopbannertext { get; set; }

		public string? Pagemediumbannerpic { get; set; }

		public string? Pagemediumbannertitle { get; set; }

		public string? Pagemediumbannersubtitle { get; set; }

		public string? Pagemediumbannertext { get; set; }

		public string? Pagesmallbannerpic { get; set; }

		public string? Pagesmallbannertitle { get; set; }

		public string? Pagesmallbannersubtitle { get; set; }

		public string? Pagesmallbannertext { get; set; }

		public DateTime? Pagecreateddate { get; set; }

		public DateTime Pageupdateddate { get; set; }

		public int Pagetype { get; set; }

		public int Pagestatus { get; set; }

		public int? Viewcount { get; set; }

		public DateTime? Pagemodifieddate { get; set; }

		public int? Pagemenuarea { get; set; }
	}
}
