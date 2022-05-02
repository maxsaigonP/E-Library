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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HoisController : ControllerBase
    {
        private readonly Software_Requirement_SpecificationContext _context;

        public HoisController(Software_Requirement_SpecificationContext context)
        {
            _context = context;
        }

        // GET: api/Hois
        [HttpGet]
        [Route("/dscauhoi")]
        public async Task<ActionResult> DsCauHoi()
        {
            

            var result = (from a in _context.Hoi
                          join b in _context.TaiLieu on a.TaiLieuId equals b.Id
                          select new
                          {
                              MonHoc=a.MonHoc.TenMonHoc,
                              BaiGiang=b.TieuDe,
                              CauHoi=a.NoiDung
                          }).ToListAsync();
            return Ok(result);
        }

        // GET: api/Hois/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hoi>> GetHoi(int id)
        {
            var hoi = await _context.Hoi.FindAsync(id);

            if (hoi == null)
            {
                return NotFound();
            }

            return hoi;
        }

        // PUT: api/Hois/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHoi(int id, Hoi hoi)
        {
            if (id != hoi.Id)
            {
                return BadRequest();
            }

            _context.Entry(hoi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoiExists(id))
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

        // POST: api/Hois
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("/themcauhoi")]
        public async Task<ActionResult<Hoi>> PostHoi([FromForm] Hoi hoi)
        {
            _context.Hoi.Add(hoi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHoi", new { id = hoi.Id }, hoi);
        }

        // DELETE: api/Hois/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHoi(int id)
        {
            var hoi = await _context.Hoi.FindAsync(id);
            if (hoi == null)
            {
                return NotFound();
            }

            _context.Hoi.Remove(hoi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HoiExists(int id)
        {
            return _context.Hoi.Any(e => e.Id == id);
        }
    }
}
