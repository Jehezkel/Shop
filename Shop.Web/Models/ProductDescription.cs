namespace Shop.Web.Models
{
    public class ProductDescription : BaseEntity
    {
        public int ProductId { get; set; }
        public string Description { get; set; }
        public Product Product { get; set; }
    }
}