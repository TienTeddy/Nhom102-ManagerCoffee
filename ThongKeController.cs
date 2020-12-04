using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom102_ManagerCoffee.Common;

namespace Nhom102_ManagerCoffee.Controllers
{
    public class ThongKeController : Controller
    {
        // GET: ThongKe
        //Thống Kê
        [HttpGet]
        public JsonResult ThongKe()
        {
            //int today = DateTime.Today.Day;

            //int month = DateTime.Today.Month;
            //int year = DateTime.Today.Year;

            string tenthongke = "Tháng " + DateTime.Now.Month.ToString();

            string thoigian = DateTime.Now.ToString("MM/dd/yyyy");

            var dao = new HoaDonDAO();
            double tongthu = 0;
            tongthu = dao.GetHoaDon_TongGia_TrangThaiChua();

            var daothongke = new ThongKeDAO();
            int result = daothongke.CreateThongKe(tenthongke, thoigian, tongthu);

            if (result != 0) return Json(result, JsonRequestBehavior.AllowGet);
            else return Json(0, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult CountSoDon_Ngay()
        {
            var dao = new HoaDonDAO();
            int result = dao.CountHoaDon_Ngay();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult CountSoDon_Thang()
        {
            var dao = new HoaDonDAO();
            int result = dao.CountHoaDon_Thang();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult DoanhThu_Ngay()
        {
            var dao = new HoaDonDAO();
            double result = dao.DoanhThu_Ngay();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult DoanhThu_Thang()
        {
            var dao = new HoaDonDAO();
            double result = dao.DoanhThu_Thang();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult CountSanPham()
        {
            var dao = new SanPhamDAO();
            int result = dao.CountSanPham();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult CountSanPhamDaBan()
        {
            var dao = new SanPhamDAO();
            int result = dao.CountSanPhamDaBan();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}