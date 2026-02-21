using System.ComponentModel.DataAnnotations;

namespace DenounceBeasts.API.Data.Entities
{
    public class Status
    {
        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool IsActive { get; set; }
    }
}
