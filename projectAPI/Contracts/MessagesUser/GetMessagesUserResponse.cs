namespace projectAPI.Contracts.MessagesUser
{
    public class GetMessagesUserResponse
    {
        public int MessageId { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public int StatusMessageId { get; set; }
        public DateTime SendingDate { get; set; } = DateTime.Now;
        public string MessageText { get; set; } = null!;
        public DateTime? UpdatedDateTime { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDateTime { get; set; }
    }
}
