using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BaiTest.Models
{
    public class NhanVien
    {
        [Key]
        public int MaNhanVien { get; set; }
        public String TenNhanVien { get; set; }
        public int MaPhongBan { get; set; }
        [ForeignKey("MaPhongBan")]
        public virtual PhongBan PhongBan { get; set; }
    }
}
