namespace DenounceBeasts.API.Models.Dtos
{
    public class SectorCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public string PostalCode { get; set; } 
        public int MunicipalityId { get; set; }
    }
}
