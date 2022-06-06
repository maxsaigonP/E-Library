using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Software_Requirement_Specification.Models
{
    public class ThacMac
    {
        public int Id { get; set; }
        public string TaiKhoanId { get; set; }

        public TaiKhoan? TaiKhoan { get; set; }

        public string ChuDe { get; set; }
        public string NoiDung { get; set; }
    }
}
