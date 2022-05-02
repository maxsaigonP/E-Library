using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Software_Requirement_Specification.Data;
using Software_Requirement_Specification.Models;

namespace Software_Requirement_Specification.Areas.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaiLieuxController : ControllerBase
    {
        private readonly Software_Requirement_SpecificationContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TaiLieuxController(Software_Requirement_SpecificationContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: api/TaiLieux
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaiLieu>>> TaiLieu()
        {
            return await _context.TaiLieu.ToListAsync();
        }

        // GET: api/TaiLieux/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaiLieu>> TaiLieu(int id)
        {
            var taiLieu = await _context.TaiLieu.FindAsync(id);

            if (taiLieu == null)
            {
                return NotFound();
            }

            return taiLieu;
        }
        //
        [HttpGet]
        [Route("/dstailieu")]
        public async Task<ActionResult> DsTaiLieu()
        {
            var result = (from a in _context.TaiLieu
                          join b in _context.Tep on a.TepId equals b.Id
                          select new
                          {
                              
                              TenTaiLieu=a.TenTaiLieu,
                              PhanLoai=a.LoaiTaiLieu,
                             NgayGuiPheDuyet=a.NgayGuiPheDuyet,
                             TinhTrangPheDuyet=a.TinhTrang,
                             GhiChu=a.GhiChu,
                             SoTaiLieuChoDuyet=(from c in _context.TaiLieu select c).Count()
                              

                          }).ToList();
            return Ok(result);
        }
        //
        [HttpGet]
        [Route("/timkiemtailieu")]

        public async Task<ActionResult> TimKiemTaiLieu(string txtSearch)
        {
            var result = (from a in _context.TaiLieu
                          join x in _context.LopHocMonHoc on a.MonHocId equals x.MonHocId
                          where a.TieuDe.Contains(txtSearch) || x.LopHoc.TenLop.Contains(txtSearch) || a.MonHoc.TenMonHoc.Contains(txtSearch)
                          select new
                          {

                              TenTaiLieu = a.TenTaiLieu,
                              PhanLoai = a.LoaiTaiLieu,
                              NgayGuiPheDuyet = a.NgayGuiPheDuyet,
                              TinhTrangPheDuyet = a.TinhTrang,
                              GhiChu = a.GhiChu,
                              SoTaiLieuChoDuyet = (from c in _context.TaiLieu select c).Count()


                          }).ToList();
            return Ok(result);
        }
        //
        [HttpGet]
        [Route("/teacher/dsbaigiang")]
        public async Task<ActionResult> DsBaiGiang()
        {
            var result = (from a in _context.TaiLieu
                          join b in _context.Tep on a.TepId equals b.Id
                          where a.LoaiTaiLieu=="Bài giảng"
                          select new
                          {
                              TheLoai = b.TheLoai,
                              Ten = a.TenTaiLieu,
                              Mon = a.MonHoc.TenMonHoc,
                              NguoiChinhSua = b.NguoiChinhSua,
                              NguoiChinhSuaCuoi = a.NguoiChinhSuaCuoi,
                              KichThuoc = b.KichThuoc

                          }).ToList();
            return Ok(result);
        }
        //
        [HttpGet]
        [Route("/teacher/locdsbaigiang")]
        public async Task<ActionResult> LocDsBaiGiang(int mh)
        {
            var result = (from a in _context.TaiLieu
                          join b in _context.Tep on a.TepId equals b.Id
                          where a.LoaiTaiLieu == "Bài giảng" && a.MonHocId==mh
                          select new
                          {
                              TheLoai = b.TheLoai,
                              Ten = a.TenTaiLieu,
                              Mon = a.MonHoc.TenMonHoc,
                              NguoiChinhSua = b.NguoiChinhSua,
                              NguoiChinhSuaCuoi = a.NguoiChinhSuaCuoi,
                              KichThuoc = b.KichThuoc

                          }).ToList();
            return Ok(result);
        }
        //
        [HttpGet]
        [Route("/timkiembaigiang")]
        public async Task<ActionResult> SearchTaiLieu(string txtSearch)
        {
            txtSearch = txtSearch.ToLower();

            var taiLieu = await _context.TaiLieu.Where(m => m.MonHoc.TenMonHoc.Contains(txtSearch) || m.TieuDe.ToLower().Contains(txtSearch)).ToListAsync();
            var result = (from a in taiLieu
                          where a.LoaiTaiLieu=="Bài giảng"
                          select new
                          {
                              TenTaiLieu = a.TenTaiLieu,
                              PhanLoai = a.LoaiTaiLieu,
                              NgayGuiPheDuyet = a.NgayGuiPheDuyet,
                              TinhTrangPheDuyet = a.TinhTrang,
                              GhiChu = a.GhiChu
                          }).ToList();
            return Ok(result);
        }
        //a

        //
        [HttpGet]
        [Route("/teacher/dstainguyen")]
        public async Task<ActionResult> DsTaiNguyen()
        {
            var result = (from a in _context.TaiLieu
                          join b in _context.Tep on a.TepId equals b.Id
                          where a.LoaiTaiLieu == "Tài nguyên"
                          select new
                          {
                              TheLoai = b.TheLoai,
                              Ten = a.TenTaiLieu,
                              Mon = a.MonHoc.TenMonHoc,
                              NguoiChinhSua = b.NguoiChinhSua,
                              NguoiChinhSuaCuoi = a.NguoiChinhSuaCuoi,
                              KichThuoc = b.KichThuoc

                          }).ToList();
            return Ok(result);
        }
        //
        [HttpGet]
        [Route("/teacher/locdstainguyen")]
        public async Task<ActionResult> LocDsTaiNguyen(int mh)
        {
            var result = (from a in _context.TaiLieu
                          join b in _context.Tep on a.TepId equals b.Id
                          where a.LoaiTaiLieu == "Tài nguyên" && a.MonHocId == mh
                          select new
                          {
                              TheLoai = b.TheLoai,
                              Ten = a.TenTaiLieu,
                              Mon = a.MonHoc.TenMonHoc,
                              NguoiChinhSua = b.NguoiChinhSua,
                              NguoiChinhSuaCuoi = a.NguoiChinhSuaCuoi,
                              KichThuoc = b.KichThuoc

                          }).ToList();
            return Ok(result);
        }
        //
        [HttpGet]
        [Route("/timkiemtainguyen")]
        public async Task<ActionResult> SearchTaiNguyen(string txtSearch)
        {
            var taiLieu = await _context.TaiLieu.Where(m => m.MonHoc.TenMonHoc.Contains(txtSearch) || m.TieuDe.Contains(txtSearch)).ToListAsync();
            var result = (from a in taiLieu
                          where a.LoaiTaiLieu == "Tài nguyên"
                          select new
                          {
                              TenTaiLieu = a.TenTaiLieu,
                              PhanLoai = a.LoaiTaiLieu,
                              NgayGuiPheDuyet = a.NgayGuiPheDuyet,
                              TinhTrangPheDuyet = a.TinhTrang,
                              GhiChu = a.GhiChu
                          }).ToList();
            return Ok(result);
        }
        //
        //a
        [HttpGet]
        public async Task<ActionResult> DsTepRiengTu()
        {
            var result = (from a in _context.TaiLieu
                          join b in _context.Tep on a.TepId equals b.Id
                          where a.LoaiTaiLieu == "Tệp riêng tư"
                          select new
                          {
                              TheLoai = b.TheLoai,
                              Ten = a.TenTaiLieu,
                              Mon = a.MonHoc.TenMonHoc,
                              NguoiChinhSua = b.NguoiChinhSua,
                              NguoiChinhSuaCuoi = a.NguoiChinhSuaCuoi,
                              KichThuoc = b.KichThuoc

                          }).ToList();
            return Ok(result);
        }
        //
        //
        [HttpGet]
        [Route("/admin/loctailieu")]
        public async Task<ActionResult<IEnumerable<TaiLieu>>> LocTaiLieu(int? tt, int gv, int mh)
        {



            var result = await _context.TaiLieu.ToListAsync();
            if (gv != 0 && mh != 0)
            {
                result = await _context.TaiLieu.Where(t => t.NguoiDungId == gv && t.MonHocId == mh).ToListAsync();
            }
            else
            if (mh != 0)
            {
                result = await _context.TaiLieu.Where(t => t.MonHocId == mh).ToListAsync();
            }
            else
            if (gv != 0)
            {
                result = await _context.TaiLieu.Where(t => t.NguoiDungId == gv).ToListAsync();
            }

            if (tt != null)
            {
                result = result.Where(t => t.TinhTrang == (tt != 0) ? true : false).ToList();
            }

            return result;
        }
        [HttpGet]
        [Route("/teacher/loctailieu")]
        public async Task<ActionResult> LocTaiLieut(int? tt)
        {
            var result = (from a in _context.TaiLieu
                          select new
                          {
                              TenTaiLieu = a.TenTaiLieu,
                              PhanLoai = a.LoaiTaiLieu,
                              NgayGuiPheDuyet = a.NgayGuiPheDuyet,
                              TinhTrangPheDuyet = a.TinhTrang,
                              GhiChu = a.GhiChu
                          }).ToList();

            if (tt!=null)
            {
                result = (from a in _context.TaiLieu
                          where a.TinhTrang == (tt == 0) ? false : true
                          select new
                          {
                              TenTaiLieu = a.TenTaiLieu,
                              PhanLoai = a.LoaiTaiLieu,
                              NgayGuiPheDuyet = a.NgayGuiPheDuyet,
                              TinhTrangPheDuyet = a.TinhTrang,
                              GhiChu = a.GhiChu
                          }).ToList();
                
            }
            return Ok(result);




        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaiLieu>>> LocTepRiengTu(int ?tt, int gv, int mh)
        {
           
         

            var result = await _context.TaiLieu.ToListAsync();
            if (gv!=0&&mh!=0)
            {
                result = await _context.TaiLieu.Where(t => t.NguoiDungId == gv&& t.MonHocId == mh&& t.LoaiTaiLieu=="Tệp riêng tư").ToListAsync();
            }else
            if(mh!=0)
            {
                result = await _context.TaiLieu.Where(t => t.MonHocId == mh && t.LoaiTaiLieu == "Tệp riêng tư").ToListAsync();
            }else
            if (gv != 0)
            {
                result = await _context.TaiLieu.Where(t => t.NguoiDungId == gv && t.LoaiTaiLieu == "Tệp riêng tư").ToListAsync();
            }

            if(tt!=null)
            {
                result = result.Where(t => t.TinhTrang == (tt != 0) ? true : false && t.LoaiTaiLieu == "Tệp riêng tư").ToList();
            }
            
            return result;
        }

        //
        [HttpGet]
        [Route("/teacher/timkiemtailieu")]
        public async Task<ActionResult> SearchTaiLieu1(string txtSearch)
        {
            var taiLieu = await _context.TaiLieu.Where(m => m.MonHoc.TenMonHoc.Contains(txtSearch)||m.TenTaiLieu.Contains(txtSearch)).ToListAsync();
            var result = (from a in taiLieu
                          select new {
                              TenTaiLieu = a.TenTaiLieu,
                              PhanLoai = a.LoaiTaiLieu,
                              NgayGuiPheDuyet = a.NgayGuiPheDuyet,
                              TinhTrangPheDuyet = a.TinhTrang,
                              GhiChu = a.GhiChu
                          }).ToList();
            return Ok(result);
        }
        [HttpGet]
        [Route("/admin/duyettailieu")]
        public async Task<ActionResult> DuyetTaiLieu(int TaiLieuId)
        {
            var taiLieu = await _context.TaiLieu.FindAsync(TaiLieuId);
                
            if (taiLieu == null)
            {
                return NotFound();
            }
            taiLieu.TinhTrang = true;
            _context.Update(taiLieu);
           await _context.SaveChangesAsync();

            return NoContent();
        }

        // PUT: api/TaiLieux/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> SuaTaiLieu(int id,[FromBody] TaiLieu taiLieu)
        {
            if (id != taiLieu.Id)
            {
                return BadRequest();
            }

            _context.Entry(taiLieu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaiLieuExists(id))
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
        //Phan cong
        [HttpPost]
        [Route("/teacher/phancongtailieu")]

        public async Task<ActionResult> PhanCongTaiLieu(int lh,int tl)
        {
            LopHocTaiLieu lhtl = new LopHocTaiLieu();
            lhtl.LopHocId = lh;
            lhtl.TaiLieuId = tl;
            _context.LopHocTaiLieu.Add(lhtl);
           await _context.SaveChangesAsync();
            return Ok("Da them vao lop hoc");
        }

        // POST: api/TaiLieux
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("/teacher/thembaigiang")]
        public async Task<ActionResult> ThemBaiGiang([FromForm] TaiLieu taiLieu, [FromForm] Tep tep )
        {
          
            tep.NguoiChinhSua = taiLieu.NguoiDungId;
            tep.NgaySuaCuoi = DateTime.Now;
            tep.LoaiTep = "Tài liệu";
            


            if (tep.FileTep != null)
            {
                var fileName = Path.GetFileName(tep.FileTep.FileName);
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
          
            taiLieu.TinhTrang = false;
            taiLieu.TepId = tep.Id;
            taiLieu.NgayGuiPheDuyet = DateTime.Now;
            taiLieu.TenTaiLieu = tep.TenTep;
            taiLieu.NguoiChinhSuaCuoi = taiLieu.NguoiDungId; //role
            taiLieu.LoaiTaiLieu = "Bài giảng";
            taiLieu.NguoiDungId = int.Parse(HttpContext.Session.GetString("Nd"));
            _context.TaiLieu.Add(taiLieu);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        //Them tai nguyen
        [HttpPost]
        [Route("/teacher/themtainguyen")]
        public async Task<ActionResult> ThemTaiNguyen([FromForm] TaiLieu taiLieu, [FromForm] Tep tep)
        {

            tep.NguoiChinhSua = taiLieu.NguoiDungId;
            tep.NgaySuaCuoi = DateTime.Now;
            tep.LoaiTep = "Tài liệu";



            if (tep.FileTep != null)
            {
                var fileName = Path.GetFileName(tep.FileTep.FileName);
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
            _context.TaiLieu.Add(taiLieu);
            taiLieu.TinhTrang = false;
            taiLieu.TepId = tep.Id;
            taiLieu.NgayGuiPheDuyet = DateTime.Now;
            taiLieu.TenTaiLieu = tep.TenTep;
            taiLieu.NguoiChinhSuaCuoi = taiLieu.NguoiDungId; //role
            taiLieu.LoaiTaiLieu = "Tài nguyên";
            await _context.SaveChangesAsync();

            return NoContent();
        }
        //them tai lieu vao monhoc
        [HttpPost]
        [Route("/teacher/themtailieuvaomonhoc")]
        public async Task<ActionResult> ThemVaoMonHoc(int taiLieu,string tieuDe,int monHoc, int lopHoc)
        {
            var tlieu = await _context.TaiLieu.FindAsync(taiLieu);
            TaiLieu tl = new TaiLieu();
            tl.MonHocId = monHoc;
            tl.TepId = tlieu.TepId;
            tl.MonHocId = monHoc;
            tl.NguoiDungId = tlieu.NguoiDungId;
            tl.TinhTrang = true;
            tl.NgayGuiPheDuyet = tlieu.NgayGuiPheDuyet;
            tl.LoaiTaiLieu = tlieu.LoaiTaiLieu;
            tl.NguoiChinhSuaCuoi = tlieu.NguoiChinhSuaCuoi;
            tl.TieuDe = tieuDe;

            var a = await _context.Tep.FindAsync(tlieu.TepId);
            tl.TenTaiLieu = a.TenTep;
            _context.TaiLieu.Add(tl);
            await _context.SaveChangesAsync();
            if(lopHoc!=0)
            {
                LopHocTaiLieu lhtl = new LopHocTaiLieu();
                lhtl.LopHocId = lopHoc;
                lhtl.TaiLieuId = taiLieu;
                _context.LopHocTaiLieu.Add(lhtl);
                await _context.SaveChangesAsync();
            }
            return Ok(tl);
        }

        // DELETE: api/TaiLieux/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> XoaTaiLieu(int id)
        {
            var taiLieu = await _context.TaiLieu.FindAsync(id);
            if (taiLieu == null)
            {
                return NotFound();
            }

            _context.TaiLieu.Remove(taiLieu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaiLieuExists(int id)
        {
            return _context.TaiLieu.Any(e => e.Id == id);
        }
    }
}
