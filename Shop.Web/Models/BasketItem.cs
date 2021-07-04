namespace Shop.Web.Models
{
    public class BasketItem
    {
        public int BasketItemId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal EntryPrice
        {
            get
            {
                if (this.Product.Price == 0 || this.Quantity == 0)
                {
                    return 0;
                }
                else
                {
                    return this.Product.Price * this.Quantity;
                }
            }
        }
        public Basket Basket { get; set; }
    }
}