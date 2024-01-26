using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuanLiSV.Models;

namespace QuanLiSV.Data
{
    public class QuanLiSVContext : DbContext
    {
        public QuanLiSVContext (DbContextOptions<QuanLiSVContext> options)
            : base(options)
        {
        }

        public DbSet<QuanLiSV.Models.Diemhoctap> Diemhoctap { get; set; }

        public DbSet<QuanLiSV.Models.Diemrenluyen> Diemrenluyen { get; set; }

        public DbSet<QuanLiSV.Models.Ketquahoctap> Ketquahoctap { get; set; }

        public DbSet<QuanLiSV.Models.Lichhoc> Lichhoc { get; set; }

        public DbSet<QuanLiSV.Models.Lop> Lop { get; set; }

        public DbSet<QuanLiSV.Models.Monhoc> Monhoc { get; set; }

        public DbSet<QuanLiSV.Models.Sinhvien> Sinhvien { get; set; }

        public DbSet<QuanLiSV.Models.User> User { get; set; }
        public IEnumerable<object> StudentMarks { get; internal set; }
    }
}
