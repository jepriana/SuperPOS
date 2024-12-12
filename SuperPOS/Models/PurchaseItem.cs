using System.ComponentModel.DataAnnotations.Schema;

namespace SuperPOS.Models
{
    public class PurchaseItem : BaseModel
    {
        public int PurchaseId { get; set; }
        [ForeignKey(nameof(PurchaseId))]
        public Purchase Purchase { get; set; }
        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        public double Quantity { get; set; } = 0;
        public decimal Price { get; set; } = 0;
        public decimal Disc { get; set; } = 0;
        public decimal Amount { get; set; } = 0;
    }
}
