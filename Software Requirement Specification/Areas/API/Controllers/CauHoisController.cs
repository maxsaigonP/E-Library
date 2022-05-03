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
    public class CauHoisController : ControllerBase
    {
        private readonly Software_Requirement_SpecificationContext _context;

        public CauHoisController(Software_Requirement_SpecificationContext context)
        {
            _context = context;
        }

        // GET: api/CauHois
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CauHoi>>> GetCauHoi()
        {
            return await _context.CauHoi.ToListAsync();
        }

        // GET: api/CauHois/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CauHoi>> GetCauHoi(int id)
        {
            var cauHoi = await _context.CauHoi.FindAsync(id);

            if (cauHoi == null)
            {
                return NotFound();
            }

            return cauHoi;
        }

        // PUT: api/CauHois/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCauHoi(int id, CauHoi cauHoi)
        {
            if (id != cauHoi.Id)
            {
                return BadRequest();
            }

            _context.Entry(cauHoi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CauHoiExists(id))
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

        // POST: api/CauHois
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("/teacher/themcauhoi")]
        public async Task<ActionResult<CauHoi>> ThemCauHoi([FromForm] CauHoi cauHoi, [FromForm] string[] dapAn, [FromForm] int dapAnDung)
        {
            _context.CauHoi.Add(cauHoi);
            await _context.SaveChangesAsync();

            for (int i = 0; i < dapAn.Count(); i++)
            {
                DapAn da = new DapAn();
                da.NoiDung = dapAn[i];
                da.CauHoiId = cauHoi.Id;
                if (dapAnDung != 0)
                {
                    if (dapAnDung - 1 == i)
                    {
                        da.Dung = true;
                    }
                    else
                    {
                        da.Dung = false;
                    }
                }
                else
                {
                    da.Dung = true;
                }

                _context.DapAn.Add(da);
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetCauHoi", new { id = cauHoi.Id }, cauHoi);

        }

        // DELETE: api/CauHois/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCauHoi(int id)
        {
            var cauHoi = await _context.CauHoi.FindAsync(id);
            if (cauHoi == null)
            {
                return NotFound();
            }

            _context.CauHoi.Remove(cauHoi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CauHoiExists(int id)
        {
            return _context.CauHoi.Any(e => e.Id == id);
        }
    }
}
