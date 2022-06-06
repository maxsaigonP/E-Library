﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Software_Requirement_Specification.Models
{
    public class Tep
    {
        public int Id { get; set; }
        public string TenTep { get; set; }
        public string? TheLoai { get; set; }
        public string? LoaiTep { get; set; }
        public string NguoiChinhSua { get; set; }
        public DateTime? NgaySuaCuoi { get; set; }
        public string File { get; set; }
        public int? KichThuoc { get; set; }

        [NotMapped]
        public IFormFile FileTep { get; set; }
       

        public List<TaiLieu>? TaiLieu { get; set; }

      //  public BaiGiang BaiGiang { get; set; }
        public DeThi? DeThi { get; set; }

    }
}
