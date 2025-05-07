using System.ComponentModel.DataAnnotations;

namespace ADMIN.ITEGAMAX._4._0.App_Data
{
    public class SvcEmailMessage
    {
        public string SEMsgId { get; set; }

        [Required(ErrorMessage = "Detta fält är obligatoriskt.")]

        public string? SEMsgFrom { get; set; }

        public string? SEMsgFromName { get; set; }

        [Required(ErrorMessage = "Detta fält är obligatoriskt.")]

        public string? SEMsgTo { get; set; }

        public string? SEMsgToName { get; set; }

        public string? SEMsgReplyTo { get; set; }

        public string? SEMsgSubject { get; set; }

        [Required(ErrorMessage = "Detta fält är obligatoriskt.")]
        public bool SEMsgIsHtml { get; set; } = true;

        [Required(ErrorMessage = "Detta fält är obligatoriskt.")]
        public string SEMsgBodyHtml { get; set; } = null!;

        [Required(ErrorMessage = "Detta fält är obligatoriskt.")]
        public bool SEMsgHasAttachments { get; set; } = false;

        public DateTime? SEMsgCreatedDate { get; set; } = DateTime.Now;

        public DateTime? SEMsgUpdatedDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Detta fält är obligatoriskt.")]
        public int SEMsgSystem { get; set; } = 0;

        public int SEMsgStatus { get; set; } = 3;

        public DateTime? SEMsgSentDate { get; set; }

        public int? Viewcount { get; set; } = 0;
    }
}
