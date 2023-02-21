namespace Entities
{
    /// <summary>
    /// Domain Model for country details
    /// </summary>
    public class Country
    {
        public Guid CountryID { get; set; }
        public string? CountryName { get; set; }
    }
}