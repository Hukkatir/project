using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class MediaType
    {
        public MediaType()
        {
            Media = new HashSet<Medium>();
        }

        public int MediaTypeId { get; set; }
        public string MediaTypeName { get; set; } = null!;

        public virtual ICollection<Medium> Media { get; set; }
    }
}
