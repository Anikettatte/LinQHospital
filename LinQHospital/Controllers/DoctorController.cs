using LinQHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinQHospital.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Doctor
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SaveDoctor(DoctorModel model)
        {
            try
            {
                return Json(new { Message = new DoctorModel().SaveDoctor(model) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior. AllowGet);
            }
        }
        public ActionResult GetDoctorList(String Search)
        {
            try
            {
                return Json(new { model = new DoctorModel().GetDoctorList(Search) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }



    }
}