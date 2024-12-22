namespace projectAPI.Contracts.Medium
{
    public class CreateMediumRequest
    {
        public string Title { get; set; } = null!;
        public DateTime ReleaseDate { get; set; }
        public string Plot { get; set; } = null!;
        public int Runtime { get; set; }
        public decimal? ImdbRating { get; set; }
        public int? Season { get; set; }
        public int? Episode { get; set; }
        public int MediaTypeId { get; set; }
        public int CreatedBy { get; set; }

    }
}
