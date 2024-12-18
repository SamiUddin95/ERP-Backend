﻿using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class PaymentType
    {
        public PaymentType()
        {
            ReceivedPayments = new HashSet<ReceivedPayments>();
        }

        public int Id { get; set; }
        public string PaymentType1 { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public ICollection<ReceivedPayments> ReceivedPayments { get; set; }
    }
}
