using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace SuperPOS.Models
{
    public class Sale : BaseModel
    {
        public int CreatorId { get; set; }
        [ForeignKey(nameof(CreatorId))]
        public virtual User Creator { get; set; }
        public DateTime SaleDate { get; set; }
        public int BuyerId { get; set; }
        [ForeignKey(nameof(BuyerId))]
        public virtual Member Buyer { get; set; }
        public decimal Total { get; set; } = 0;
        public decimal Disc { get; set; } = 0;
        public decimal GrandTotal { get; set; } = 0;
        public decimal TotalPayment { get; set; } = 0;
    }
}
