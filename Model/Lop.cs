using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; // Thêm dòng này
namespace QuanLiSV.Models
{
    public class Lop
    {
        [Key]
        public int malop { get; set; }

        [Required(ErrorMessage = "Tên lớp không được để trống")]
        [StringLength(255, ErrorMessage = "Tên lớp không được quá 255 ký tự")]
        public string tenlop { get; set; }
    }
}
