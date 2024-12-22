namespace projectAPI.Contracts.Content
{
    public class GetContentResponse
    {
        public int ContentId { get; set; }
        public int AuthorId { get; set; }
        public int MediaId { get; set; }
        public int CategoryContentId { get; set; }
        public string Title { get; set; } = null!;
        public string ContentText { get; set; } = null!;
        public int CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDateTime { get; set; }
    }
}