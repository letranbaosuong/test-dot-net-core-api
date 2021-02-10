using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaiTest.Models
{
    public class BaiTestContext : DbContext
    {
        public BaiTestContext(DbContextOptions<BaiTestContext> options) : base(options) { }
        public DbSet<NhanVien> NhanVien { get; set; }
        public DbSet<PhongBan> PhongBan { get; set; }
    }
}
