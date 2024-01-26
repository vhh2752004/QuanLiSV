using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; // Thêm dòng này
using System.ComponentModel.DataAnnotations.Schema;
namespace QuanLiSV.Models
{
    public class Sinhvien { 
    [Key]
    public int masv { get; set; }

   
    public string Hoten { get; set; }

    
    public DateTime? ngaysinh { get; set; }

    
    public string gioitinh { get; set; }

   
    [ForeignKey("Lop")]
    public int Lop_Id { get; set; }

    public virtual Lop? Lop { get; set; }
}

}

