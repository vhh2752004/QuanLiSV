using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; // Thêm dòng này
using System.ComponentModel.DataAnnotations.Schema;
namespace QuanLiSV.Models
{
    public class Lichhoc
    {

        [Key]
        public int mamonhoc { get; set; }

        [Required(ErrorMessage = "Thứ học không được để trống")]
        public string thuhoc { get; set; }

        [Required(ErrorMessage = "Giờ bắt đầu không được để trống")]
        [Display(Name = "Giờ bắt đầu")]
        [DataType(DataType.Time)]
        public DateTime giobatdau { get; set; }

        [Required(ErrorMessage = "Giờ kết thúc không được để trống")]
        [Display(Name = "Giờ kết thúc")]
        [DataType(DataType.Time)]
        public DateTime gioketthuc { get; set; }

        [Required(ErrorMessage = "Phòng học không được để trống")]
        public string phonghoc { get; set; }

        [ForeignKey("Monhoc")]
        public int Monhoc_ID { get; set; }

        public virtual Monhoc? Monhoc { get; set; }
    }
}
