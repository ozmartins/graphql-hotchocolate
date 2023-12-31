﻿using Demo.Domain.Products;
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
            var customer = new Customer (name);
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

        public Customer? InactiveCustomer(Guid id)
        {
            var customer = _demoDbContext.Customers.Find(id)!;
            customer.Active = false;
            _demoDbContext.SaveChanges();
            return customer;
        }

        public Customer? GetCustomer(Guid id) => _demoDbContext.Customers.Find(id);

        public IEnumerable<Customer> GetCustomers(int pageSize, int pageNumber)
            => _demoDbContext
            .Customers
            .Where(x => x.Active.Equals(true))
            .OrderBy(x => x.Name)
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize);

    }
}
