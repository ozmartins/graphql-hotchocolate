using System.Collections.ObjectModel;
using Demo.Domain.Customers;
using Demo.Domain.Products;

namespace Demo.Domain.Order
{
    public class Order
    {
        private List<OrderItem> _items;
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Customer? Customer { get; set; }
        public double Total { get; set; }
        public IReadOnlyCollection<OrderItem> Items { get; set; }
        public OrderStatus Status { get; set; }

        public Order()
        {
            _items = new List<OrderItem>();
            Items = new ReadOnlyCollection<OrderItem>(_items);
        }

        public void AddItem(Product product, int quantity)
        { 
            var orderItem = new OrderItem 
            { 
                Id = Guid.NewGuid(), 
                Product = product, 
                Quantity = quantity,
                Price = product.Price,
                Total = quantity * product.Price
            };
            _items.Add(orderItem);            
            Total = Items.Sum(x => x.Total);
        }
    }
}
