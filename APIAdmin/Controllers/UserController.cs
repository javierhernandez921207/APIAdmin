using APIAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly AplicationDBContext context;
        public UserController(AplicationDBContext aplicationDBContext)
        {
            context = aplicationDBContext;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var listUser = await context.User.ToListAsync();
                return Ok(listUser);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] User user)
        {
            try
            {
                context.Add(user);
                await context.SaveChangesAsync();
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> put(int id, [FromBody] User user)
        {
            try
            {
                if (id != user.Id)
                    return NotFound();

                context.User.Update(user);
                await context.SaveChangesAsync();
                return Ok(new { message = "Usuario modificado con éxito." });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var usuario = await context.User.FindAsync(id);
                if (usuario == null)
                    return NotFound();
                context.User.Remove(usuario);
                await context.SaveChangesAsync();
                return Ok(new { message = "Usuario eliminado con éxito" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
