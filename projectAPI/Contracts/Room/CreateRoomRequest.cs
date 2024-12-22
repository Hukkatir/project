namespace projectAPI.Contracts.Room
{
    public class CreateRoomRequest
    {
        public string RoomName { get; set; } = null!;
        public int MediaId { get; set; }
        public int CreatorId { get; set; }

    }
}
