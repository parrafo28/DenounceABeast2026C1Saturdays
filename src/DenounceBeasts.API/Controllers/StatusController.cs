using DenounceBeasts.API.Data;
using DenounceBeasts.API.Data.Entities;
using DenounceBeasts.API.Models;
using DenounceBeasts.API.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DenounceBeasts.API.Controllers
{
    [ApiController]
    [Route("api/status")]
    public class StatusController : BaseController<Status>
    {
        // private readonly ApplicationDataContext _context;

        public StatusController(ApplicationDataContext context) : base(context)
        {
           // _context = context;
        }

        [HttpGet]
        [Route("get-all-why-yes")]
        public ActionResult<IEnumerable<StatusDto>> GetAllAll()
        {
            var status = Context.Status.ToList();

            var response = status.Select(s => new StatusDto
            {
                Id = s.Id,
                Name = s.Name,
                IsActive = s.IsActive,
            }).ToList();

            return Ok(response);
        }
        //[HttpGet]
        //public ActionResult<IEnumerable<StatusDto>> GetAll()
        //{
        //    var status = _context.Status.ToList();

        //    var response = status.Select(s => new StatusDto
        //    {
        //        Id = s.Id,
        //        Name = s.Name, 
        //        IsActive = s.IsActive, 
        //    }).ToList();

        //    return Ok(response);
        //}


        //[HttpGet("{id}")]
        //public IActionResult GetById( int id)
        //{
        //    var status = _context.Status.FirstOrDefault(s => s.Id == id);
        //    if (status == null)
        //        return NotFound();

        //    var response = new StatusDto
        //    {
        //        Id = status.Id,
        //        Name = status.Name, 
        //        IsActive = status.IsActive, 
        //    };

        //    return Ok(response);
        //}

        //[HttpPost]
        //public ActionResult<Status> Create([FromBody] StatusDto request)
        //{
        //    if (string.IsNullOrWhiteSpace(request.Name))
        //    {
        //        return BadRequest("Name of status is required.");
        //    }

        //    var status = new Status
        //    {
        //        Name = request.Name,
        //        IsActive = true,
        //        Created = DateTime.Now,
        //        Updated = DateTime.Now
        //    };

        //    _context.Add(status);
        //    _context.SaveChanges();

        //    return Ok(new { id = status.Id }); 
        //}

        //[HttpPut("{id}")]
        //public IActionResult Update([FromRoute] int id, [FromBody] StatusDto request)
        //{
        //    if (id != request.Id)
        //    {
        //        return BadRequest("ID in URL does not match ID in request body.");
        //    }

        //    var existing = _context.Status.FirstOrDefault(s => s.Id == id);
        //    if (existing == null)
        //        return NotFound();

        //    existing.Name = request.Name; 
        //    existing.IsActive = request.IsActive; 
        //    existing.Updated = DateTime.Now;

        //    _context.Update(existing);
        //    _context.SaveChanges();

        //    return NoContent();
        //}

        ////[HttpDelete("{id}")]
        //[HttpDelete]
        //public IActionResult Delete([FromBody] StatusDto request)
        //{
        //    var existing = _context.Status.FirstOrDefault(s => s.Id == request.Id);
        //    if (existing == null)
        //        return NotFound();
        //    _context.Remove(existing);
        //    _context.SaveChanges();
        //    return NoContent();
        //}
    }
}
