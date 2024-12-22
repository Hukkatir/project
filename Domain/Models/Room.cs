using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Room
    {
        public Room()
        {
            MessagesUsers = new HashSet<MessagesUser>();
            RoomsUsers = new HashSet<RoomsUser>();
        }

        public int RoomId { get; set; }
        public string RoomName { get; set; } = null!;
        public int MediaId { get; set; }
        public int CreatorId { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public int? DeletedBy { get; set; }
        public string? DeletedDateTime { get; set; }

        public virtual User Creator { get; set; } = null!;
        public virtual User? DeletedByNavigation { get; set; }
        public virtual Medium Media { get; set; } = null!;
        public virtual ICollection<MessagesUser> MessagesUsers { get; set; }
        public virtual ICollection<RoomsUser> RoomsUsers { get; set; }
    }
}
