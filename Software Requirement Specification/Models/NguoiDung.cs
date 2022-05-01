using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Software_Requirement_Specification.Models
{
    public class NguoiDung
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }

        public int LopHocId { get; set; }
        public int MonHocId { get; set; }
        public int VaitroId { get; set; }
        public VaiTro VaiTro { get; set; }
        public TaiKhoan TaiKhoan { get; set; }
        public List<NguoiDungMonHoc> NguoiDungMonHoc { get; set; }
        public List<TaiLieu> TaiLieu { get; set; }
        public List<DeThi> DeThi { get; set; }
        public Hoi Hoi { get; set; }

        public List<ThacMac> ThacMac { get; set; }
    }
}
