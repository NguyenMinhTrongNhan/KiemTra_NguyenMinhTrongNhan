using KiemTra_NguyenMinhTrongNhan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KiemTra_NguyenMinhTrongNhan.Controllers
{

    public class HocPhanController : Controller
    {
        Test01DataContext data = new Test01DataContext();

        // GET: HocPhan
        public ActionResult Index()
        {
            var hocphan = from hp in data.HocPhans select hp;
            return View(hocphan);
        }
        public List<HocPhan> LayHocPhan()
        {
            List<HocPhan> listHocPhan = Session["HocPhan"] as List<HocPhan>;
            if (listHocPhan == null)
            {
                listHocPhan = new List<HocPhan>();
                Session["HocPhan"] = listHocPhan;
            }
            return listHocPhan;
        }

        public ActionResult DangKyHP(string id, string strURL)
        {
            List<hocphan> listHocPhan = LayHocPhan();
            hocphan hp = listHocPhan.Find(n => n.mahp == id);
            if (hp == null)
            {
                hp = new hocphan(id);
                listHocPhan.Add(hp);
                return Redirect(strURL);
            }
            else
            {
                return Redirect(strURL);
            }
        }
        private int TongSoLuongHocPhan()
            {
                int tsl = 0;
                List<HocPhan> listHocPhan = Session["HocPhan"] as List<HocPhan>;
                if (listHocPhan != null)
                {
                    tsl = listHocPhan.Count;
                }
                return tsl;
            }

            public ActionResult XoaHocPhan(string id)
            {
                List<HocPhan> listHocPhan = LayHocPhan();
                HocPhan hp = listHocPhan.SingleOrDefault(n => n.MaHP == id);
                if (hp != null)
                {
                    listHocPhan.RemoveAll(n => n.MaHP == id);
                    return RedirectToAction("HocPhan");
                }
                return RedirectToAction("HocPhan");
            }
        public ActionResult XoaTatCaDangKyHP()
        {
            List<hocphan> listHocPhan = LayHocPhan();
            listHocPhan.Clear();
            return RedirectToAction("HocPhan");
        }
        public ActionResult HocPhan()
        {
            List<hocphan> listHocPhan = LayHocPhan();
            ViewBag.TongSoLuongHocPhan = TongSoLuongHocPhan();
            return View(listHocPhan);
        }

        public ActionResult HocPhanPartial()
        {
            ViewBag.TongSoLuongHocPhan = TongSoLuongHocPhan();
            return PartialView();
        }


    }
}