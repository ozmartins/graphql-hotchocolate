using Demo.Domain.Products;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo.Domain.Customers
{
    public class CustomerService
    {
        private readonly DemoDbContext _demoDbContext;

        public CustomerService(DemoDbContext demoDbContext)
        {
            _demoDbContext = demoDbContext;
        }

        public Customer CreateCustomer(string name)
        {
            var customer = new Customer { Id = Guid.NewGuid(), Name = name };
            _demoDbContext.Customers.Add(customer);
            _demoDbContext.SaveChanges();
            return customer;
        }

        public Customer? UpdateCustomer(Guid id, string name)
        {
            var customer = _demoDbContext.Customers.Find(id)!;
            customer.Name = name;
            _demoDbContext.SaveChanges();
            return customer;                        
        }

        public Customer? DeleteCustomer(Guid id)
        {
            var customer = _demoDbContext.Customers.Find(id)!;
            _demoDbContext.Remove(customer);
            _demoDbContext.SaveChanges();
            return customer;                        
        }

        public Customer? GetCustomer(Guid id) 
            => _demoDbContext.Customers.Find(id);

        public IEnumerable<Customer> GetCustomers(int pageSize, int pageNumber)
            => _demoDbContext.Customers.Skip(pageSize * (pageNumber - 1)).Take(pageSize);

    }
}
