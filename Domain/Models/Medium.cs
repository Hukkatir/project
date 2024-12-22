using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Medium
    {
        public Medium()
        {
            Contents = new HashSet<Content>();
            MediaFiles = new HashSet<MediaFile>();
            MyRatings = new HashSet<MyRating>();
            Rooms = new HashSet<Room>();
            Comments = new HashSet<Comment>();
            Genres = new HashSet<Genre>();
            Groups = new HashSet<GroupMedium>();
        }

        public int MediaId { get; set; }
        public string Title { get; set; } = null!;
        public DateTime ReleaseDate { get; set; }
        public string Plot { get; set; } = null!;
        public int Runtime { get; set; }
        public decimal? ImdbRating { get; set; }
        public int? Season { get; set; }
        public int? Episode { get; set; }
        public int MediaTypeId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDateTime { get; set; }

        public virtual User CreatedByNavigation { get; set; } = null!;
        public virtual User? DeletedByNavigation { get; set; }
        public virtual MediaType MediaType { get; set; } = null!;
        public virtual User? UpdatedByNavigation { get; set; }
        public virtual ICollection<Content> Contents { get; set; }
        public virtual ICollection<MediaFile> MediaFiles { get; set; }
        public virtual ICollection<MyRating> MyRatings { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<GroupMedium> Groups { get; set; }
    }
}
