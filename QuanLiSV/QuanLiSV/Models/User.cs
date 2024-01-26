using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace QuanLiSV.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        public String? Name { get; set; }
        public string? Email { get; set; }
        public String? Password { get; set; }
        public string? Role { get; set; }

    }
}
