namespace DenounceBeasts.API.Models.Dtos
{
    public class SectorListWithMunicipalityDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PostalCode { get; set; }
        public bool IsActive { get; set; }
        public MunicipalityDto Municipality { get; set; }
        public int MunicipalityId { get; set; }
    }
}
