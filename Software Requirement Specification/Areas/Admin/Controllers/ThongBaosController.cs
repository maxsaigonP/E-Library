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
    public class ThongBaosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ThongBaosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ThongBaos
        [HttpGet]
        [Route("/xemthongbao")]
        public async Task<ActionResult<IEnumerable<ThongBao>>> DsThongBao()
        {
            return await _context.ThongBao.ToListAsync();
        }

        [HttpGet]
        [Route("/locthongbao")]
        public async Task<ActionResult<IEnumerable<ThongBao>>> LocDsThongBao(int ?loai)
        {
            var result = await _context.ThongBao.ToListAsync();
            if(loai==0)
            {
                result = result.Where(t => t.LoaiThongBao == true).ToList();
            }else 
                if(loai==1)
            {
                result = result.Where(t => t.LoaiThongBao == false).ToList();
            }
            
            return result;
        }
        // GET: api/ThongBaos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ThongBao>> ThongBao(int id)
        {
            var thongBao = await _context.ThongBao.FindAsync(id);

            if (thongBao == null)
            {
                return NotFound();
            }

            return thongBao;
        }

        // PUT: api/ThongBaos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThongBao(int id, ThongBao thongBao)
        {
            if (id != thongBao.Id)
            {
                return BadRequest();
            }

            _context.Entry(thongBao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThongBaoExists(id))
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

        // POST: api/ThongBaos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("/admin/themthongbao")]
        public async Task<ActionResult<ThongBao>> ThemThongBao([FromForm] ThongBao thongBao)
        {
            thongBao.ThoiGian = DateTime.Now;
            thongBao.LoaiThongBao = false;
            _context.ThongBao.Add(thongBao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetThongBao", new { id = thongBao.Id }, thongBao);
        }

        // DELETE: api/ThongBaos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThongBao(int id)
        {
            var thongBao = await _context.ThongBao.FindAsync(id);
            if (thongBao == null)
            {
                return NotFound();
            }

            _context.ThongBao.Remove(thongBao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ThongBaoExists(int id)
        {
            return _context.ThongBao.Any(e => e.Id == id);
        }
    }
}
