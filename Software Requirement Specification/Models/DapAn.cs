using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Software_Requirement_Specification.Models
{
    public class DapAn
    {
        public int Id { get; set; }

        public int CauHoiId { get; set; }
        public CauHoi CauHoi { get; set; }
        public string NoiDung { get; set; }

        public bool Dung { get; set; }
    }
}
