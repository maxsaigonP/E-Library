using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Software_Requirement_Specification.Models
{
    public class LopHoc
    {
        public int Id { get; set; }
        public string TenLop { get; set; }

        public List<LopHocMonHoc> LopHocMonHoc { get; set; }
        public List<LopHocTaiLieu> LopHocTaiLieu { get; set; }

       

    }
}

