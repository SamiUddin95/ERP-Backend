﻿using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class PurchaseDetail
    {
        public int Id { get; set; }
        public int? PurchaseId { get; set; }
        public string Barcode { get; set; }
        public int? ItemId { get; set; }
        public int? Quantity { get; set; }
        public int? BonusQuantity { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal? DiscountByPercent { get; set; }
        public decimal? DiscountByValue { get; set; }
        public decimal? Total { get; set; }
        public decimal? GstByPercent { get; set; }
        public decimal? GstByValue { get; set; }
        public decimal? TotalWithGst { get; set; }
        public decimal? NetRate { get; set; }
        public decimal? MarginPercent { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal? SaleDiscountByValue { get; set; }
        public decimal? NetSalePrice { get; set; }
    }
}
