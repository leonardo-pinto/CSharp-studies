namespace ModelBindingAndValidations.Models
{
    public class Book
    {
        // add [FromQuery] to get only
        // specific properties from query string
        public int? BookId { get; set; }
        public string? Author { get; set; }

        public override string ToString()
        {
            return $"Book id: {BookId} - Book Author: {Author}";
        }
    }
}
