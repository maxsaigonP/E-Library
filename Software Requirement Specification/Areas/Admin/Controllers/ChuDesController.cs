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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChuDesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ChuDesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChuDe>>> DsChuDe()
        {
            return await _context.ChuDe.ToListAsync();
        }

      
        [HttpGet("{id}")]
        public async Task<ActionResult<ChuDe>> ChiTietChuDe(int id)
        {
            var chuDe = await _context.ChuDe.FindAsync(id);

            if (chuDe == null)
            {
                return NotFound();
            }

            return chuDe;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutChuDe(int id, ChuDe chuDe)
        {
            if (id != chuDe.Id)
            {
                return BadRequest();
            }

            _context.Entry(chuDe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
               
            }

            return NoContent();
        }

        // POST: api/ChuDes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChuDe>> ThemChuDe([FromForm] ChuDe chuDe)
        {
            _context.ChuDe.Add(chuDe);
            await _context.SaveChangesAsync();
            var tb = new ThongBao();
            tb.LoaiThongBao = true;
            tb.TaiKhoanId = "";
            tb.NoiDung = "X đã thêm một chủ đề";
            tb.ThoiGian = DateTime.Now;
            _context.Add(tb);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChuDe", new { id = chuDe.Id }, chuDe);
        }

        // DELETE: api/ChuDes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> XoaChuDe(int id)
        {
            var chuDe = await _context.ChuDe.FindAsync(id);
            if (chuDe == null)
            {
                return NotFound();
            }

            _context.ChuDe.Remove(chuDe);
            await _context.SaveChangesAsync();
            var tb = new ThongBao();
            tb.LoaiThongBao = false;
            tb.TaiKhoanId = "";
            tb.NoiDung = "X đã xoá một chủ đề";
            tb.ThoiGian = DateTime.Now;
            _context.Add(tb);
            await _context.SaveChangesAsync();
            return NoContent();
        }

      
    }
}
