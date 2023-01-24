namespace ModelBindingAndValidations.Models
{
    public class Book
    {
        // add [FromQuery] to get only
        // specific properties from query string
        public int? Id { get; set; }
        public string? Author { get; set; }

        public override string ToString()
        {
            return $"Book id: {Id} - Book Author: {Author}";
        }
    }
}
