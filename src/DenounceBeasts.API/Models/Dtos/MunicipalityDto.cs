using System.Text.Json.Serialization;

namespace DenounceBeasts.API.Models
{
    public class MunicipalityDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty; 
        public bool IsActive { get; set; }

    }
}
