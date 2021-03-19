using System.Runtime.Intrinsics.X86;
namespace Shop.Web.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitAmount { get; set; }
        public decimal TotalUnitAmount { get; set; }
    }
}