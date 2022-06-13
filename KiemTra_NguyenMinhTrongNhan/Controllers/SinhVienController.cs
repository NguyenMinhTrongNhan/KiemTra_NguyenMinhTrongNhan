using KiemTra_NguyenMinhTrongNhan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KiemTra_NguyenMinhTrongNhan.Controllers
{
    public class SinhVienController : Controller
    {
        Test01DataContext data = new Test01DataContext();
        // GET: SinhVien
        public ActionResult Index()
        {
            var all_sinhvien = from ss in data.SinhViens select ss;
            return View(all_sinhvien);
        }
        public ActionResult Detail(String id)
        {
            var D_sinhvien = data.SinhViens.Where(m => m.MaSV == id).First();
            return View(D_sinhvien);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, SinhVien s)
        {
            
            var E_hoten = collection["hoten"];
            var E_gioitinh = collection["gioitinh"];
            var E_ngaysinh = Convert.ToDateTime(collection["ngaysinh"]);
            var E_hinh = collection["hinh"];
            var E_manganh = collection["manganh"];
            if (string.IsNullOrEmpty(E_hoten))
            {
                ViewData["Error"] = "Don't Empty!";
            }
            else
            {
                
                s.HoTen = E_hoten.ToString();
                s.GioiTinh = E_gioitinh.ToString();
                s.NgaySinh = E_ngaysinh;
                s.Hinh = E_hinh.ToString();
                s.MaNganh = E_manganh.ToString();
                data.SinhViens.InsertOnSubmit(s);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Create();
        }
        public ActionResult Edit(string id)
        {
            var E_sinhvien = data.SinhViens.First(m => m.MaSV == id);
            return View(E_sinhvien);
        }
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            var E_sinhvien = data.SinhViens.First(m => m.MaSV == id);
            var E_masv = collection["masv"];
            var E_hoten = collection["hoten"];
            var E_gioitinh = collection["gioitinh"];
            var E_ngaysinh = Convert.ToDateTime(collection["ngaysinh"]);
            var E_hinh = collection["hinh"];
            var E_nganhhoc = collection["ma nganh"];
            if (string.IsNullOrEmpty(E_masv))
            {
                ViewData["Error"] = "Don't Empty!";
            }
            else
            {
                E_sinhvien.MaSV = E_masv;
                E_sinhvien.HoTen = E_hoten;
                E_sinhvien.GioiTinh = E_gioitinh;
                E_sinhvien.NgaySinh = E_ngaysinh;
                E_sinhvien.Hinh = E_hinh.ToString();
                E_sinhvien.MaNganh = E_nganhhoc;
                UpdateModel(E_sinhvien);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }
        public ActionResult Delete(string id)
        {
            var D_sinhvien = data.SinhViens.First(m => m.MaSV == id);
            return View(D_sinhvien);
        }
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            var D_sinhvien = data.SinhViens.Where(m => m.MaSV == id).First();
            data.SinhViens.DeleteOnSubmit(D_sinhvien);
            data.SubmitChanges();
            return RedirectToAction("Index");
        }
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/images/" + file.FileName));
            return "/Content/images/" + file.FileName;
        }
    }
}