using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Content
    {
        public int ContentId { get; set; }
        public int AuthorId { get; set; }
        public int MediaId { get; set; }
        public int CategoryContentId { get; set; }
        public string Title { get; set; } = null!;
        public string ContentText { get; set; } = null!;
        public int CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDateTime { get; set; }

        public virtual CategoryContent CategoryContent { get; set; } = null!;
        public virtual User CreatedByNavigation { get; set; } = null!;
        public virtual User? DeletedByNavigation { get; set; }
        public virtual Medium Media { get; set; } = null!;
        public virtual User? UpdatedByNavigation { get; set; }
    }
}
