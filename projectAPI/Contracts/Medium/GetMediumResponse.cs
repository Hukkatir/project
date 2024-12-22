namespace projectAPI.Contracts.Medium
{
    public class GetMediumResponse
    {
        public int MediaId { get; set; }
        public string Title { get; set; } = null!;
        public DateTime ReleaseDate { get; set; }
        public string Plot { get; set; } = null!;
        public int Runtime { get; set; }
        public decimal? ImdbRating { get; set; }
        public int? Season { get; set; }
        public int? Episode { get; set; }
        public int MediaTypeId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDateTime { get; set; }
    }
}
