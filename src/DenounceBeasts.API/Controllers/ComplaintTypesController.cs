using DenounceBeasts.API.Data;
using DenounceBeasts.API.Data.Entities;
using DenounceBeasts.API.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DenounceBeasts.API.Controllers
{
    [ApiController]
    [Route("api/complaintTypes")]
    public class ComplaintTypesController : ControllerBase
    {
        private readonly ApplicationDataContext _context;

        public ComplaintTypesController(ApplicationDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ComplaintTypeDto>> GetAll()
        {
            var complaintTypes = _context.ComplaintTypes.ToList();

            var response = complaintTypes.Select(s => new ComplaintTypeDto
            {
                Id = s.Id,
                Name = s.Name,
                IsActive = s.IsActive
            }).ToList();

            return Ok(response);
        }


        [HttpGet("{id}")]
        public IActionResult GetById([FromQuery] int id)
        {
            var complaintType = _context.ComplaintTypes.FirstOrDefault(s => s.Id == id);
            if (complaintType == null)
                return NotFound();

            var response = new ComplaintTypeDto
            {
                Id = complaintType.Id,
                Name = complaintType.Name,
                IsActive = complaintType.IsActive,
            };

            return Ok(response);
        }

        [HttpPost]
        public ActionResult<ComplaintType> Create([FromBody] ComplaintTypeDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return BadRequest("Name of complaintType is required.");
            }


            var complaintType = new ComplaintType
            {
                Name = request.Name,
                IsActive = true,
                Created = DateTime.Now,
                Updated = DateTime.Now
            };

            _context.Add(complaintType);
            _context.SaveChanges();

            return Ok(new { id = complaintType.Id });

        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] ComplaintTypeDto request)
        {
            if (id != request.Id)
            {
                return BadRequest("ID in URL does not match ID in request body.");
            }

            var existing = _context.ComplaintTypes.FirstOrDefault(s => s.Id == id);
            if (existing == null)
                return NotFound();

            existing.Name = request.Name;
            existing.IsActive = request.IsActive;
            existing.Updated = DateTime.Now;

            _context.Update(existing);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] ComplaintTypeDto request)
        {
            var existing = _context.ComplaintTypes.FirstOrDefault(s => s.Id == request.Id);
            if (existing == null)
                return NotFound();
            _context.Remove(existing);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
