﻿using System;
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
    public class ResourcesController : Controller//Base
    {
        private readonly DevelopmentUtilitiesContext _context;

        public ResourcesController(DevelopmentUtilitiesContext context)
        {
            _context = context;
        }

        // GET: api/Resources
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResourcesV1>>> GetResources()
        {
            return await _context.Resources.ToListAsync();
        }

        // GET: api/Resources/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResourcesV1>> GetResources(int id)
        {
            var resources = await _context.Resources.FindAsync(id);

            if (resources == null)
            {
                return NotFound();
            }

            return resources;
        }

        // PUT: api/Resources/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResources(int id, ResourcesV1 resources)
        {
               if (id != resources.Id)
               {
                    return BadRequest();
               }

               try
               {
                    _context.Database.ExecuteSqlCommand("resourcesUpdate @p0, @p1, @p2, @p3, @p4", parameters: new[] { id.ToString(), resources.Title, resources.Description, resources.Link, resources.Langues });
               }
               catch (Exception e)
               {
                    return BadRequest(e);
               }

               return NoContent();
          }

        // POST: api/Resources
        [HttpPost]
        public async Task<ActionResult<ResourcesV1>> PostResources(ResourcesV1 resources)
        {
            _context.Resources.Add(resources);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResources", new { id = resources.Id }, resources);
        }

        // DELETE: api/Resources/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResourcesV1>> DeleteResources(int id)
        {
            var resources = await _context.Resources.FindAsync(id);
            if (resources == null)
            {
                return NotFound();
            }

            _context.Resources.Remove(resources);
            await _context.SaveChangesAsync();

            return resources;
        }

        private bool ResourcesExists(int id)
        {
            return _context.Resources.Any(e => e.Id == id);
        }
    }
}
