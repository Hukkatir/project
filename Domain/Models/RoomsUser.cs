using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class RoomsUser
    {
        public DateTime JoinedDateTime { get; set; } = DateTime.Now;
        public int RoomId { get; set; }
        public int UserId { get; set; }

        public virtual Room Room { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
