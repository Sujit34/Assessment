using System;


namespace Assignment.Contract.Models
{
    public class PartnerRate
    {
        public string Currency { get; set; }
        public string PaymentMethod { get; set; }
        public string DeliveryMethod { get; set; }
        public double Rate { get; set; }
        public DateTime AcquiredDate { get; set; }
    }
}
