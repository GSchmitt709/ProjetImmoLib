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
    public class brokersController : Controller
    {

        private agendaEntities db = new agendaEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListBrokers()
        {
            return View(db.brokers.ToList());
        }


        public ActionResult AddBroker()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBroker([Bind(Include = "idBroker,lastname,firstname,mail,phonenumber")] brokers brokers)
        {

            if (ModelState.IsValid)
            {
                db.brokers.Add(brokers);

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

            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult Success()
        {
            return View();
        }

        public ActionResult ProfilBroker(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error");
            }
            brokers brokers = db.brokers.Find(id);
            if (brokers == null)
            {
                return RedirectToAction("Error");
            }
            return View(brokers);
        }

        // EDIT: brokers
        [HttpPost]
        public ActionResult ProfilBroker([Bind(Include = "idBroker,lastname,firstname,mail,phonenumber")] brokers brokers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brokers).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException)
                {
                    return RedirectToAction("Error");
                }
                return RedirectToAction("Index");
            }
            return View(brokers);
        }
    }
}