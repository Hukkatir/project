namespace projectAPI.Contracts.CommentRate
{
    public class GetCommentRateResponse
    {
        public int CommentRateId { get; set; }
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public DateTime? UpdatedDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; }

    }
}
