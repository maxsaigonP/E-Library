using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Software_Requirement_Specification.Models
{
    public class TaiLieu
    {
        public int Id { get; set; }
        public string TenTaiLieu { get; set; }
        public string LoaiTaiLieu { get; set; }
        public string TieuDe { get; set; }
        public int TepId { get; set; }
        public Tep Tep { get; set; }
        public int MonHocId { get; set; }
        public MonHoc MonHoc { get; set; }
        public int NguoiDungId { get; set; }
        public NguoiDung NguoiDung { get; set; }
        public string GhiChu { get; set; }
        public int NguoiChinhSuaCuoi { get; set; }
        public bool TinhTrang { get; set; }
        public DateTime NgayGuiPheDuyet { get; set; }
        public List<LopHocTaiLieu> LopHocTaiLieu { get; set; }
    
    }
}
