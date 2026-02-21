using AutoMapper;
using Azure;
using DenounceBeasts.API.Data;
using DenounceBeasts.API.Data.Entities;
using DenounceBeasts.API.Models;
using DenounceBeasts.API.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DenounceBeasts.API.Controllers
{
    [ApiController]
    [Route("api/sectors")]
    public class SectorsController : ControllerBase
    {
        private readonly ApplicationDataContext _context;
        private readonly IMapper _mapper;

        public SectorsController(ApplicationDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<ApiResponse<List<SectorDto>>> GetAll()
        {
            var sectors = _context.Sectors.ToList();

            //var response = sectors.Select(s => new SectorDto
            //{
            //    Id = s.Id,
            //    Name = s.Name,
            //    PostalCode = s.PostalCode,
            //    IsActive = s.IsActive,
            //    MunicipalityId = s.MunicipalityId
            //}).ToList();
            //var response2 = sectors.Select(s => _mapper.Map<SectorDto>(s)).ToList();

            var response = _mapper.Map<List<SectorDto>>(sectors);
            // return Ok(response);
            //   return Ok(ApiResponse<List<SectorDto>>.SuccessResponse(response));
            return ApiResponse<List<SectorDto>>.SuccessResponse(response);
        }

        [HttpGet]
        [Route("with-municipality")]
        public ActionResult<ApiResponse<List<SectorDto>>> GetAllWithMunicipality()
        {
            //var sectors = _context.Sectors.ToList();


            //foreach (var sector in sectors)
            //{
            //    var municipality = _context.Municipalities.FirstOrDefault(m => m.Id == sector.MunicipalityId);
            //    if (municipality != null)
            //    {
            //        sector.Municipality = municipality;
            //    }
            //}

            //var municipalities = _context.Municipalities.ToList();
            //foreach (var sector in sectors)
            //{
            //    var municipality = municipalities.FirstOrDefault(m => m.Id == sector.MunicipalityId);
            //    if (municipality != null)
            //    {
            //        sector.Municipality = municipality;
            //    }
            //}

            //var sectorsWithMunicipalties = (from s in _context.Sectors
            // join m in _context.Municipalities on s.MunicipalityId equals m.Id into sm
            // from municipality in sm.DefaultIfEmpty()
            // select new Sector
            // {
            //     Id = s.Id,
            //     Name = s.Name,
            //     PostalCode = s.PostalCode,
            //     IsActive = s.IsActive,
            //     MunicipalityId = s.MunicipalityId,
            //     Municipality = municipality
            // }).ToList();

            var sectors = _context.Sectors.Include(p => p.Municipality).ToList();

            //var response = sectors.Select(s => new SectorDto
            //{
            //    Id = s.Id,
            //    Name = s.Name,
            //    PostalCode = s.PostalCode,
            //    IsActive = s.IsActive,
            //    MunicipalityId = s.MunicipalityId,
            //    Municipality = s.Municipality != null ? new MunicipalityDto
            //    {
            //        Id = s.Municipality.Id,
            //        Name = s.Municipality.Name,
            //        IsActive = s.Municipality.IsActive
            //    } : null
            //}).ToList();

            //var response = _mapper.ProjectTo<SectorDto>(_context.Sectors.Include(p => p.Municipality)).ToList();
            var response = _mapper.Map<List<SectorDto>>(sectors);
            //  return Ok(response);
            return ApiResponse<List<SectorDto>>.SuccessResponse(response);

        }

        [HttpGet("{id}")]
        public ActionResult<ApiResponse<SectorDto>> GetById([FromQuery] int id)
        {
            var sector = _context.Sectors.FirstOrDefault(s => s.Id == id);
            if (sector == null)
            {
                return ApiResponse<SectorDto>.ErrorResponse("Sector not found", 404);
                // return NotFound();
            }
            //var response = new SectorDto
            //{
            //    Id = sector.Id,
            //    Name = sector.Name,
            //    PostalCode = sector.PostalCode,
            //    IsActive = sector.IsActive,
            //    MunicipalityId = sector.MunicipalityId
            //};

            var response = _mapper.Map<SectorDto>(sector);
            //return Ok(response);
            return ApiResponse<SectorDto>.SuccessResponse(response);

        }

        [HttpPost]
        public ActionResult<ApiResponse<int>> Create([FromBody] SectorCreateDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                //return BadRequest("Name of sector is required.");
                ApiResponse<int>.ErrorResponse("Name of sector is required.", 400);
            }
             
            //var sector = new Sector
            //{
            //    Name = request.Name,
            //    PostalCode = request.PostalCode,
            //    IsActive = true,
            //    MunicipalityId = request.MunicipalityId,
            //    //Created = DateTime.Now,
            //    //Updated = DateTime.Now
            //};
            var sector = _mapper.Map<Sector>(request);
            sector.IsActive = true;

            _context.Add(sector);
            _context.SaveChanges();

           // return Ok(new { id = sector.Id });
            return ApiResponse<int>.SuccessResponse(sector.Id);

            //return CreatedAtAction(nameof(GetById), new { id = sector.Id }, sector);
        }

        [HttpPut("{id}")]
       // public ActionResult<ApiResponse<bool>> Update([FromRoute] int id, [FromBody] SectorUpdateDto request)
        public ApiResponse<bool> Update([FromRoute] int id, [FromBody] SectorUpdateDto request)
        {
            if (id != request.Id)
            {
                //return BadRequest("ID in URL does not match ID in request body.");
                return ApiResponse<bool>.ErrorResponse("ID in URL does not match ID in request body.", 400);
            }

            var existing = _context.Sectors.FirstOrDefault(s => s.Id == id);
            if (existing == null)
                return ApiResponse<bool>.ErrorResponse("Sector not found", 404);

            existing.Name = request.Name;
            existing.PostalCode = request.PostalCode;
            existing.IsActive = request.IsActive;
            existing.MunicipalityId = request.MunicipalityId;
            //existing.Updated = DateTime.Now;

            _context.Update(existing);
            _context.SaveChanges();

            //return NoContent();
         return    ApiResponse<bool>.SuccessResponse(true);
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
