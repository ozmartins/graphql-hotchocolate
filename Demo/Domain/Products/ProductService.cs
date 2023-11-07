using Microsoft.AspNetCore.Mvc.RazorPages;

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
            var product = new Product { Id = Guid.NewGuid(), Description = description, Price = price };
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

        public Product? DeleteProduct(Guid id)
        {
            var product = _demoDbContext.Products.Find(id)!;
            _demoDbContext.Products.Remove(product);
            _demoDbContext.SaveChanges();
            return product;
        }

        public Product? GetProduct(Guid id) 
            => _demoDbContext.Products.Find(id);

        public IEnumerable<Product> GetProducts(int pageSize, int pageNumber) 
            => _demoDbContext.Products.OrderBy(x => x.Description).Skip(pageSize * (pageNumber - 1)).Take(pageSize);

    }
}
