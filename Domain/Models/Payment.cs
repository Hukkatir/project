using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Payment
    {
        public Payment()
        {
            PaymentUsers = new HashSet<PaymentUser>();
        }

        public int PaymentId { get; set; }
        public string CardNumber { get; set; } = null!;
        public string Cvv { get; set; } = null!;
        public DateTime Date { get; set; }

        public virtual ICollection<PaymentUser> PaymentUsers { get; set; }
    }
}
