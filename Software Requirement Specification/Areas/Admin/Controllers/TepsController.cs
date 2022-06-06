using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Software_Requirement_Specification.Models;

namespace Software_Requirement_Specification.Areas.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TepsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TepsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: api/Teps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tep>>> Tep()
        {
            return await _context.Tep.ToListAsync();
        }

        // GET: api/Teps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tep>> Tep(int id)
        {
            var tep = await _context.Tep.FindAsync(id);

            if (tep == null)
            {
                return NotFound();
            }

            return tep;
        }
        //
        [HttpGet]
        [Route("/admin/xemdstepriengtu")]
        public async Task<ActionResult<IEnumerable<Tep>>> XemTep()
        {
            var result = (from a in _context.Tep
                          where a.LoaiTep.Equals("Tệp riêng tư")
                          select new
                          {
                              TheLoai = a.TheLoai,
                              Ten = a.TenTep,
                              NguoiChinhSuaCuoi = a.NguoiChinhSua,
                              NgaySuaCuoi = a.NgaySuaCuoi,
                              KichThuc = a.KichThuoc
                          }).ToList();
            return Ok(result);
        }
        //
        [HttpGet]
        [Route("/admin/loctepriengtu")]
        public async Task<ActionResult<Tep>> LocTep(string loaiTep)
        {
            loaiTep = loaiTep.ToLower();
            var result = (from a in _context.Tep
                         where a.TheLoai.ToLower().Contains(loaiTep) && a.LoaiTep.Equals("Tệp riêng tư")
                         select new
                         {
                             TheLoai = a.TheLoai,
                             Ten = a.TenTep,
                             NguoiChinhSuaCuoi = a.NguoiChinhSua,
                             NgaySuaCuoi = a.NgaySuaCuoi,
                             KichThuc = a.KichThuoc
                         }).ToList();
            return Ok(result);
        }
        //
        [HttpGet]
        [Route("/admin/timtepriengtu")]
        public async Task<ActionResult<Tep>> TimTepRt(string txtSearch)
        {
            txtSearch = txtSearch.ToLower();
            var result = (from a in _context.Tep
                          where a.TenTep.ToLower().Contains(txtSearch) && a.LoaiTep.Equals("Tệp riêng tư")
                          select new {
                              TheLoai=a.TheLoai,
                              Ten=a.TenTep,
                              NguoiChinhSuaCuoi=a.NguoiChinhSua,
                              NgaySuaCuoi=a.NgaySuaCuoi,
                              KichThuc=a.KichThuoc
                          }).ToList();
            return Ok(result);
        }

        // PUT: api/Teps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> SuaTep(int id, string tenTep)
        {
            var tep = await _context.Tep.FindAsync(id);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TepExists(id))
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

   

        // POST: api/Teps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("/admin/themtepriengtu")]
        public async Task<ActionResult<Tep>> ThemTep([FromForm] Tep tep)
        {
            //if(HttpContext.Session.GetString("Id")==null)
            //{
            //    return NoContent();
            //}
           // int a = int.Parse(HttpContext.Session.GetString("Id"));
            tep.NguoiChinhSua = "";
            tep.NgaySuaCuoi = DateTime.Now;
            tep.LoaiTep = "Tệp riêng tư";



            if (tep.FileTep != null)
            {
                var fileName =Path.GetFileName(tep.FileTep.FileName);
                var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "tep");
                var filePath = Path.Combine(uploadPath, fileName);
                using (FileStream fs = System.IO.File.Create(filePath))
                {
                    tep.FileTep.CopyTo(fs);
                    fs.Flush();
                }
                tep.TenTep = fileName;
                string c = tep.FileTep.Length.ToString();
                tep.KichThuoc = int.Parse(c);
                tep.FileTep = tep.FileTep;
                tep.TheLoai = Path.GetExtension(tep.FileTep.FileName).Substring(1, Path.GetExtension(tep.FileTep.FileName).Length-1);
                _context.Tep.Add(tep);

            }
            await _context.SaveChangesAsync();
            var tb = new ThongBao();
            tb.LoaiThongBao = true;
            tb.TaiKhoanId = "";
            tb.NoiDung = "X đã thêm một tệp riêng tư ";
            tb.ChuDe = "Thêm tệp riêng tư";
            tb.DoiTuong = 2;
            tb.ThoiGian = DateTime.Now;
            _context.Add(tb);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Tep", new { id = tep.Id }, tep);
        }

        // DELETE: api/Teps/5
        [HttpDelete]
        [Route("/admin/xoatepriengtu/{id}")]
        public async Task<IActionResult> XoaTep(int id)
        {
            var tep = await _context.Tep.FindAsync(id);
            if (tep == null)
            {
                return NotFound();
            }

            _context.Tep.Remove(tep);
            //xoa file
            var filex = Path.Combine(_webHostEnvironment.WebRootPath, "tep", tep.TenTep);
            if (filex!=null)
            {
                var fileDelete = Path.Combine(_webHostEnvironment.WebRootPath, "tep", tep.TenTep);
                FileInfo file = new FileInfo(fileDelete);
                file.Delete();
            }
            await _context.SaveChangesAsync();

            var tb = new ThongBao();
            tb.LoaiThongBao = true;
            tb.TaiKhoanId = "";
            tb.NoiDung = HttpContext.Session.GetString("Ten") + " đã xoá một tệp riêng tư";
            tb.ChuDe = "Xoá tệp riêng tư";
            tb.DoiTuong = 2;
            tb.ThoiGian = DateTime.Now;
            _context.Add(tb);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TepExists(int id)
        {
            return _context.Tep.Any(e => e.Id == id);
        }
    }
}
