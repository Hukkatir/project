namespace projectAPI.Contracts.MyRating
{
    public class GetMyRatingResponse
    {
        public int RatingId { get; set; }
        public int UserId { get; set; }
        public int MediaId { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public DateTime? UpdatedDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; }
    }
}
