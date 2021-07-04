using System.Collections.Generic;
using System.Linq;

namespace Shop.Web.Models
{
    public class Basket
    {
        public int BasketId { get; set; }
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
        public bool isFinalized { get; set; }
        public decimal TotalAmount
        {
            get
            {
                if (this.BasketItems.Count == 0)
                {
                    return 0;
                }
                else
                {
                    return this.BasketItems.Sum(i => i.EntryPrice);
                }
            }
        }
        public ICollection<BasketItem> BasketItems { get; private set; } = new List<BasketItem>();

    }
}