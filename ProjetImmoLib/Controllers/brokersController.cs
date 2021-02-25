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

        // GET: brokers
        public ActionResult Index()
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



                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}