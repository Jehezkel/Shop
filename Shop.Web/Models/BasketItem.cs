namespace Shop.Web.Models
{
    public class BasketItem
    {
        public int BasketItemId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public Basket Basket { get; set; }
    }
}