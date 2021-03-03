using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Models;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly  ApiContext _ctx;

        public ValuesController(ApiContext ctx){
            _ctx = ctx;
        }
        

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var data = _ctx.Todos.OrderBy(c=>c.Id);

            return Ok(data);
        }

         // GET api/values/5
        [HttpGet("{id}", Name = "GetTodo")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }


        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Todo todo)
        {
            if (todo == null)
            {
                return BadRequest();
            }

            _ctx.Todos.Add(todo);
            _ctx.SaveChanges();

            return CreatedAtRoute("GetTodo", new { id = todo.Id }, todo);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Todo todo)
        {
             if (todo == null || todo.Id != id)
            {
                return BadRequest();
            }

            var updatedTodo = _ctx.Todos.FirstOrDefault(t => t.Id == id);

            if (updatedTodo == null)
            {
                return NotFound();
            }

            updatedTodo.name = todo.name;
            updatedTodo.isCompleted = todo.isCompleted;

            _ctx.SaveChanges();
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = _ctx.Todos.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            _ctx.Todos.Remove(todo);
            _ctx.SaveChanges();
            return new NoContentResult();
        }
    }
}
