namespace DenounceBeasts.API.Models.Dtos
{
    public class SectorUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PostalCode { get; set; }
        public bool IsActive { get; set; }
        public int MunicipalityId { get; set; }
    }
}
