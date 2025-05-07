namespace ADMIN.ITEGAMAX._4._0.App_Data
{
    public class EmailAttachment
    {
        public string EmssgAttachId { get; set; }
        public string EmssgId { get; set; } // This must be required
        public string EmssgAttachFileName { get; set; }
        public string EmssgAttachDownloadUrl { get; set; }
        public string EmssgAttachFileType { get; set; }
        public DateTime? EmssgAttachCreated { get; set; }
        public byte EmssgAttachSend { get; set; }

        public DateTime? EmssgAttachUpdatedDate { get; set; } = DateTime.Now;
        public int ViewCount { get; set; }
        // Add OtherDetails and Description if necessary


    }
}

