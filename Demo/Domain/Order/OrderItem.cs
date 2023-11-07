using Demo.Domain.Products;

namespace Demo.Domain.Order
{
    public class OrderItem
    {
        public OrderItem() { }

        public OrderItem(Product product, int quantity)
        {
            UpdateProduct(product);
            UpdateQuantity(quantity);
        }

        public Guid Id { get; set; }
        public Product? Product { get; protected set; }
        public int Quantity { get; protected set; }
        public double Price { get; protected set; }
        public double Total { get; protected set; }
        
        private void UpdateProduct(Product product)
        {
            Product = product;
            UpdatePrice(product.Price);           
        }
        private void UpdateQuantity(int quantity)
        {
            Quantity = quantity;
            UpdateTotal();
        }
        private void UpdatePrice(double price) 
        {
            Price = price;
            UpdateTotal();
        }
        private void UpdateTotal() => Total = Quantity * Price;
    }
}
