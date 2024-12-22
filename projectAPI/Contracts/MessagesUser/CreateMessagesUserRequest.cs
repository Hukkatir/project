namespace projectAPI.Contracts.MessagesUser
{
    public class CreateMessagesUserRequest
    {
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public int StatusMessageId { get; set; }
        public string MessageText { get; set; } = null!;

    }
}
