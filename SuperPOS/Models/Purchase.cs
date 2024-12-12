using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperPOS.Models
{
    public class Purchase : BaseModel
    {
        public int CreatorId { get; set; }
        [ForeignKey(nameof(CreatorId))]
        public virtual User Creator { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int SellerId { get; set; }
        [ForeignKey(nameof(SellerId))]
        public virtual Supplier Seller { get; set; }
        public decimal Total { get; set; } = 0;
        public decimal Disc { get; set; } = 0;
        public decimal GrandTotal { get; set; } = 0;
        public decimal TotalPayment { get; set; } = 0;
    }
}
