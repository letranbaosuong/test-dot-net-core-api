using BaiTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaiTest.Services
{
    public interface IBaiTest
    {
        NhanVien GetNhanVien(int? MaNhanVien);
        List<NhanVien> NhanViens();
        PhongBan GetPhongBan(int? MaPhongBan);
        List<PhongBan> PhongBans();
        PhongBan AddPhongBan(PhongBan phongBan);
        PhongBan UpdatePhongBan(PhongBan phongBan);
        PhongBan DeletePhongBan(int? MaPhongBan);
        NhanVien AddNhanVien(NhanVien nhanVien);
        NhanVien UpdateNhanVien(NhanVien nhanVien);
        NhanVien DeleteNhanVien(int? MaNhanVien);
    }
}
