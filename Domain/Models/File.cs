using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class File
    {
        public File()
        {
            MediaFiles = new HashSet<MediaFile>();
        }

        public int FileId { get; set; }
        public string FileName { get; set; } = null!;
        public string FileUrl { get; set; } = null!;
        public int CategoryFileId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDateTime { get; set; }

        public virtual CategoryFile CategoryFile { get; set; } = null!;
        public virtual User CreatedByNavigation { get; set; } = null!;
        public virtual User? DeletedByNavigation { get; set; }
        public virtual User? UpdatedByNavigation { get; set; }
        public virtual ICollection<MediaFile> MediaFiles { get; set; }
    }
}
