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
    public class customersController : Controller
    {

        private agendaEntities db = new agendaEntities();

        // GET: customers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListBrokers()
        {
            return View(db.customers.ToList());
        }


        public ActionResult AddBroker()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBroker([Bind(Include = "idCustomers,lastname,firstname,mail,phonenumber,budget")] customers customers)
        {

            if (ModelState.IsValid)
            {
                db.customers.Add(customers);

                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException)
                {
                    return RedirectToAction("Error");
                }

                //db.SaveChanges();
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

        public ActionResult ProfilCustomers(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error");
            }
            customers customers = db.customers.Find(id);
            if (customers == null)
            {
                return RedirectToAction("Error");
            }
            return View(customers);
        }
    }
}