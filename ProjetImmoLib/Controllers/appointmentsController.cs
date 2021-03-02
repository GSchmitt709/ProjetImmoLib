using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetImmoLib;

namespace ProjetImmoLib.Controllers
{
    public class appointmentsController : Controller
    {
        private agendaEntities db = new agendaEntities();
        public ActionResult Index()
        {
            var appointments = db.appointments.Include(a => a.brokers).Include(a => a.customers);
            return View(appointments.ToList());
        }

        public ActionResult AddAppointment()
        {
            ViewBag.idBroker = new SelectList(db.brokers, "idBroker", "lastname");
            ViewBag.idCustomer = new SelectList(db.customers, "idCustomer", "lastname");
            return View();
        }

        [HttpPost]
        public ActionResult AddAppointment([Bind(Include = "idApointment,dateHour,subject,idBroker,idCustomer")] appointments appointments)
        {
            if (ModelState.IsValid)
            {
                int id = appointments.idBroker;
                DateTime rdv = appointments.dateHour;

                if (db.appointments.SqlQuery("set dateformat dmy SELECT * FROM Appointments WHERE idBroker = " + id + " AND dateHour = '" + rdv + "'").Count() == 0)
                {
                    db.appointments.Add(appointments);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DbEntityValidationException)
                    {
                        return RedirectToAction("Error");
                    }
                    return RedirectToAction("Success");
                }
                else
                {
                    return RedirectToAction("Error");
                }
            }
            ViewBag.idBroker = new SelectList(db.brokers, "idBroker", "lastname", appointments.idBroker);
            ViewBag.idCustomer = new SelectList(db.customers, "idCustomer", "lastname", appointments.idCustomer);
            return View(appointments);
        }
        public ActionResult Error()
        {
            return View();
        }

        public ActionResult Success()
        {
            return View();
        }
        public ActionResult ProfilAppointment(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error");
            }
            appointments appointments = db.appointments.Find(id);
            if (appointments == null)
            {
                return RedirectToAction("Error");
            }
            return View(appointments);
        }

        // DELETE
        public ActionResult DeleteAppointment(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error");
            }
            appointments appointments = db.appointments.Find(id);
            if (appointments == null)
            {
                return HttpNotFound();
            }
            return View(appointments);
        }

        [HttpPost, ActionName("DeleteAppointment")]
        public ActionResult DeleteConfirmed(int id)
        {
            appointments appointments = db.appointments.Find(id);
            db.appointments.Remove(appointments);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}