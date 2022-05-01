using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Software_Requirement_Specification.Models;

namespace Software_Requirement_Specification.Data
{
    public class Software_Requirement_SpecificationContext : DbContext
    {
        public Software_Requirement_SpecificationContext (DbContextOptions<Software_Requirement_SpecificationContext> options)
            : base(options)
        {
        }
      

        public DbSet<Software_Requirement_Specification.Models.NguoiDung> NguoiDung { get; set; }



        public DbSet<Software_Requirement_Specification.Models.Tep> Tep { get; set; }

       // public DbSet<Software_Requirement_Specification.Models.BaiGiang> BaiGiang { get; set; }

        public DbSet<Software_Requirement_Specification.Models.DeThi> DeThi { get; set; }

        public DbSet<Software_Requirement_Specification.Models.LopHoc> LopHoc { get; set; }

        public DbSet<Software_Requirement_Specification.Models.MonHoc> MonHoc { get; set; }

        public DbSet<Software_Requirement_Specification.Models.PhanQuyen> PhanQuyen { get; set; }

        public DbSet<Software_Requirement_Specification.Models.TaiKhoan> TaiKhoan { get; set; }

        public DbSet<Software_Requirement_Specification.Models.TaiLieu> TaiLieu { get; set; }

        public DbSet<Software_Requirement_Specification.Models.ThuVien> ThuVien { get; set; }

        public DbSet<Software_Requirement_Specification.Models.VaiTro> VaiTro { get; set; }

        public DbSet<Software_Requirement_Specification.Models.ThongBao> ThongBao { get; set; }
        public DbSet<Software_Requirement_Specification.Models.LopHocMonHoc> LopHocMonHoc { get; set; }
        public DbSet<Software_Requirement_Specification.Models.BoMon> BoMon { get; set; }
        public DbSet<Software_Requirement_Specification.Models.CauHoi> CauHoi { get; set; }
        public DbSet<Software_Requirement_Specification.Models.DapAn> DapAn { get; set; }
        public DbSet<Software_Requirement_Specification.Models.ChuDe> ChuDe { get; set; }
        public DbSet<Software_Requirement_Specification.Models.LopHocTaiLieu> LopHocTaiLieu { get; set; }
        public DbSet<Software_Requirement_Specification.Models.NguoiDungMonHoc> NguoiDungMonHoc { get; set; }
        public DbSet<Software_Requirement_Specification.Models.Hoi> Hoi { get; set; }
        public DbSet<Software_Requirement_Specification.Models.ThacMac> ThacMac { get; set; }
        public DbSet<Software_Requirement_Specification.Models.VaiTroPhanQuyen> VaiTroPhanQuyen { get; set; }
    }
}
