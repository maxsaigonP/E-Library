using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Software_Requirement_Specification.Models;

namespace Software_Requirement_Specification.Areas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThacMacsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ThacMacsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ThacMacs
        [HttpGet]
        [Route("/xemthacmac")]
        public async Task<ActionResult<IEnumerable<ThacMac>>> GetThacMac()
        {

            return await _context.ThacMac.ToListAsync();
        }

        // GET: api/ThacMacs/5
        [HttpGet("{id}")]

        public async Task<ActionResult<ThacMac>> GetThacMac(int id)
        {
            var thacMac = await _context.ThacMac.FindAsync(id);

            if (thacMac == null)
            {
                return NotFound();
            }

            return thacMac;
        }

        // PUT: api/ThacMacs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThacMac(int id, ThacMac thacMac)
        {
            if (id != thacMac.Id)
            {
                return BadRequest();
            }

            _context.Entry(thacMac).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThacMacExists(id))
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

        // POST: api/ThacMacs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("/themthacmac")]
        public async Task<ActionResult<ThacMac>> PostThacMac([FromForm] ThacMac thacMac)
        {
            thacMac.TaiKhoanId = HttpContext.Session.GetString("Nd");
            _context.ThacMac.Add(thacMac);
            
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetThacMac", new { id = thacMac.Id }, thacMac);
        }

        // DELETE: api/ThacMacs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThacMac(int id)
        {
            var thacMac = await _context.ThacMac.FindAsync(id);
            if (thacMac == null)
            {
                return NotFound();
            }

            _context.ThacMac.Remove(thacMac);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ThacMacExists(int id)
        {
            return _context.ThacMac.Any(e => e.Id == id);
        }
    }
}
