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
    public class VaiTroesController : ControllerBase
    {
        private readonly Software_Requirement_SpecificationContext _context;

        public VaiTroesController(Software_Requirement_SpecificationContext context)
        {
            _context = context;
        }

        // GET: api/VaiTroes
        [HttpGet]
        [Route("/admin/xemnhomnguoidung")]
        public async Task<ActionResult<IEnumerable<VaiTro>>> VaiTro()
        {
            var result = (from a in _context.VaiTro
                          select new {
                              TenNhom=a.TenVaiTro,
                              MoTa=a.MoTa,
                              NgayCapNhatCuoi=a.NgayCapNhatCuoi
                          }).ToList();
            return Ok(result);
        }

        // GET: api/VaiTroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VaiTro>> VaiTro(int id)
        {
            var vaiTro = await _context.VaiTro.FindAsync(id);

            if (vaiTro == null)
            {
                return NotFound();
            }

            return vaiTro;
        }

        // PUT: api/VaiTroes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> SuaVaiTro(int id, [FromBody] VaiTro vaiTro)
        {
            if (id != vaiTro.Id)
            {
                return BadRequest();
            }

            _context.Entry(vaiTro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VaiTroExists(id))
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
      
        [HttpPost]
        [Route("/admin/themvaitro")]
        public async Task<ActionResult<VaiTro>> ThemVaiTro([FromForm] VaiTro vaiTro, [FromForm] int[] phanQuyen)
        {
            vaiTro.NgayCapNhatCuoi = DateTime.Now;
            _context.VaiTro.Add(vaiTro);
            await _context.SaveChangesAsync();
           
            if (phanQuyen.Count() > 0)
            {
                foreach (int a in phanQuyen)
                {
                    var pq = new VaiTroPhanQuyen();
                    pq.VaiTroId = vaiTro.Id;
                    pq.PhanQuyenId = a;
                    _context.VaiTroPhanQuyen.Add(pq);
                    await _context.SaveChangesAsync();
                }
                return Ok("Cai dat thanh cong");
            }

            return CreatedAtAction("GetVaiTro", new { id = vaiTro.Id }, vaiTro);
        }
        [HttpPost]
        [Route("/admin/caidatvaitro")]
        public async Task<ActionResult<VaiTro>> CaiDatVaiTro([FromForm] int[] phanQuyen,[FromForm] int vaiTro)
        {
            var sl = await _context.VaiTroPhanQuyen.Where(v => v.VaiTroId == vaiTro).ToListAsync();
            foreach (var x in sl)
            {
                _context.VaiTroPhanQuyen.Remove(x);
                await _context.SaveChangesAsync();
            }
            if (phanQuyen.Count()>0)
            {
                foreach(int a in phanQuyen)
                {
                    var pq = new VaiTroPhanQuyen();
                    pq.VaiTroId = vaiTro;
                    pq.PhanQuyenId = a;
                    _context.VaiTroPhanQuyen.Add(pq);
                    await _context.SaveChangesAsync();
                }
                var vt = await _context.VaiTro.FindAsync(vaiTro);
                vt.NgayCapNhatCuoi = DateTime.Now;
                _context.Update(vt);
                await _context.SaveChangesAsync();
                return Ok("Cai dat thanh cong");
            }
            return NoContent();
        }

        // DELETE: api/VaiTroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> XoaVaiTro(int id)
        {
            var vaiTro = await _context.VaiTro.FindAsync(id);
            if (vaiTro == null)
            {
                return NotFound();
            }

            _context.VaiTro.Remove(vaiTro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VaiTroExists(int id)
        {
            return _context.VaiTro.Any(e => e.Id == id);
        }
    }
}
