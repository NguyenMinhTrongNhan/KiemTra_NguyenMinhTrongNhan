using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KiemTra_NguyenMinhTrongNhan.Models
{
    public class hocphan
    {
        Test01DataContext data = new Test01DataContext();
        [Display(Name = "Mã học phần")]
        public string mahp { get; set; }
        [Display(Name = "Tên học phần")]
        public string tenhp { get; set; }
        [Display(Name = "Số tín chỉ")]
        public int sotinchi { get; set; }
        public hocphan(string id)
        {
            mahp = id;
            HocPhan hocPhan = data.HocPhans.Single(n => n.MaHP == mahp);
            tenhp = hocPhan.TenHP;
            sotinchi = Convert.ToInt32(hocPhan.SoTinChi);
        }
    }
}