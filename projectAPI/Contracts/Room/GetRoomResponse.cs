namespace projectAPI.Contracts.Room
{
    public class GetRoomResponse
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; } = null!;
        public int MediaId { get; set; }
        public int CreatorId { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public int? DeletedBy { get; set; }
        public string? DeletedDateTime { get; set; }
    }
}
