namespace MinimalAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public override string ToString()
        {
            return $"Product ID: {Id}, Product Name: {Name}";
        }
    }
}
