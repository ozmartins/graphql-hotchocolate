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
            var customer = _demoDbContext.Customers.Find(customerId)!;
            var order = new Order(customer);                        
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

        public Order? RemoveItemFromOrder(Guid orderId, Guid orderItemId)
        {            
            var order = _demoDbContext.Orders.Find(orderId)!;
            order.RemoveItem(orderItemId);
            _demoDbContext.SaveChanges();
            return order;
        }

        public Order? CloseOrder(Guid id)
        {
            var order = _demoDbContext.Orders.Find(id)!;
            order.Close();
            _demoDbContext.SaveChanges();
            return order;
        }

        public Order? CancelOrder(Guid id)
        {
            var order = _demoDbContext.Orders.Find(id)!;
            order.Cancel();
            _demoDbContext.SaveChanges();
            return order;
        }

        public Order? GetOrder(Guid id)
            => _demoDbContext.Orders.Find(id);

        public IEnumerable<Order> GetOrders(OrderStatus? status, int pageSize, int pageNumber)
        {
            var orders = status == null ? 
                _demoDbContext.Orders : 
                _demoDbContext.Orders.Where(x => status == null || x.Status.Equals(status));

            return orders
                .OrderBy(x => x.Date)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize);
        }        
    }
}
