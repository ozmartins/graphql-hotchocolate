namespace Demo.Domain.Products
{
    public class Product
    {
        public Guid Id { get; protected set; }
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public bool Active { get; set; }

        public Product()
        {
            Id = Guid.NewGuid();
            Active = true;
        }

        public Product(string description, double price) : this() 
        {
            Description = description;
            Price = price;
        }
    }
}