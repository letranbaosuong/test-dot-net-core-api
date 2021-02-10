using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BaiTest.Models
{
    public class PhongBan
    {
        [Key]
        public int MaPhongBan { get; set; }
        public String TenPhongBan { get; set; }
    }
}
