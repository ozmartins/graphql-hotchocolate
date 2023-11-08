using Demo.Domain.Customers;
using Demo.Domain.Order;
using Demo.Domain.Products;

namespace Demo.GraphQL
{
    public class Mutation
    {
        private readonly ProductService _productService;
        private readonly CustomerService _customerService;
        private readonly OrderService _orderService;

        public Mutation(ProductService productService, CustomerService customerService, OrderService orderService)
        {
            _productService = productService;
            _customerService = customerService;
            _orderService = orderService;
        }

        public Product CreateProduct(string description, double price) => _productService.CreateProduct(description, price);
        public Product? UpdateProduct(Guid id, string description, double price)=> _productService.UpdateProduct(id, description, price);
        public Product? InactiveProduct(Guid id) => _productService.InactiveProduct(id);        

        public Customer CreateCustomer(string name) => _customerService.CreateCustomer(name);
        public Customer? UpdateCustomer(Guid id, string name) => _customerService.UpdateCustomer(id, name);
        public Customer? InactiveCustomer(Guid id) => _customerService.InactiveCustomer(id);

        public Order CreateOrder(Guid customerId) => _orderService.CreateOrder(customerId);
        public Order? AddItemToOrder(Guid orderId, Guid productId, int quantity) => _orderService.AddItemToOrder(orderId, productId, quantity);
        public Order? RemoveItemFromOrder(Guid orderId, Guid productId) => _orderService.RemoveItemFromOrder(orderId, productId);
        public Order? CloseOrder(Guid id) => _orderService.CloseOrder(id);
        public Order? CancelOrder(Guid id) => _orderService.CancelOrder(id);
    }
}
