﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ATL_API_SPMT.Data;
using ATL_API_SPMT.Models;

namespace ATL_API_SPMT.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        private readonly ShipmentContext _context;

        public RoutesController(ShipmentContext context)
        {
            _context = context;
        }

        // GET: api/Routes
        [HttpGet]
        [ProducesResponseType(typeof(Route), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Route>>> GetRoutes()
        {
            return await _context.Routes.ToListAsync();
        }

        // GET: api/Routes/b65d55e7-f9e1-44c7-a38b-d527fb7cabde
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(Route), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Route>> GetRoute(Guid id)
        {
            var route = await _context.Routes.FindAsync(id);

            if (route == null)
            {
                return NotFound();
            }

            return route;
        }

        // PUT: api/Routes/b65d55e7-f9e1-44c7-a38b-d527fb7cabde
        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(Route), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutRoute(Guid id, Route route)
        {
            if (id != route.Route_Id)
            {
                return BadRequest();
            }

            _context.Entry(route).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RouteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Routes
        [HttpPost]
        [ProducesResponseType(typeof(Route), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Route>> PostRoute(Route route)
        {
            _context.Routes.Add(route);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoute", new { id = route.Route_Id }, route);
        }

        // DELETE: api/Routes/b65d55e7-f9e1-44c7-a38b-d527fb7cabde
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(Route), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Route>> DeleteRoute(Guid id)
        {
            var route = await _context.Routes.FindAsync(id);
            if (route == null)
            {
                return NotFound();
            }

            _context.Routes.Remove(route);
            await _context.SaveChangesAsync();

            return route;
        }

        private bool RouteExists(Guid id)
        {
            return _context.Routes.Any(e => e.Route_Id == id);
        }
    }
}
