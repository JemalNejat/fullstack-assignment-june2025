namespace ADMIN.ITEGAMAX._4._0.App_Data
{
    public class SvcEmailMessagesAttachments
    {
        public int EmssgAttachId { get; set; } // Example property
        public string EmssgAttachFileName { get; set; }
        public string EmssgAttachFileType { get; set; }
        public DateTime EmssgAttachCreated { get; set; } = DateTime.Now;
        public int EmssgAttachSend { get; set; }

        public string Description { get; set; }  // Ensure this property exists
        public string OtherDetails { get; set; } 
     

    }
}
