using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DenounceBeasts.API.Data.Entities
{
    public class Municipality
    {
        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;
        [StringLength(20)]
        public string PostalCode { get; set; }
        //public DateTime Created { get; set; }
        //public DateTime Updated { get; set; }
        public bool IsActive { get; set; }
        public List<Sector> Sectors { get; set; }
    }
}
