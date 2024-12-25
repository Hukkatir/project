namespace projectAPI.Contracts.MediaFile
{
    public class CreateMediaFileRequest
    {
        public int MediaId { get; set; }
        public int FileId { get; set; }
        public string MediaFileName { get; set; } = null!;

    }
}
