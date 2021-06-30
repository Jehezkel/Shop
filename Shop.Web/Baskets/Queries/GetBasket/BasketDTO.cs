using System.Collections.Generic;
using Shop.Web.Products.Queries.GetProducts;

namespace Shop.Web.Baskets.Queries.GetBasket
{
    public class BasketEntry
    {
        public ProductDTO Product { get; set; }
        public int Qty { get; set; }
        public decimal EntryPrice { get; set; }

    }
    public class BasketDTO
    {
        public IList<BasketEntry> BasketEntries { get; set; }
        public decimal TotalAmount { get; set; }
    }
}