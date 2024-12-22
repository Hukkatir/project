using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class GroupMedium
    {
        public GroupMedium()
        {
            Media = new HashSet<Medium>();
        }

        public int GroupId { get; set; }
        public string GroupName { get; set; } = null!;
        public string GroupDescrip { get; set; } = null!;

        public virtual ICollection<Medium> Media { get; set; }
    }
}
