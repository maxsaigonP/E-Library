using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Software_Requirement_Specification.Models
{
    public class NguoiDungMonHoc
    {
        public int Id { get; set; }
        public int NguoiDungId { get; set; }
        public NguoiDung NguoiDung { get; set; }
        public int MonHocId { get; set; }
        public MonHoc MonHoc { get; set; }
    }
}
