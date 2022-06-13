using KiemTra_NguyenMinhTrongNhan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KiemTra_NguyenMinhTrongNhan.Controllers
{

    public class NguoiDungController : Controller
    {
        Test01DataContext data = new Test01DataContext();

        // GET: NguoiDung
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection collection)
        {
            var mssv = collection["mssv"];
            
             if(String.IsNullOrEmpty (mssv))
            {
                ViewData["Loi"] = "Vui lòng nhập mã số sinh viên";
            }
             else
            {
                var sv = data.SinhViens.SingleOrDefault(n => n.MaSV == mssv);
                if(sv != null)
                {
                    //Session["TaiKhoan" = sv];
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ViewBag.ThongBao = "Sinh viên này không tồn tại";
                }
            }
            return View();
        }
    }
}