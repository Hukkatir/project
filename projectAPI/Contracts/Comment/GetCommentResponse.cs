namespace projectAPI.Contracts.Comment
{
    public class GetCommentResponse
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public string CommentText { get; set; } = null!;
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; }
    }
}