using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperPOS.Models
{
    public class Product : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public virtual ProductCategory Category { get; set; }
        public decimal PurchasePrice { get; set; } = 0;
        public decimal SellingPrice { get; set; } = 0;
        public double Quantity { get; set; } = 0;
    }
}
