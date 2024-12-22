using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class CommentRate
    {
        public int CommentRateId { get; set; }
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public DateTime? UpdatedDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual Comment Comment { get; set; } = null!;


    }
}
