namespace ADMIN.ITEGAMAX._4._0.App_Data
{ 
public partial class StContactIssue
{
    public int StCtIssueId { get; set; }

    public int StCtIssueIscustomer { get; set; }

    public int StCtIssueArea { get; set; }

    public string? StCtIssueCustName { get; set; }

    public string? StCtIssueEmail { get; set; }

    public string? StCtIssuePhone { get; set; }

    public string? StCtIssueSubject { get; set; }

    public string? StCtIssueText { get; set; }

    public sbyte StCtIssueComfirmEmail { get; set; }

    public DateTime? StCtIssueCreateddate { get; set; }

    public DateTime? StCtIssueUpdateddate { get; set; }
        
   public int? Viewcount { get; set; } = 0;

   public int? StCtIssueStatus { get; set; }
}
}

