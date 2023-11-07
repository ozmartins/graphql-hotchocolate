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
        public Product? DeleteProduct(Guid id) => _productService.DeleteProduct(id);        

        public Customer CreateCustomer(string name) => _customerService.CreateCustomer(name);
        public Customer? UpdateCustomer(Guid id, string name) => _customerService.UpdateCustomer(id, name);
        public Customer? DeleteCustomer(Guid id) => _customerService.DeleteCustomer(id);

        public Order CreateOrder(Guid customerId) => _orderService.CreateOrder(customerId);
        public Order? AddItemToOrder(Guid orderId, Guid productId, int quantity) => _orderService.AddItemToOrder(orderId, productId, quantity);
        public Order? CloseOrder(Guid orderId) => _orderService.CloseOrder(orderId);
        public Order? CancelOrder(Guid orderId) => _orderService.CancelOrder(orderId);
    }
}
