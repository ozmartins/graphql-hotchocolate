﻿using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo.Domain.Products
{
    public class ProductService
    {
        private readonly DemoDbContext _demoDbContext;

        public ProductService(DemoDbContext demoDbContext)
        {
            _demoDbContext = demoDbContext;
        }

        public Product CreateProduct(string description, double price)
        {
            var product = new Product(description, price);
            _demoDbContext.Products.Add(product);
            _demoDbContext.SaveChanges();
            return product;
        }

        public Product? UpdateProduct(Guid id, string description, double price)
        {
            var product = _demoDbContext.Products.Find(id)!;
            product.Description = description;
            product.Price = price;
            _demoDbContext.SaveChanges();
            return product;
        }

        public Product? InactiveProduct(Guid id)
        {
            var product = _demoDbContext.Products.Find(id)!;
            product.Active = false;
            _demoDbContext.SaveChanges();
            return product;
        }

        public Product? GetProduct(Guid id) => _demoDbContext.Products.Find(id);

        public IEnumerable<Product> GetProducts(int pageSize, int pageNumber) 
            => _demoDbContext
            .Products
            .Where(x => x.Active)
            .OrderBy(x => x.Description)
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize);        
    }
}
