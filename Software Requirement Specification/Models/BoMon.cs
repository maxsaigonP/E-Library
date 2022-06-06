using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Software_Requirement_Specification.Models
{
    public class BoMon
    {
        public int Id { get; set; }
        public string TenBoMon { get; set; }

        public List<MonHoc>? MonHoc { get; set; }
    }
}
