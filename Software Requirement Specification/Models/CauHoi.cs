using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Software_Requirement_Specification.Models
{
    public class CauHoi
    {
        public int Id { get; set; }
        //public int DeThiId { get; set; }
        //public DeThi DeThi { get; set; }
        public string NoiDung { get; set; }

        public int LoaiCauHoi { get; set; } // 1=Tuluan  2=tracnghiem

        public int DoKho { get; set; } //1=thap 2=tb 3=cao
        public List<DapAn>? DapAn { get; set; }
    }
}
