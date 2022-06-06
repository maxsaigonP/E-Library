using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Software_Requirement_Specification.Models
{
  
    public class VaiTro
    {
        public int Id { get; set; }
        public string TenVaiTro { get; set; }

        public string MoTa { get; set; }
        

        public int TaiNguyen { get; set; }

        public DateTime? NgayCapNhatCuoi { get; set; }

        public int ThongBao { get; set; }
       // public ThongBao ThongBao { get; set; }

  
        public List<TaiKhoan> TaiKhoans { get; set; }

        public List<VaiTroPhanQuyen> VaiTroPhanQuyen { get; set; }
        
    }
}
