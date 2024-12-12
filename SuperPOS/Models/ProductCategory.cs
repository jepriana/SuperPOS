using System.Collections.Generic;

namespace SuperPOS.Models
{
    public class ProductCategory : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
