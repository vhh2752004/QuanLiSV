using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; // Thêm dòng này
using System.ComponentModel.DataAnnotations.Schema;
namespace QuanLiSV.Models
{
    public class Ketquahoctap
    {
        [Key]
        public int masv { get; set; }

        [ForeignKey("Sinhvien")]
        public int Sinhvien_Id { get; set; }

        public virtual Sinhvien? Sinhvien { get; set; }

        [ForeignKey("Monhoc")]
        public int Monhoc_Id { get; set; }

        public virtual Monhoc? Monhoc { get; set; }

        public int Hocky { get; set; }

        [Column(TypeName = "decimal(2, 2)")]
        public float Diemtongket { get; set; }
    }
}
