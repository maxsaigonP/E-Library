using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Software_Requirement_Specification.Models
{
    public class ThongBao
    {
        public int Id { get; set; }

        public bool LoaiThongBao { get; set; }

        public string ChuDe { get; set; }

        public string TaiKhoanId { get; set; }

        public string? HocVienId { get; set; }

        public int DoiTuong { get; set; } //1=MonHoc 2=Tep 3=Dethi 4=PhanQuyen 5=TaiKhoan
        public string NoiDung { get; set; }

        public DateTime ThoiGian { get; set; }

    }
}
