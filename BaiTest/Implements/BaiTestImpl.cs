using BaiTest.Models;
using BaiTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaiTest.Implements
{
    public class BaiTestImpl : IBaiTest
    {
        private readonly BaiTestContext _db;
        public BaiTestImpl(BaiTestContext db)
        {
            _db = db;
        }

        public NhanVien AddNhanVien(NhanVien nhanVien)
        {
            int result = 0;
            NhanVien nhan;
            if (_db != null)
            {
                _db.NhanVien.Add(nhanVien);
                result = _db.SaveChanges();

                if (result != 0)
                {
                    nhan = (from n in _db.NhanVien
                            join p in _db.PhongBan on n.MaPhongBan equals p.MaPhongBan
                            where n.MaNhanVien == nhanVien.MaNhanVien
                            select new NhanVien
                            {
                                MaNhanVien = n.MaNhanVien,
                                TenNhanVien = n.TenNhanVien,
                                MaPhongBan = p.MaPhongBan,
                                PhongBan = new PhongBan
                                {
                                    MaPhongBan = p.MaPhongBan,
                                    TenPhongBan = p.TenPhongBan,
                                }
                            }
                              ).FirstOrDefault();

                    return nhan;
                }

                return null;
            }

            return null;
        }

        public PhongBan AddPhongBan(PhongBan phongBan)
        {
            if (_db != null)
            {
                _db.PhongBan.Add(phongBan);
                _db.SaveChanges();

                return phongBan;
            }

            return null;
        }

        public NhanVien DeleteNhanVien(int? MaNhanVien)
        {
            int result = 0;
            if (_db != null)
            {
                var nhanVien = (from n in _db.NhanVien
                                join p in _db.PhongBan on n.MaPhongBan equals p.MaPhongBan
                                where n.MaNhanVien == MaNhanVien
                                select new NhanVien
                                {
                                    MaNhanVien = n.MaNhanVien,
                                    TenNhanVien = n.TenNhanVien,
                                    MaPhongBan = n.MaPhongBan,
                                    PhongBan = new PhongBan
                                    {
                                        MaPhongBan = p.MaPhongBan,
                                        TenPhongBan = p.TenPhongBan,
                                    }
                                }
                                ).FirstOrDefault();

                if (_db != null)
                {
                    _db.NhanVien.Remove(nhanVien);
                    result = _db.SaveChanges();

                    if (result != 0)
                    {
                        return nhanVien;
                    }

                    return null;
                }
            }

            return null;
        }

        public PhongBan DeletePhongBan(int? MaPhongBan)
        {
            int result = 0;

            if (_db != null)
            {
                var phongBan = _db.PhongBan.FirstOrDefault(p => p.MaPhongBan == MaPhongBan);

                if (phongBan != null)
                {
                    _db.PhongBan.Remove(phongBan);
                    result = _db.SaveChanges();

                    return phongBan;
                }
            }

            return null;
        }

        public NhanVien GetNhanVien(int? MaNhanVien)
        {
            NhanVien nhanVien = _db.NhanVien.Find(MaNhanVien);
            PhongBan phongBan = (from p in _db.PhongBan
                                 join n in _db.NhanVien
                                 on p.MaPhongBan equals n.MaPhongBan
                                 where n.MaNhanVien == MaNhanVien
                                 select new PhongBan
                                 {
                                     MaPhongBan = p.MaPhongBan,
                                     TenPhongBan = p.TenPhongBan
                                 }
                              ).FirstOrDefault();
            if (nhanVien != null)
            {
                nhanVien.PhongBan = phongBan;
            }
            return nhanVien;
        }

        public PhongBan GetPhongBan(int? MaPhongBan)
        {
            PhongBan phongBan = _db.PhongBan.Find(MaPhongBan);
            return phongBan;
        }

        public List<NhanVien> NhanViens()
        {
            List<NhanVien> nhanViens = _db.NhanVien.ToList();
            if (_db != null && nhanViens != null)
            {
                foreach (NhanVien nhanVien in nhanViens)
                {
                    PhongBan phongBan = (from p in _db.PhongBan
                                         join n in _db.NhanVien
                                         on p.MaPhongBan equals n.MaPhongBan
                                         where n.MaNhanVien == nhanVien.MaNhanVien
                                         select new PhongBan
                                         {
                                             MaPhongBan = p.MaPhongBan,
                                             TenPhongBan = p.TenPhongBan
                                         }
                              ).FirstOrDefault();
                    nhanVien.PhongBan = phongBan;
                }
                return nhanViens;
            }

            return null;
        }

        public List<PhongBan> PhongBans()
        {
            List<PhongBan> phongBans = _db.PhongBan.ToList();
            if (_db != null)
            {
                return phongBans;
            }

            return null;
        }

        public NhanVien UpdateNhanVien(NhanVien nhanVien)
        {
            int result = 0;
            NhanVien nhan;
            if (_db != null)
            {
                _db.NhanVien.Update(nhanVien);
                result = _db.SaveChanges();

                if (result != 0)
                {
                    nhan = (from n in _db.NhanVien
                            join p in _db.PhongBan on n.MaPhongBan equals p.MaPhongBan
                            where n.MaNhanVien == nhanVien.MaNhanVien
                            select new NhanVien
                            {
                                MaNhanVien = n.MaNhanVien,
                                TenNhanVien = n.TenNhanVien,
                                MaPhongBan = n.MaPhongBan,
                                PhongBan = new PhongBan
                                {
                                    MaPhongBan = p.MaPhongBan,
                                    TenPhongBan = p.TenPhongBan
                                }
                            }
                          ).FirstOrDefault();

                    return nhan;
                }

                return null;
            }

            return null;
        }

        public PhongBan UpdatePhongBan(PhongBan phongBan)
        {
            if (_db != null)
            {
                _db.PhongBan.Update(phongBan);
                _db.SaveChanges();

                return phongBan;
            }

            return null;
        }
    }
}
