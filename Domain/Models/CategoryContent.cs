using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class CategoryContent
    {
        public CategoryContent()
        {
            Contents = new HashSet<Content>();
        }

        public int CategoryContentId { get; set; }
        public string CategoryName { get; set; } = null!;

        public virtual ICollection<Content> Contents { get; set; }
    }
}
