using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BasicCSharpRESTful.Models;

namespace BasicCSharpRESTful.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CommandsController : Controller//Base
    {
        private readonly DevelopmentUtilitiesContext _context;

        public CommandsController(DevelopmentUtilitiesContext context)
        {
            _context = context;
        }

        // GET: api/v1/Commands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommandsV1>>> GetCommands()
        {
            return await _context.Commands.ToListAsync();
        }

        // GET: api/v1/Commands/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommandsV1>> GetCommands(int id)
        {
            var commands = await _context.Commands.FindAsync(id);

            if (commands == null)
            {
                return NotFound();
            }

            return commands;
        }

          // GET: api/v1/Commands/Top/5
          [HttpGet("/Top/{amount}")]
          public async Task<String> GetTopCommands(int amount)
          {
               return _context.Commands.FromSql("commandsSelection @Amount", amount).ToString();
          }

          // PUT: api/v1/Commands/5
          [HttpPut("{id}")]
        public async Task<IActionResult> PutCommands(int id, CommandsV1 commands)
        {            
            if (id != commands.Id)
            {
                return BadRequest();
            }

               try
               {
                    _context.Database.ExecuteSqlCommand("commandsUpdate @p0, @p1, @p2, @p3", parameters: new[] { id.ToString(), commands.Title, commands.Command, commands.ConsoleType });
               }
               catch (Exception e)
               {
                    return BadRequest(e);
               }

            return NoContent();
        }

        // POST: api/v1/Commands
        [HttpPost]
        public async Task<ActionResult<CommandsV1>> PostCommands(CommandsV1 commands)
        {
            _context.Commands.Add(commands);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommands", new { id = commands.Id }, commands);
        }

        // DELETE: api/v1/Commands/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CommandsV1>> DeleteCommands(int id)
        {
            var commands = await _context.Commands.FindAsync(id);
            if (commands == null)
            {
                return NotFound();
            }

            _context.Commands.Remove(commands);
            await _context.SaveChangesAsync();

            return commands;
        }

        private bool CommandsExists(int id)
        {
            return _context.Commands.Any(e => e.Id == id);
        }
    }
}
