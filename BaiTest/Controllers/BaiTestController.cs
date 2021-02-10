using BaiTest.Models;
using BaiTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaiTestController : ControllerBase
    {
        IBaiTest _baiTest;
        public BaiTestController(IBaiTest baiTest)
        {
            _baiTest = baiTest;
        }
        [HttpGet("GetNhanVien/{MaNhanVien}")]
        [Route("GetNhanVien")]
        public IActionResult GetNhanVien(int? MaNhanVien)
        {
            /*try
            {*/
            var nhanVien = _baiTest.GetNhanVien(MaNhanVien);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return Ok(nhanVien);
            /*}
            catch (Exception)
            {
                return BadRequest();
            }*/
        }
        [HttpGet]
        [Route("NhanViens")]
        public IActionResult NhanViens()
        {
            /*try
            {*/
            var nhanViens = _baiTest.NhanViens();
            if (nhanViens == null)
            {
                return NotFound();
            }

            return Ok(nhanViens);
            /*}
            catch (Exception)
            {
                return BadRequest();
            }*/
        }
        [HttpGet("GetPhongBan/{MaPhongBan}")]
        [Route("GetPhongBan")]
        public IActionResult GetPhongBan(int? MaPhongBan)
        {
            var phongBan = _baiTest.GetPhongBan(MaPhongBan);
            if (phongBan == null)
            {
                return NotFound();
            }

            return Ok(phongBan);
        }
        [HttpGet]
        [Route("PhongBans")]
        public IActionResult PhongBans()
        {
            var phongBans = _baiTest.PhongBans();
            if (phongBans == null)
            {
                return NotFound();
            }

            return Ok(phongBans);
        }
        [HttpPost]
        [Route("AddPhongBan")]
        public IActionResult AddPhongBan([FromBody] PhongBan phongBan)
        {
            if (ModelState.IsValid)
            {
                /*try
                {*/
                var phong = _baiTest.AddPhongBan(phongBan);
                if (phong != null)
                {
                    return Ok(phong);
                }
                else
                {
                    return NotFound();
                }
                /*}
                catch (Exception)
                {
                    return BadRequest();
                }*/
            }

            return BadRequest();
        }
        [HttpPut]
        [Route("UpdatePhongBan")]
        public IActionResult UpdatePhongBan([FromBody] PhongBan phongBan)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    PhongBan phong = _baiTest.UpdatePhongBan(phongBan);
                    return Ok(phong);
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }
        [HttpDelete("DeletePhongBan/{MaPhongBan}")]
        [Route("DeletePhongBan")]
        public IActionResult DeletePhongBan(int? MaPhongBan)
        {
            if (MaPhongBan == null)
            {
                return BadRequest();
            }

            try
            {
                PhongBan phong = _baiTest.DeletePhongBan(MaPhongBan);
                if (phong == null)
                {
                    return NotFound();
                }

                return Ok(phong);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("AddNhanVien")]
        public IActionResult AddNhanVien([FromBody] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                /*try
                {*/
                var nhan = _baiTest.AddNhanVien(nhanVien);
                if (nhan != null)
                {
                    return Ok(nhan);
                }
                else
                {
                    return NotFound();
                }
                /*}
                catch (Exception)
                {
                    return BadRequest();
                }*/
            }

            return BadRequest();
        }
        [HttpPut]
        [Route("UpdateNhanVien")]
        public IActionResult UpdateNhanVien([FromBody] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                /*try
                {*/
                NhanVien nhan = _baiTest.UpdateNhanVien(nhanVien);
                return Ok(nhan);
                /*}
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }*/
            }

            return BadRequest();
        }
        [HttpDelete]
        [Route("DeleteNhanVien")]
        public IActionResult DeleteNhanVien([FromBody]int? MaNhanVien)
        {
            /*if (MaNhanVien == null)
            {
                return BadRequest();
            }

            try
            {*/
            NhanVien nhan = _baiTest.DeleteNhanVien(MaNhanVien);
            if (nhan != null)
            {
                return Ok(nhan);
            }

            return NotFound();
            /*}
            catch (Exception)
            {
                return BadRequest();
            }*/
        }
    }
}
