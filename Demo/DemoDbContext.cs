using System;
using Demo.Domain.Customers;
using Demo.Domain.Order;
using Demo.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace Demo
{
    public class DemoDbContext : DbContext 
    {
        private string _dbPath;

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public DemoDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            _dbPath = System.IO.Path.Join(path, "Demo.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options
            .EnableSensitiveDataLogging()
            .UseSqlite($"Data Source={_dbPath}");        
    }
}