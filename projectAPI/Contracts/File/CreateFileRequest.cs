namespace projectAPI.Contracts.File
{
    public class CreateFileRequest
    {
        public string FileName { get; set; } = null!;
        public string FileUrl { get; set; } = null!;
        public int CategoryFileId { get; set; }
        public int CreatedBy { get; set; }
    }
}
