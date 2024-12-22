using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class MediaFile
    {
        public int MediaFileId { get; set; }
        public int MediaId { get; set; }
        public int FileId { get; set; }
        public string MediaFileName { get; set; } = null!;

        public virtual File File { get; set; } = null!;
        public virtual Medium Media { get; set; } = null!;
    }
}
