using DenounceBeasts.API.Data;
using DenounceBeasts.API.Data.Entities;
using DenounceBeasts.API.Models;
using DenounceBeasts.API.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DenounceBeasts.API.Controllers
{
    [ApiController]
    [Route("api/sectors")]
    public class SectorsController : ControllerBase
    {
        private readonly ApplicationDataContext _context;

        public SectorsController(ApplicationDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SectorDto>> GetAll()
        {
            var sectors = _context.Sectors.ToList();

            var response = sectors.Select(s => new SectorDto
            {
                Id = s.Id,
                Name = s.Name,
                PostalCode = s.PostalCode,
                IsActive = s.IsActive,
                MunicipalityId = s.MunicipalityId
            }).ToList();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromQuery] int id)
        {  
            var sector = _context.Sectors.FirstOrDefault(s => s.Id == id);
            if (sector == null)
                return NotFound();

            var response = new SectorDto
            {
                Id = sector.Id,
                Name = sector.Name,
                PostalCode = sector.PostalCode,
                IsActive = sector.IsActive,
                MunicipalityId = sector.MunicipalityId

                
            };

            return Ok(response);
        }

        [HttpPost]
        public ActionResult<Sector> Create([FromBody] SectorCreateDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return BadRequest("Name of sector is required.");
            }
             

            var sector = new Sector
            {
                Name = request.Name,
                PostalCode = request.PostalCode,
                IsActive = true,
                MunicipalityId = request.MunicipalityId,
                //Created = DateTime.Now,
                //Updated = DateTime.Now
            };

            _context.Add(sector);
            _context.SaveChanges();

            return Ok(new { id = sector.Id });

            //return CreatedAtAction(nameof(GetById), new { id = sector.Id }, sector);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute]int id, [FromBody] SectorUpdateDto request)
        {
            if(id != request.Id)
            {
                return BadRequest("ID in URL does not match ID in request body.");
            }

            var existing = _context.Sectors.FirstOrDefault(s => s.Id == id);
            if (existing == null)
                return NotFound();

            existing.Name = request.Name;
            existing.PostalCode = request.PostalCode;
            existing.IsActive = request.IsActive;
            existing.MunicipalityId = request.MunicipalityId; 
            //existing.Updated = DateTime.Now;

            _context.Update(existing);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromBody] SectorDeleteDto request)
        {
            var existing = _context.Sectors.FirstOrDefault(s => s.Id == request.Id);
            if (existing == null)
                return NotFound();
            _context.Remove(existing);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
