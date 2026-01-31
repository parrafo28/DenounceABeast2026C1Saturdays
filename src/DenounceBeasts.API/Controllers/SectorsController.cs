using DenounceBeasts.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DenounceBeasts.API.Controllers
{
    [ApiController]
    [Route("api/sectors")]
    public class SectorsController : ControllerBase
    {
        private static readonly List<Sector> _sectors = new List<Sector>
        {
            new Sector { Id = 1, Name = "Zona Colonial", PostalCode = "1", IsActive = true, MunicipalityId = 1 },
            new Sector { Id = 2, Name = "Gascue", PostalCode = "1", IsActive = true , MunicipalityId = 1},
            new Sector { Id = 3, Name = "Cienfuegos", PostalCode = "2", IsActive = true, MunicipalityId = 3 }
        };

        [HttpGet]
        public ActionResult<IEnumerable<SectorDto>> GetAll()
        {
            //var sectors = new List<SectorDto>();
            //foreach (var sector in _sectors)
            //{
            //    sectors.Add(new SectorDto
            //    {
            //        Id = sector.Id,
            //        Name = sector.Name,
            //        PostalCode = sector.PostalCode,
            //        IsActive = sector.IsActive,
            //        MunicipalityId = sector.MunicipalityId
            //    });
            //}

            var response = _sectors.Select(s => new SectorDto
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
        public ActionResult<Sector> GetById(int id)
        {
            var sector = _sectors.FirstOrDefault(s => s.Id == id);
            if (sector == null)
                return NotFound();
            return Ok(sector);
        }

        [HttpPost]
        public ActionResult<Sector> Create(SectorDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return BadRequest("Name of sector is required.");
            }

            int newId = _sectors.Any() ? _sectors.Max(s => s.Id) + 1 : 1;
            request.Id = newId;
            request.IsActive = true;

            var sector = new Sector
            {
                Id = request.Id,
                Name = request.Name,
                PostalCode = request.PostalCode,
                IsActive = request.IsActive,
                MunicipalityId = request.MunicipalityId,
                Created = DateTime.Now,
                Updated = DateTime.Now
            };

            _sectors.Add(sector);
            return CreatedAtAction(nameof(GetById), new { id = request.Id }, request);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, SectorDto request)
        {
            var existing = _sectors.FirstOrDefault(s => s.Id == id);
            if (existing == null)
                return NotFound();
            existing.Name = request.Name;
            existing.PostalCode = request.PostalCode;
            existing.IsActive = request.IsActive;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _sectors.FirstOrDefault(s => s.Id == id);
            if (existing == null)
                return NotFound();
            _sectors.Remove(existing);
            return NoContent();
        }
    }
}
