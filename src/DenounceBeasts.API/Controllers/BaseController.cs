using DenounceBeasts.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DenounceBeasts.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController<T> : ControllerBase where T : class
    {
        public readonly ApplicationDataContext Context;

        public BaseController(ApplicationDataContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var entities = Context.Set<T>().ToList();
            return Ok(entities);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var entity = Context.Set<T>().Find(id);
            if (entity == null)
                return NotFound();
            return Ok(entity);
        }

        [HttpPost]
        public IActionResult Create(T entity)
        {
            Context.Add(entity);
            Context.SaveChanges();
            return Ok(entity);

        }

        [HttpPut]
        public IActionResult Update(T entity)
        {
            Context.Update(entity);
            Context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(T entity)
        {
            Context.Remove(entity);
            Context.SaveChanges();
            return NoContent();
        }
    }
}
