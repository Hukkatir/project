namespace projectAPI.Contracts.MyRating
{
    public class CreateMyRatingRequest
    {
        public int UserId { get; set; }
        public int MediaId { get; set; }
        public int Rating { get; set; }

    }
}
