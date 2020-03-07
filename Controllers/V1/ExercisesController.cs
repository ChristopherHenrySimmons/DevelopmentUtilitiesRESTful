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
    public class ExercisesController : Controller//Base
    {
        private readonly DevelopmentUtilitiesContext _context;

        public ExercisesController(DevelopmentUtilitiesContext context)
        {
            _context = context;
        }

        // GET: api/Exercises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExercisesV1>>> GetExercises()
        {
            return await _context.Exercises.ToListAsync();
        }

        // GET: api/Exercises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExercisesV1>> GetExercises(int id)
        {
            var exercises = await _context.Exercises.FindAsync(id);

            if (exercises == null)
            {
                return NotFound();
            }

            return exercises;
        }

        // PUT: api/Exercises/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExercises(int id, ExercisesV1 exercises)
        {
               if (id != exercises.Id)
               {
                    return BadRequest();
               }

               try
               {
                    _context.Database.ExecuteSqlCommand("exercisesUpdate @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7", parameters: new[] { 
                         id.ToString(), exercises.Exercise, exercises.Solution, 
                              exercises.VarableData, exercises.ExerciseLevel, exercises.ProjectType, 
                                   exercises.Langues, exercises.ExpectedSolution });
               }
               catch (Exception e)
               {
                    return BadRequest(e);
               }

               return NoContent();
          }

          // POST: api/Exercises
          [HttpPost]
          public async Task<ActionResult<ExercisesV1>> PostExercises(ExercisesV1 exercises)
          {
               try
               {
                    _context.Exercises.Add(exercises);
                    await _context.SaveChangesAsync();
               }
               catch (Exception e)
               {
                    return BadRequest(e);
               }

               return CreatedAtAction("GetExercises", new { id = exercises.Id }, exercises);
          }

        // DELETE: api/Exercises/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ExercisesV1>> DeleteExercises(int id)
        {
            var exercises = await _context.Exercises.FindAsync(id);
            if (exercises == null)
            {
                return NotFound();
            }

            _context.Exercises.Remove(exercises);
            await _context.SaveChangesAsync();

            return exercises;
        }

        private bool ExercisesExists(int id)
        {
            return _context.Exercises.Any(e => e.Id == id);
        }
    }
}
