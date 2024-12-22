using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Genre
    {
        public Genre()
        {
            Media = new HashSet<Medium>();
        }

        public int GenreId { get; set; }
        public string GenreName { get; set; } = null!;

        public virtual ICollection<Medium> Media { get; set; }
    }
}
