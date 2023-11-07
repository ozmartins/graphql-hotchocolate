using Demo.Domain.Customers;
using Demo.Domain.Order;
using Demo.Domain.Products;

namespace Demo.GraphQL
{
    public class Query
    {
        private readonly ProductService _productService;
        private readonly CustomerService _customerService;
        private readonly OrderService _orderService;

        public Query(ProductService productService, CustomerService customerService, OrderService orderService)
        {
            _productService = productService;
            _customerService = customerService;
            _orderService = orderService;
        }

        public IEnumerable<Product> Products(int pageSize, int pageNumber) => _productService.GetProducts(pageSize, pageNumber);
        public Product? Product(Guid id) => _productService.GetProduct(id);

        public IEnumerable<Customer> Customers(int pageSize, int pageNumber) => _customerService.GetCustomers(pageSize, pageNumber);
        public Customer? Customer(Guid id) => _customerService.GetCustomer(id);

        public IEnumerable<Order> Orders(int pageSize, int pageNumber) => _orderService.GetOrders(pageSize, pageNumber);
        public Order? Orders(Guid id) => _orderService.GetOrder(id);
    }
}