namespace projectAPI.Contracts.CommentRate
{
    public class CreateCommentRateRequest
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }


    }
}
