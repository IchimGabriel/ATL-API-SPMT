using System;
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
    public class ContainersController : ControllerBase
    {
        private readonly ShipmentContext _context;

        public ContainersController(ShipmentContext context)
        {
            _context = context;
        }

        // GET: api/Containers
        [HttpGet]
        [ProducesResponseType(typeof(Container), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Container>>> GetContainers()
        {
            return await _context.Containers.ToListAsync();
        }

        // GET: api/Containers/b65d55e7-f9e1-44c7-a38b-d527fb7cabde
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(Container), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Container>> GetContainer(Guid id)
        {
            var container = await _context.Containers.FindAsync(id);

            if (container == null)
            {
                return NotFound();
            }

            return container;
        }

        // PUT: api/Containers/b65d55e7-f9e1-44c7-a38b-d527fb7cabde
        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(Container), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutContainer(Guid id, Container container)
        {
            if (id != container.Unit_Id)
            {
                return BadRequest();
            }

            _context.Entry(container).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContainerExists(id))
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

        // POST: api/Containers
        [HttpPost]
        [ProducesResponseType(typeof(Container), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Container>> PostContainer(Container container)
        {
            _context.Containers.Add(container);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContainer", new { id = container.Unit_Id }, container);
        }

        // DELETE: api/Containers/b65d55e7-f9e1-44c7-a38b-d527fb7cabde
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(Container), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Container>> DeleteContainer(Guid id)
        {
            var container = await _context.Containers.FindAsync(id);
            if (container == null)
            {
                return NotFound();
            }

            _context.Containers.Remove(container);
            await _context.SaveChangesAsync();

            return container;
        }

        private bool ContainerExists(Guid id)
        {
            return _context.Containers.Any(e => e.Unit_Id == id);
        }
    }
}
