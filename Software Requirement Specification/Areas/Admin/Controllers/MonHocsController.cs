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
    public class MonHocsController : ControllerBase
    {
       
        private readonly ApplicationDbContext _context;

        public MonHocsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("/teacher/dsmonhoc")]
        public async Task<ActionResult> DsMonHoc()
        {
            //int check = 0;
            //var nd = await _context.NguoiDung.FindAsync(int.Parse(HttpContext.Session.GetString("Nd")));
            //var vt = await _context.VaiTroPhanQuyen.Where(v => v.VaiTroId == nd.VaitroId).ToListAsync();
            //foreach (var i in vt)
            //{
            //    if (i.PhanQuyenId == 1)
            //    {
            //        check++;
            //    }
            //}
            //if (check == 0)
            //{
            //    return NoContent();
            //}
            var result = (from a in _context.MonHoc
                          select new
                          {
                              MaMonHoc = a.Id,
                              TenMonHoc = a.TenMonHoc,
                              MoTa = a.MoTa,
                              TinhTrang = a.TinhTrang,
                              SoTaiLieuChoDuyet = (from c in _context.TaiLieu where c.MonHocId == a.Id where c.TinhTrang == false select c).Count(),

                          }).Distinct().ToList();
            return Ok(result);
        }
        //
        [HttpGet]
        [Route("/teacher/locdsmonhoc")]
        public async Task<ActionResult> DsMonHoc(int xepTheo) //1=Theo ten
        {
           
            var result = (from a in _context.MonHoc
                          orderby a.TenMonHoc
                          select new
                          {
                              MaMonHoc = a.Id,
                              TenMonHoc = a.TenMonHoc,
                              MoTa = a.MoTa,
                              TinhTrang = a.TinhTrang,
                              SoTaiLieuChoDuyet = (from c in _context.TaiLieu where c.MonHocId == a.Id where c.TinhTrang == false select c).Count(),

                          }).Distinct().ToList();
            return Ok(result);
        }
        [HttpGet]
        [Route("/teacher/dsmonhoctheolop")]
        public async Task<ActionResult> DsMonHocMaLop(int lopHoc)
        {
            //int check = 0;
            //var nd = await _context.NguoiDung.FindAsync(int.Parse(HttpContext.Session.GetString("Nd")));
            //var vt = await _context.VaiTroPhanQuyen.Where(v => v.VaiTroId == nd.VaitroId).ToListAsync();
            //foreach (var i in vt)
            //{
            //    if (i.PhanQuyenId == 1)
            //    {
            //        check++;
            //    }
            //}
            //if (check == 0)
            //{
            //    return NoContent();
            //}
            var result = (from a in _context.MonHoc
                          join x in _context.LopHocMonHoc on a.Id equals x.MonHocId
                          where x.LopHocId == lopHoc
                          select new
                          {
                              MaMonHoc = a.Id,
                              TenMonHoc = a.TenMonHoc,
                              MoTa = a.MoTa,
                              TinhTrang = a.TinhTrang,
                              SoTaiLieuChoDuyet = (from c in _context.TaiLieu where c.MonHocId == a.Id where c.TinhTrang == false select c).Count(),

                          }).Distinct().ToList();
            return Ok(result);
        }


        [HttpGet]
        [Route("/teacher/timkiemmonhoc")]
        public async Task<ActionResult> TimKiemDsMonHoc(string txtSearch)
        {
            txtSearch = txtSearch.ToLower();
         
            var result = (from a in _context.MonHoc
                          join x in _context.LopHocMonHoc on a.Id equals x.MonHocId
                          where a.TenMonHoc.Contains(txtSearch) || x.LopHoc.TenLop.Contains(txtSearch)
                          select new
                          {
                              MaMonHoc = a.Id,
                              TenMonHoc = a.TenMonHoc,
                              MoTa = a.MoTa,
                              TinhTrang = a.TinhTrang,
                              SoTaiLieuChoDuyet = (from c in _context.TaiLieu where c.MonHocId == a.Id where c.TinhTrang == false select c).Count(),

                          }).Distinct().ToList();
            return Ok(result);
        }
        [HttpGet]
        [Route("/chitietmonhoc")]
        public async Task<ActionResult> ChiTietMonHoc(int id)
        {
       
            var v = await _context.MonHoc.Include(t => t.TaiLieu).ToListAsync();
            var result = (from a in v
                          where a.Id==id
                          select new
                          {
                              MaMonHoc = a.Id,
                              TenMonHoc = a.TenMonHoc,
                              MoTa = a.MoTa,
                              TinhTrang = a.TinhTrang,
                              SoTaiLieuChoDuyet = (from c in _context.TaiLieu where c.MonHocId == a.Id where c.TinhTrang == false select c).Count(),

                          }).Distinct().ToList();
            return Ok(result);
        }

        [HttpGet]
        [Route("/admin/themmonhocvaolop")]
        public async Task<ActionResult> ThemMonHocVaoLop(int lh, int mh)
        {
            if(lh==0&&mh==0)
            {
                return NotFound();
            }
            var listLop = await _context.LopHoc.ToListAsync();
            var  a = new LopHocMonHoc();
            if(lh==0)
            {
                foreach(LopHoc l in listLop)
                {
                    a = new LopHocMonHoc();
                    a.LopHocId = l.Id;
                    a.MonHocId = mh;
                    try
                    {
                        _context.LopHocMonHoc.Add(a);
                        await _context.SaveChangesAsync();                     
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                var tb = new ThongBao();
                tb.LoaiThongBao = false;
                tb.TaiKhoanId = HttpContext.Session.GetString("Id");
                tb.NoiDung = "X đã thêm  môn học " + _context.MonHoc.Find(mh).TenMonHoc + " vào tất cả các lớp";
                tb.DoiTuong = 1;
                tb.ThoiGian = DateTime.Now;
                _context.Add(tb);
                await _context.SaveChangesAsync();
                return Ok("Da them vao tat ca lop hoc");
            }
            a.LopHocId = lh;
            a.MonHocId = mh;
            try
            {
                _context.LopHocMonHoc.Add(a);
              await  _context.SaveChangesAsync();
                var tb = new ThongBao();
                tb.LoaiThongBao = true;
                tb.TaiKhoanId = HttpContext.Session.GetString("Id");
                tb.NoiDung = "X đã thêm môn "+_context.MonHoc.Find(mh).TenMonHoc+" vào lớp "+ _context.LopHoc.Find(lh).TenLop;
                tb.DoiTuong = 1;
                tb.ThoiGian = DateTime.Now;
                _context.Add(tb);
                await _context.SaveChangesAsync();
                return Ok(a);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return Ok("Them thanh cong");


        }
     
        [HttpPut("{id}")]
        public async Task<IActionResult> SuaMonHoc(int id,[FromBody] MonHoc monHoc)
        {
            //int check = 0;
            //var nd = await _context.NguoiDung.FindAsync(int.Parse(HttpContext.Session.GetString("Nd")));
            //var vt = await _context.VaiTroPhanQuyen.Where(v => v.VaiTroId == nd.VaitroId).ToListAsync();
            //foreach (var i in vt)
            //{
            //    if (i.PhanQuyenId == 2)
            //    {
            //        check++;
            //    }
            //}
            //if (check == 0)
            //{
            //    return NoContent();
            //}
            if (id != monHoc.Id)
            {
                return BadRequest();
            }

            _context.Entry(monHoc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                var tb = new ThongBao();
                tb.LoaiThongBao = true;
                tb.TaiKhoanId = HttpContext.Session.GetString("Id");
                tb.NoiDung = "X đã chỉnh sửa " + monHoc.TenMonHoc;
                tb.DoiTuong = 1;
                tb.ThoiGian = DateTime.Now;
                _context.Add(tb);
                await _context.SaveChangesAsync();
            
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonHocExists(id))
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

        // POST: api/MonHocs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MonHoc>> ThemMonHoc([FromBody] MonHoc monHoc)
        {
            _context.MonHoc.Add(monHoc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMonHoc", new { id = monHoc.Id }, monHoc);
        }

        // DELETE: api/MonHocs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> XoaMonHoc(int id)
        {
            var monHoc = await _context.MonHoc.FindAsync(id);
            if (monHoc == null)
            {
                return NotFound();
            }

            _context.MonHoc.Remove(monHoc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MonHocExists(int id)
        {
            return _context.MonHoc.Any(e => e.Id == id);
        }
    }
}
