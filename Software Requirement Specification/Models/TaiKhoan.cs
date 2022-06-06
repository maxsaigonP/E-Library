using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Software_Requirement_Specification.Models
{
    public class TaiKhoan : IdentityUser
    {

        public VaiTro? VaiTro { get; set; }
        public List<TaiLieu>? TaiLieu { get; set; }
        public List<DeThi>? DeThi { get; set; }
        public Hoi? Hoi { get; set; }

        public List<ThacMac>? ThacMac { get; set; }
    }
}
