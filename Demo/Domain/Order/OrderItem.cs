using Demo.Domain.Products;

namespace Demo.Domain.Order
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Product? Product { get; set; }
        public int Quantity { get; set; }
        public double Price{ get; set; }
        public double Total { get; set; }        
    }
}
