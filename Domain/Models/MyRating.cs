using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class MyRating
    {
        public int RatingId { get; set; }
        public int UserId { get; set; }
        public int MediaId { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public DateTime? UpdatedDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; }

        public virtual Medium Media { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
