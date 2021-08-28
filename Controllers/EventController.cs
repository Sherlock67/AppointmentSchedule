using AppoinmentScheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppoinmentScheduler.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        public appoinmentEntities1 db = new appoinmentEntities1();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetEvents()
        {
            var events = db.tbl_appointment.ToList();
            return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public JsonResult SaveEvent(tbl_appointment e){
            var status = false;
            if(e.EventID > 0)
            {
                var v = db.tbl_appointment.Where(x => x.EventID == e.EventID).FirstOrDefault();
                //update
                if (v != null)
                {
                    v.Subject = e.Subject;
                    v.Description = e.Description;
                    v.Start_date = e.Start_date;
                    v.End_date = e.End_date;
                    v.IsFullDay = e.IsFullDay;
                    v.Theme = e.Theme;
                }
            }
            else
            {// new
                db.tbl_appointment.Add(e);

            }
            db.SaveChanges();
            status = true;
            return new JsonResult { Data = new { status = status } };

        }
        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            var status = false;
            var v = db.tbl_appointment.Where(x => x.EventID == eventID).FirstOrDefault();
            if (v != null)
            {
                db.tbl_appointment.Remove(v);
                db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
            
        }
       
    }
}
