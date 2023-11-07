using Demo.Domain.Products;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo.Domain.Order
{
    public class OrderService
    {
        private readonly DemoDbContext _demoDbContext;

        public OrderService(DemoDbContext demoDbContext)
        {
            _demoDbContext = demoDbContext;
        }

        public Order CreateOrder(Guid customerId)
        {
            var customer = _demoDbContext.Customers.Find(customerId);            
            var order = new Order 
            { 
                Id = Guid.NewGuid(), 
                Date = DateTime.Today, 
                Customer = customer,                
                Status = OrderStatus.Open, 
                Total = 0 
            };            
            _demoDbContext.Orders.Add(order);
            _demoDbContext.SaveChanges();
            return order;
        }

        public Order? AddItemToOrder(Guid orderId, Guid productId, int quantity)
        {
            var product = _demoDbContext.Products.Find(productId)!;
            var order = _demoDbContext.Orders.Find(orderId)!;
            order.AddItem(product, quantity);
            _demoDbContext.SaveChanges();
            return order;
        }

        public Order? CloseOrder(Guid orderId)
        {
            var order = _demoDbContext.Orders.Find(orderId)!;
            order.Status = OrderStatus.Closed;
            _demoDbContext.SaveChanges();
            return order;
        }

        public Order? CancelOrder(Guid orderId)
        {
            var order = _demoDbContext.Orders.Find(orderId)!;
            order.Status = OrderStatus.Cancelled;
            _demoDbContext.SaveChanges();
            return order;
        }

        public Order? GetOrder(Guid id)
            => _demoDbContext.Orders.Find(id);

        public IEnumerable<Order> GetOrders(int pageSize, int pageNumber)
            => _demoDbContext.Orders.OrderBy(x => x.Date).Skip(pageSize * (pageNumber - 1)).Take(pageSize);

    }
}
