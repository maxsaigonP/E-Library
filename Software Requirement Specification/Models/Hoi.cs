using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Software_Requirement_Specification.Models
{
    public class Hoi
    {
        public int Id { get; set; }

        public string NoiDung { get; set; }
        public int MonHocId { get; set; }
        public MonHoc MonHoc { get; set; }

        public int TaiLieuId { get; set; }
        //public TaiLieu TaiLieu { get; set; }

        public int NguoiDungId { get; set; }
        public NguoiDung NguoiDung { get; set; }

        public DateTime NgayGui { get; set; }
        public bool TinhTrang { get; set; }


    }
}
