namespace projectAPI.Contracts.Payment
{
    public class CreatePaymentRequest
    {
        public string CardNumber { get; set; } = null!;
        public string Cvv { get; set; } = null!;
        public DateTime Date { get; set; }
    }
}
