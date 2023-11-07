namespace Demo.Domain.Customers
{
    public class Customer
    {
        public Guid Id { get; protected set; }
        public string Name { get; set; } = string.Empty;
        public bool Active { get; set; }

        public Customer()
        {
            Id = Guid.NewGuid();
            Active = true;
        }

        public Customer(string name) : this() 
        {
            Name = name;
        }
    }
}
