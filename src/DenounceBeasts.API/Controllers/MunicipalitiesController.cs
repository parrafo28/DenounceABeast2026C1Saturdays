using DenounceBeasts.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DenounceBeasts.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MunicipalitiesController : ControllerBase
    {

        private static List<Municipality> _municipalities = new List<Municipality>()
            {
                new Municipality{ Id = 1, Name = "Municipality A", PostalCode="1251", Created= DateTime.Now.AddDays(-8), Updated= DateTime.Now.AddDays(-6) , IsActive= true },
                new Municipality{ Id = 2, Name = "Municipality A.1", PostalCode="54654", Created= DateTime.Now.AddDays(-5), Updated= DateTime.Now.AddDays(-2), IsActive = true  },
                new Municipality{ Id = 3, Name = "Municipality B", PostalCode="546", Created= DateTime.Now.AddDays(-10), Updated= DateTime.Now.AddDays(-4) , IsActive=false }
            };

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var municipality = _municipalities.FirstOrDefault(m => m.Id == id);
            if (municipality == null)
            {
                return NotFound();
            }
            return Ok(municipality);
        }

        [HttpGet]
        public IActionResult Get()
        {
            //var municipalities = new List<Municipality>()
            //{
            //    new Municipality{ Id = 1, Name = "Municipality A" },
            //    new Municipality{ Id = 2, Name = "Municipality B" }
            //};
            return Ok(_municipalities);
        }

        [HttpGet("/api/sectors/Get1")]
        public IActionResult Getxx()
        {
            //var municipalities = new List<Municipality>()
            //{
            //    new Municipality{ Id = 1, Name = "Municipality A" },
            //    new Municipality{ Id = 2, Name = "Municipality B" }
            //};
            return Ok(_municipalities);
        }

        [HttpGet("Get2")]
        public IActionResult Getx()
        {
            //var municipalities = new List<Municipality>()
            //{
            //    new Municipality{ Id = 1, Name = "Municipality A" },
            //    new Municipality{ Id = 2, Name = "Municipality B" }
            //};
            return Ok(_municipalities);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Municipality municipality)
        {
            municipality.Id = _municipalities.Max(m => m.Id) + 1;
            municipality.Created = DateTime.Now;
            municipality.Updated = DateTime.Now;
            _municipalities.Add(municipality);
            return CreatedAtAction(nameof(Get), new { id = municipality.Id }, municipality);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Municipality updatedMunicipality)
        {
            var municipality = _municipalities.FirstOrDefault(m => m.Id == id);
            if (municipality == null)
            {
                return NotFound();
            }
            municipality.Name = updatedMunicipality.Name;
            municipality.PostalCode = updatedMunicipality.PostalCode;
            municipality.Updated = DateTime.Now;
            //return NoContent();
            return Ok(municipality);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var municipality = _municipalities.Find(m => m.Id == id);
            if (municipality == null)
            {
                return NotFound();
            }
            _municipalities.Remove(municipality);
            return NoContent();
        }
    }
}
