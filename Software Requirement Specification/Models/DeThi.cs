using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Software_Requirement_Specification.Models
{
    public class DeThi
    {
        public int Id { get; set; }

        public string TenDeThi { get; set; }

        public string Loai { get; set; }
        public int TepId { get; set; }
        public Tep Tep { get; set; }
        public int MonHocId { get; set; }
        public MonHoc MonHoc { get; set; }
        public int NguoiDungId { get; set; }
        public NguoiDung NguoiDung { get; set; }
        public string HinhThuc { get; set; }
        public string NienKhoa { get; set; }
        public int ThoiLuong { get; set; }
        public DateTime NgayTao { get; set; }
        public bool TinhTrang { get; set; }

        public int NguoiPheDuyet { get; set; }
        public string GhiChu { get; set; }

       // public List<CauHoi> CauHoi { get; set; }


        
    }
}
