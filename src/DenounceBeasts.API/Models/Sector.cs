namespace DenounceBeasts.API.Models
{
    public class Sector
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PostalCode { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updates { get; set; }
        public bool IsActive { get; set; }
    }
}
