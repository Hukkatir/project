namespace projectAPI.Contracts.Content
{
    public class CreateContentRequest
    {
        public int AuthorId { get; set; }
        public int MediaId { get; set; }
        public int CategoryContentId { get; set; }
        public string Title { get; set; } = null!;
        public string ContentText { get; set; } = null!;
        public int CreatedBy { get; set; }
    }
}