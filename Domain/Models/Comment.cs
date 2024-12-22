using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Comment
    {
        public Comment()
        {
            Media = new HashSet<Medium>();
        }

        public int CommentId { get; set; }
        public int UserId { get; set; }
        public string CommentText { get; set; } = null!;
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public DateTime? UpdatedDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; }

        public virtual User User { get; set; } = null!;

        public virtual ICollection<Medium> Media { get; set; }
    }
}
