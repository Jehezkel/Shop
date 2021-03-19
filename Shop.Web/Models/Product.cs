using System.Collections.Generic;

namespace Shop.Web.Models
{
    public class Product : BaseEntity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public ProductDescription ProductDescription { get; set; }
        public ICollection<ProductImage> ProductImages { get; private set; } = new List<ProductImage>();
    }
}