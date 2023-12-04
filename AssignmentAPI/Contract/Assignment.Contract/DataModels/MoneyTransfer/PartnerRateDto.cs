using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Contract.DataModels.MoneyTransfer
{
    public class PartnerRateDto
    {
        public string CurrencyCode { get; set; }
        public string CountryCode { get; set; }
        public double PangeaRate { get; set; }
        public string PaymentMethod { get; set; }
        public string DeliveryMethod { get; set; }

    }
}
