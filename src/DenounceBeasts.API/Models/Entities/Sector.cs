namespace DenounceBeasts.API.Models
{
    public class Sector
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PostalCode { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool IsActive { get; set; }

        public int MunicipalityId { get; set; } 
        public Municipality Municipality { get; set; }
    }
}
