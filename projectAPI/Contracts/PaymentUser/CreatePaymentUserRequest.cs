namespace projectAPI.Contracts.PaymentUser
{
    public class CreatePaymentUserRequest
    {
        public int PaymentId { get; set; }
        public int UserId { get; set; }
        public bool Active { get; set; }
    }
}
