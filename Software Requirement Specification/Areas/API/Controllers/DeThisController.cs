using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Software_Requirement_Specification.Data;
using Software_Requirement_Specification.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Software_Requirement_Specification.Areas.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DeThisController : ControllerBase
    {
        private readonly Software_Requirement_SpecificationContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DeThisController(Software_Requirement_SpecificationContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: api/DeThis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeThi>>> DeThi()
        {
            return await _context.DeThi.ToListAsync();
        }

        // GET: api/DeThis/5
        [HttpGet]
        [Route("/admin/chitietdethi/{id}")]
        public async Task<ActionResult<DeThi>> DeThi(int id)
        {
            var deThi = await _context.DeThi.FindAsync(id);

            var result = (from a in _context.DeThi
                          where a.Id==id
                          select new { 
                              MonHoc=a.MonHoc.TenMonHoc,
                              ThoiLuong=a.ThoiLuong,
                              TenDeThi=a.TenDeThi,
                              HinhThuc=a.HinhThuc,
                              GiaoVienDaoTao=a.NguoiDung.Ten
                          }).ToList();

            if (deThi == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        //chitiet

        [HttpGet]
        [Route("/admin/chitietdethi")]
        public async Task<ActionResult> ChiTietDeThi(int deThi)
        {
            var a1 = (from a in _context.DeThi
                      join b in _context.NguoiDung on a.NguoiDungId equals b.Id
                      join c in _context.MonHoc on a.MonHocId equals c.Id
                      where a.Id==deThi
                      select new
                      {
                          TenDeThi = a.TenDeThi,
                          MonHoc = c.TenMonHoc,
                          GiangVien = b.Ten,
                          HinhThuc = a.HinhThuc,
                          ThoiLuong = a.ThoiLuong,
                          NgayTao = a.NgayTao,
                          TinhTrang = a.TinhTrang

                      }).ToList();
            return Ok(a1);
        }
        //Duyet
        [HttpGet]
        [Route("/admin/duyetdethi")]
        public async Task<ActionResult<DeThi>> DuyetDeThi(int id)
        {
            var deThi = await _context.DeThi.FindAsync(id);
            if (deThi == null || HttpContext.Session.GetInt32("VaiTro") != 1)
            {
                return NotFound();
            }
            deThi.TinhTrang = true;
            deThi.NguoiPheDuyet = int.Parse(HttpContext.Session.GetString("Id"));
            _context.Update(deThi);
            await _context.SaveChangesAsync();
            return deThi;
        }
        //Duyet
        [HttpGet]
        [Route("/admin/huyduyetdethi")]
        public async Task<ActionResult<DeThi>> HuyDuyetDeThi(int id)
        {
            var deThi = await _context.DeThi.FindAsync(id);
            if (deThi == null || HttpContext.Session.GetInt32("VaiTro") != 1)
            {
                return NotFound();
            }
            deThi.TinhTrang = false;
            deThi.NguoiPheDuyet = int.Parse(HttpContext.Session.GetString("Id"));
            _context.Update(deThi);
            await _context.SaveChangesAsync();
            return deThi;
        }

        //

        [HttpGet]
        [Route("/admin/NganHangDethi")]
        public async Task<ActionResult> NganHangDeThi() //admin
        {

            var a1 = (from a in _context.DeThi
                      join b in _context.NguoiDung on a.NguoiDungId equals b.Id
                      join c in _context.MonHoc on a.MonHocId equals c.Id
                      select new
                      {
                          LoaiFile=a.Tep.TheLoai,
                          TenDeThi = a.TenDeThi,
                          MonHoc = c.TenMonHoc,
                          GiangVien = b.Ten,
                          HinhThuc = a.HinhThuc,
                          ThoiLuong = a.ThoiLuong,
                          TinhTrang = a.TinhTrang

                      }).ToList();

            return Ok(a1);
        }
        //
        [HttpGet]
        [Route("/teacher/DsDethi")]
        public async Task<ActionResult> DsDeThi() //admin
        {

            var a1 = (from a in _context.DeThi
                      join b in _context.NguoiDung on a.NguoiDungId equals b.Id
                      select new
                      {
                          LoaiFile = a.Tep.TheLoai,
                          TenDeThi = a.TenDeThi,
                          ThoiLuong = a.ThoiLuong,
                          ThoiGianTao = a.NgayTao,
                          TinhTrang = a.TinhTrang

                      }).ToList();

            return Ok(a1);
        }
        //
        [HttpGet]
        [Route("/teacher/timdethi")]
        public async Task<ActionResult> TimDeThiKt(string txtSearch)
        {

            var a1 = (from a in _context.DeThi
                      join b in _context.NguoiDung on a.NguoiDungId equals b.Id
                      join c in _context.MonHoc on a.MonHocId equals c.Id
                      where a.TenDeThi.Contains(txtSearch) || c.TenMonHoc.Contains(txtSearch)
                      select new
                      {
                          LoaiFile = a.Tep.TheLoai,
                          TenDeThi = a.TenDeThi,
                          MonHoc = c.TenMonHoc,
                          GiangVien = b.Ten,
                          HinhThuc = a.HinhThuc,
                          ThoiLuong = a.ThoiLuong,
                          TinhTrang = a.TinhTrang

                      }).ToList();

            return Ok(a1);
        }
        //
        [HttpGet]
        [Route("/admin/timdethi")]
        public async Task<ActionResult> TimDeThi(string txtSearch)
        {

            var a1 = (from a in _context.DeThi
                      join b in _context.NguoiDung on a.NguoiDungId equals b.Id
                      join c in _context.MonHoc on a.MonHocId equals c.Id
                      where a.TenDeThi.Contains(txtSearch) || c.TenMonHoc.Contains(txtSearch)
                      select new
                      {
                          LoaiFile = a.Tep.TheLoai,
                          TenDeThi = a.TenDeThi,
                          MonHoc = c.TenMonHoc,
                          GiangVien = b.Ten,
                          HinhThuc = a.HinhThuc,
                          ThoiLuong = a.ThoiLuong,
                          TinhTrang = a.TinhTrang

                      }).ToList();

            return Ok(a1);
        }
        //
        [HttpGet]
        [Route("/teacher/locdsdethi")]
        public async Task<ActionResult> LocDsDethi(int bomon,int mon)
        {
            var x = await _context.BoMon.FindAsync(bomon);

            var result = (from a in _context.DeThi
                          join b in _context.MonHoc on a.MonHocId equals b.Id
                          where b.BoMonId == bomon
                          select new
                          {
                              LoaiFile = a.Tep.TheLoai,
                              TenDeThi = a.TenDeThi,
                              ThoiLuong = a.ThoiLuong,
                              ThoiGianTao = a.NgayTao,
                              TinhTrang = a.TinhTrang
                          }).ToList();

            return Ok(result);
        }
        //
        [HttpGet]
        [Route("/admin/locdsdethi")]
        public async Task<ActionResult<IEnumerable<DeThi>>> LocDeThi(int? tt, string nk, int mh, int gv)
        {

            if(nk==null)
            {
                nk = (DateTime.Now.Year-1).ToString() + "-" + DateTime.Now.Year.ToString();
            }


            var result = await _context.DeThi.Where(t=>t.NienKhoa.Equals(nk)).ToListAsync();
            if (gv != 0 && mh != 0)
            {
                result = await _context.DeThi.Where(t => t.NguoiDungId == gv && t.MonHocId == mh && t.NienKhoa.Equals(nk)).ToListAsync();
            }
            else
            if (mh != 0)
            {
                result = await _context.DeThi.Where(t => t.MonHocId == mh && t.NienKhoa.Equals(nk)).ToListAsync();
            }
            else
            if (gv != 0)
            {
                result = await _context.DeThi.Where(t => t.NguoiDungId == gv && t.NienKhoa.Equals(nk)).ToListAsync();
            }

            if (tt != null)
            {
                result = result.Where(t => t.TinhTrang == (tt != 0) ? true : false && t.NienKhoa.Equals(nk)).ToList();
            }
       

            return result;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> SuaDeThi(int id,[FromBody] DeThi deThi)
        {
            if (id != deThi.Id)
            {
                return BadRequest();
            }

            _context.Entry(deThi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeThiExists(id))
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
        //tai de

        [HttpGet]
        [Route("/taide")]
        public async Task<ActionResult> TaiDeThi(int id)
        {
            string remoteUri = Path.Combine(_webHostEnvironment.WebRootPath, "tep\\");
            var find =  _context.DeThi.Find(id);
            var _from = await _context.Tep.FindAsync(find.TepId);
            string fileName = _from.TenTep;
  
            WebClient myWebClient = new WebClient();
         
            string   myStringWebResource = remoteUri + fileName;
        
            myWebClient.DownloadFile(myStringWebResource, fileName);

            return Ok("Da tai xuong de thi ");
        }

        // POST: api/DeThis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("/teacher/tailende")]
        public async Task<ActionResult<DeThi>> TaiLenDeThi([FromForm] DeThi deThi, [FromForm] Tep tep)
        {
            tep.NguoiChinhSua = 1;
            tep.NgaySuaCuoi = DateTime.Now;
            tep.LoaiTep = "Tài liệu";
            


            if (tep.FileTep != null)
            {
                var fileName = deThi.TenDeThi + Path.GetExtension(tep.FileTep.FileName);
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
                tep.TheLoai = Path.GetExtension(tep.FileTep.FileName);
                _context.Tep.Add(tep);

            }
            await _context.SaveChangesAsync();
            //
          
   
            deThi.NguoiPheDuyet = 0;
            deThi.NgayTao = DateTime.Now;
            deThi.TepId = tep.Id;
            deThi.TinhTrang = false;
            deThi.NguoiDungId= int.Parse(HttpContext.Session.GetString("Nd"));
            _context.DeThi.Add(deThi);
            await _context.SaveChangesAsync();
            //
            var tb = new ThongBao();
            tb.LoaiThongBao = true;
            tb.NguoiDungId = int.Parse(HttpContext.Session.GetString("Nd")); //login
            tb.NoiDung = "X đã tải lên một đề thi";
            tb.ThoiGian = DateTime.Now;
            _context.Add(tb);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeThi", new { id = deThi.Id }, deThi);
        }

        // DELETE: api/DeThis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> XoaDeThi(int id)
        {
            var deThi = await _context.DeThi.FindAsync(id);
            if (deThi == null)
            {
                return NotFound();
            }

            _context.DeThi.Remove(deThi);
            await _context.SaveChangesAsync();
            //
            var tb = new ThongBao();
            tb.LoaiThongBao = true;
            tb.NguoiDungId = 1;
            tb.NoiDung = "X đã xoá một đề thi";
            tb.ThoiGian = DateTime.Now;
            _context.Add(tb);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeThiExists(int id)
        {
            return _context.DeThi.Any(e => e.Id == id);
        }
    }
}
