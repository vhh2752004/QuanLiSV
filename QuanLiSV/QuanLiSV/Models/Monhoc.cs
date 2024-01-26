using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; // Thêm dòng này
using System.ComponentModel.DataAnnotations.Schema;
namespace QuanLiSV.Models
{
    public class Monhoc
    {
        [Key]
        public int mamonhoc { get; set; }

        [Required(ErrorMessage = "Tên môn học không được để trống")]
        [StringLength(255, ErrorMessage = "Tên môn học không được quá 255 ký tự")]
        public string tenmh { get; set; }

        [Required(ErrorMessage = "Số tín chỉ không được để trống")]
        [Range(1, int.MaxValue, ErrorMessage = "Số tín chỉ phải lớn hơn 0")]
        public int sotinchi { get; set; }
    }
}
