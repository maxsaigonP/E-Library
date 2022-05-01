using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Software_Requirement_Specification.Models
{
    public class LopHocTaiLieu
    {
        public int Id { get; set; }
        public int LopHocId { get; set; }
        public LopHoc LopHoc { get; set; }
        public int TaiLieuId { get; set; }
        public TaiLieu TaiLieu { get; set; }
    }
}
