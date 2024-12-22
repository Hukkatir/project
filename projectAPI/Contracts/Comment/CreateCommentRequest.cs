namespace projectAPI.Contracts.Comment
{
    public class CreateCommentRequest
    {
        public int UserId { get; set; }
        public string CommentText { get; set; } = null!;
    }
}
