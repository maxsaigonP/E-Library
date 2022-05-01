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
    public class NguoiDungsController : ControllerBase
    {
        private readonly Software_Requirement_SpecificationContext _context;

        public NguoiDungsController(Software_Requirement_SpecificationContext context)
        {
            _context = context;
        }

        // GET: api/NguoiDungs
        [HttpGet]
        [Route("/admin/dsnguoidung")]
        public async Task<ActionResult> NguoiDung()
        {
            var result = (from a in _context.NguoiDung
                          select new {
                              MaNguoiDung=a.Id,
                              Ten=a.Ten,
                              Email=a.Email,
                              TenVaiTro=a.VaiTro.TenVaiTro
                          }).ToList();
            return Ok(result);
        }

        // GET: api/NguoiDungs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NguoiDung>> NguoiDung(int id)
        {
            var nguoiDung = await _context.NguoiDung.FindAsync(id);

            if (nguoiDung == null)
            {
                return NotFound();
            }

            return nguoiDung;
        }
        [HttpGet]
        [Route("/admin/locnguoidung")]
        public async Task<ActionResult<IEnumerable<NguoiDung>>> LocNguoiDung(int vaiTro)
        {
      
               var  result = (from a in _context.NguoiDung
                              where a.VaitroId==vaiTro
                          select new
                          {
                              MaNguoiDung = a.Id,
                              Ten = a.Ten,
                              Email = a.Email,
                              TenVaiTro = a.VaiTro.TenVaiTro
                          }).ToList();
            return Ok(result);
        }
        [HttpGet]
        [Route("/admin/timkiemnguoidung")]
        public async Task<ActionResult<IEnumerable<NguoiDung>>> SearchNguoiDung(string txtSearch)
        {
            var result = (from a in _context.NguoiDung
                          join x in _context.LopHoc on a.LopHocId equals x.Id
                          where a.Ten.Contains(txtSearch) || x.TenLop.Contains(txtSearch)
                          select new
                          {
                              MaNguoiDung = a.Id,
                              Ten = a.Ten,
                              Email = a.Email,
                              TenVaiTro = a.VaiTro.TenVaiTro
                          }).ToList();
            return Ok(result);
        }

        // PUT: api/NguoiDungs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("/admin/suanguoidung/{id}")]
        public async Task<IActionResult> SuaNguoiDung(int id,[FromBody] NguoiDung nguoiDung)
        {
            if (id != nguoiDung.Id)
            {
                return BadRequest();
            }

            _context.Entry(nguoiDung).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NguoiDungExists(id))
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

        // POST: api/NguoiDungs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("/admin/themnguoidung")]
        public async Task<ActionResult<NguoiDung>> ThemNguoiDung([FromBody] NguoiDung nguoiDung)
        {
            var check = await _context.NguoiDung.Where(n => n.Email == nguoiDung.Email || n.SoDienThoai == nguoiDung.SoDienThoai).ToListAsync();
            if(check.Count==0)
            {
                _context.NguoiDung.Add(nguoiDung);
                await _context.SaveChangesAsync();
                NguoiDungMonHoc ndmh = new NguoiDungMonHoc();
                try
                {
                    ndmh.NguoiDungId = nguoiDung.Id;
                    ndmh.MonHocId = nguoiDung.MonHocId;
                    _context.NguoiDungMonHoc.Add(ndmh);
                    await _context.SaveChangesAsync();
                    return Ok("Thanh cong");
                }
                catch (Exception e)
                {
                    return NotFound();
                }
            }else
            {
                return Ok("Trung email hoac so dien thoai");
            }
           
          
            
        }

        // DELETE: api/NguoiDungs/5
        [HttpDelete]
        [Route("/admin/xoanguoidung/{id}")]
        public async Task<IActionResult> XoaNguoiDung(int id)
        {
            var nguoiDung = await _context.NguoiDung.FindAsync(id);
            if (nguoiDung == null)
            {
                return NotFound();
            }

            _context.NguoiDung.Remove(nguoiDung);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NguoiDungExists(int id)
        {
            return _context.NguoiDung.Any(e => e.Id == id);
        }
    }
}
