using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; // Thêm dòng này
using System.ComponentModel.DataAnnotations.Schema;
namespace QuanLiSV.Models
{
    public class Diemrenluyen
    {
        [Key]
        public int masv { get; set; }

        [ForeignKey("Sinhvien")]
        public int Sinhvien_Id { get; set; }

        public virtual Sinhvien? Sinhvien { get; set; }

        public string? Hoten { get; set; }

        public float? diemrenluyen { get; set; }
    }
}
