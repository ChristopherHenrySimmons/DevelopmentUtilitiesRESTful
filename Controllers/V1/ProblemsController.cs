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
    public class ProblemsController : Controller//Base
    {
        private readonly DevelopmentUtilitiesContext _context;

        public ProblemsController(DevelopmentUtilitiesContext context)
        {
            _context = context;
        }

        // GET: api/Problems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProblemsV1>>> GetProblems()
        {
            return await _context.Problems.ToListAsync();
        }

        // GET: api/Problems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProblemsV1>> GetProblems(int id)
        {
            var problems = await _context.Problems.FindAsync(id);

            if (problems == null)
            {
                return NotFound();
            }

            return problems;
        }

        // PUT: api/Problems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProblems(int id, ProblemsV1 problems)
        {
               if (id != problems.Id)
               {
                    return BadRequest();
               }

               try
               {
                    _context.Database.ExecuteSqlCommand("problemsUpdate @p0, @p1, @p2, @p3, @p4", parameters: new[] { id.ToString(), problems.Title, problems.Solution, problems.SolutionLink, problems.Details });
               }
               catch (Exception e)
               {
                    return BadRequest(e);
               }

               return NoContent();
          }

        // POST: api/Problems
        [HttpPost]
        public async Task<ActionResult<ProblemsV1>> PostProblems(ProblemsV1 problems)
        {
            _context.Problems.Add(problems);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProblems", new { id = problems.Id }, problems);
        }

        // DELETE: api/Problems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProblemsV1>> DeleteProblems(int id)
        {
            var problems = await _context.Problems.FindAsync(id);
            if (problems == null)
            {
                return NotFound();
            }

            _context.Problems.Remove(problems);
            await _context.SaveChangesAsync();

            return problems;
        }

        private bool ProblemsExists(int id)
        {
            return _context.Problems.Any(e => e.Id == id);
        }
    }
}
