using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Software_Requirement_Specification.Data;
using Software_Requirement_Specification.Models;

namespace Software_Requirement_Specification.Areas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DapAnsController : ControllerBase
    {
        private readonly Software_Requirement_SpecificationContext _context;

        public DapAnsController(Software_Requirement_SpecificationContext context)
        {
            _context = context;
        }

        // GET: api/DapAns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DapAn>>> GetDapAn()
        {
            return await _context.DapAn.ToListAsync();
        }

        // GET: api/DapAns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DapAn>> GetDapAn(int id)
        {
            var dapAn = await _context.DapAn.FindAsync(id);

            if (dapAn == null)
            {
                return NotFound();
            }

            return dapAn;
        }

        // PUT: api/DapAns/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDapAn(int id, DapAn dapAn)
        {
            if (id != dapAn.Id)
            {
                return BadRequest();
            }

            _context.Entry(dapAn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DapAnExists(id))
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

        // POST: api/DapAns
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DapAn>> PostDapAn(DapAn dapAn)
        {
            _context.DapAn.Add(dapAn);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDapAn", new { id = dapAn.Id }, dapAn);
        }

        // DELETE: api/DapAns/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDapAn(int id)
        {
            var dapAn = await _context.DapAn.FindAsync(id);
            if (dapAn == null)
            {
                return NotFound();
            }

            _context.DapAn.Remove(dapAn);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DapAnExists(int id)
        {
            return _context.DapAn.Any(e => e.Id == id);
        }
    }
}
