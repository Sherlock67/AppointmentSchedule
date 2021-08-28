using AppoinmentScheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppoinmentScheduler.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        appoinmentEntities1 db = new appoinmentEntities1();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(tbl_admin admin)
        {
            admin.name = admin.name;
            admin.availabletime = admin.availabletime;
            db.tbl_admin.Add(admin);
            db.SaveChanges();
            return View();
        }
        public ActionResult AppointmentList()
        {
            return View(db.tbl_appointment.ToList());
        }
    }
}