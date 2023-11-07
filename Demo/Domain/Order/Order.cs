using System.Collections.ObjectModel;
using Demo.Domain.Customers;
using Demo.Domain.Products;

namespace Demo.Domain.Order
{
    public class Order
    {        
        public Guid Id { get; protected set; }
        public DateTime Date { get; protected set; }
        public Customer? Customer { get; set; }
        public double Total { get; protected set; }
        public IList<OrderItem> Items { get; }
        public OrderStatus Status { get; protected set; }

        public Order()
        {
            Id = Guid.NewGuid();
            Date = DateTime.Now;
            Items = new List<OrderItem>();
            Status = OrderStatus.Open;
        }

        public Order(Customer customer) : this()
        {
            Customer = customer;
        }

        public void AddItem(Product product, int quantity)
        {
            var orderItem = new OrderItem(product, quantity);
            Items.Add(orderItem);
            UpdateTotal();
        }

        public void RemoveItem(Guid productId)
        {            ;
            var orderItem = Items.FirstOrDefault(x => x.Product!.Id.Equals(productId))!;
            Items.Remove(orderItem);
            UpdateTotal();
        }

        public void Close() 
        {
            if (Status.Equals(OrderStatus.Open))
                Status = OrderStatus.Closed;
        }

        public void Cancel()
        {
            if (Status.Equals(OrderStatus.Open) || Status.Equals(OrderStatus.Closed))
                Status = OrderStatus.Cancelled;
        }

        private void UpdateTotal() => Total = Items.Sum(x => x.Total);
    }
}
