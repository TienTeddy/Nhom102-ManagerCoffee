﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nhom102_ManagerCoffee.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Checkout
        [HttpPost]
        public JsonResult DatHang(List<HoaDonCT_Model> data)
        {
            var session_acc = SessionHelper.GetSession();
            if (session_acc != null)
            {
                ViewBag.taikhoan = session_acc.TaiKhoan1;
            }

            //create hoadon
            var daohd = new HoaDonDAO();
            int resulthd = daohd.CreateHoaDon(session_acc.id_khachhang, session_acc.hoten); //id_hoadon

            //create hoadonct
            var daoct = new HoaDonCTDAO();
            var result = daoct.CreateHoaDonCTs(data, session_acc.id_khachhang, resulthd);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetHoaDonCTs()
        {
            var session_acc = SessionHelper.GetSession();
            if (session_acc != null)
            {
                var hoadonct = new HoaDonCTDAO();
                var result = hoadonct.GetHoaDonCTs(session_acc.id_khachhang);

                return Json(result, JsonRequestBehavior.AllowGet);
            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetHoaDons()
        {
            var session_acc = SessionHelper.GetSession();
            if (session_acc != null)
            {
                var hoadon = new HoaDonDAO();
                var result = hoadon.GetHoaDons(session_acc.id_khachhang);

                return Json(result, JsonRequestBehavior.AllowGet);
            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}