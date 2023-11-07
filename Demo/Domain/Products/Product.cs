namespace Demo.Domain.Products
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
    }
}