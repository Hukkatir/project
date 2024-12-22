using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class MessagesUser
    {
        public int MessageId { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public int StatusMessageId { get; set; }
        public DateTime SendingDate { get; set; } = DateTime.Now;
        public string MessageText { get; set; } = null!;
        public DateTime? UpdatedDateTime { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDateTime { get; set; }

        public virtual User? DeletedByNavigation { get; set; }
        public virtual Room Room { get; set; } = null!;
        public virtual StatusMessage StatusMessage { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
