using System;

namespace SITE.ITEGAMAX._4._0._2.Models
{
    public class modProduct
    {
        public int pd_id { get; set; }
        public string? pd_name { get; set; }
        public string? pd_description_short { get; set; }
        public string? pd_description { get; set; }
        public string? pd_text { get; set; }
        public string? pd_type { get; set; }
        public int? pd_group_id { get; set; }
        public int? pd_category_id { get; set; }
        public int? pd_page_id { get; set; }
        public string? pd_created_date { get; set; }
        public string? pd_updated_date { get; set; }
        public int? pd_position { get; set; }
        public int? pd_status { get; set; }
        public int? pd_view_count { get; set; }

        public List<modProductFeature>? productfeatures { get; set; }
    }
}
