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
    public class DetailsController : ControllerBase
    {
        private readonly ShipmentContext _context;

        public DetailsController(ShipmentContext context)
        {
            _context = context;
        }

        // GET: api/Details
        [HttpGet]
        [ProducesResponseType(typeof(Detail), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<Detail>>> GetDetails()
        {
            return await _context.Details.ToListAsync();
        }

        // GET: api/Details/5
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(Detail), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Detail>> GetDetail(Guid id)
        {
            var detail = await _context.Details.FindAsync(id);

            if (detail == null)
            {
                return NotFound();
            }

            return detail;
        }

        // PUT: api/Details/5
        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(Detail), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutDetail(Guid id, Detail detail)
        {
            if (id != detail.Detail_Id)
            {
                return BadRequest();
            }

            _context.Entry(detail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetailExists(id))
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

        // POST: api/Details
        [HttpPost]
        [ProducesResponseType(typeof(Detail), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Detail>> PostDetail(Detail detail)
        {
            _context.Details.Add(detail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetail", new { id = detail.Detail_Id }, detail);
        }

        // DELETE: api/Details/5
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(Detail), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Detail>> DeleteDetail(Guid id)
        {
            var detail = await _context.Details.FindAsync(id);
            if (detail == null)
            {
                return NotFound();
            }

            _context.Details.Remove(detail);
            await _context.SaveChangesAsync();

            return detail;
        }

        private bool DetailExists(Guid id)
        {
            return _context.Details.Any(e => e.Detail_Id == id);
        }
    }
}
