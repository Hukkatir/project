using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class StatusMessage
    {
        public StatusMessage()
        {
            MessagesUsers = new HashSet<MessagesUser>();
        }

        public int StatusMessageId { get; set; }
        public string StatusMessageName { get; set; } = null!;

        public virtual ICollection<MessagesUser> MessagesUsers { get; set; }
    }
}
